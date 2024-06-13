using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using GoogleMaps.LocationServices;
using NEP.Models;
using NEP.Data;
using Azure.Core;
using Telnyx;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using GoogleApi.Entities.Maps.Common;
using NetTopologySuite.Geometries;

namespace NEP.Models
{
    public class ProximitySearch
    {
        private NEPContext _context;
        private static string _apiKey = "AIzaSyBx17PDWs2heQzV65kW7ztN9PaOE42xZDU"; //AIzaSyBx17PDWs2heQzV65kW7ztN9PaOE42xZDU
        public static string APIKey { get { return _apiKey; } }


        public ProximitySearch(NEPContext context)
        {
            _context = context;
        }


        public void DoProximitySearch(string targetZipCode, double searchRadius)
        {
            //string apiKey = "AIzaSyBx17PDWs2heQzV65kW7ztN9PaOE42xZDU"; // Replace with your Google Maps API key  35.145.67.15
            //string targetZipCode = "TARGET_ZIP_CODE"; // Replace with the target zip code
            //double searchRadius = 10.0; // Specify the search radius in miles



            List<Address> addresses = GetAddressesWithinRadius(targetZipCode, searchRadius);

            Console.WriteLine("Addresses within the search radius:");
            foreach (Address address in addresses)
            {
                Console.WriteLine($"{address.Address1}, {address.City}, {address.State} {address.ZipCode}");
            }
        }

        // call to get latlong from google https://maps.googleapis.com/maps/api/geocode/json?address=326 Riley Ave Ne Palm Bay, FL 32907&key=AIzaSyBx17PDWs2heQzV65kW7ztN9PaOE42xZDU
        // look for
        // "location": {
        //"lat": 28.005241,
        // "lng": -80.62941789999999

        /*
        gcurl https://apikeys.googleapis.com/v2/projects/PROJECT_NUMBER/locations/global/keys \
      --request POST \
      --data '{
        "displayName" : "API key with browser restrictions",
        "restrictions" : {
          "browserKeyRestrictions": {
            "allowedReferrers": ["www.example.com", "www.example-2.com"]
          }
        }
      }'
            

        gcurl https://apikeys.googleapis.com/v2/projects/exalted-slice-329720/locations/global/keys  \
          --request POST \
          --data  '{
            "displayName" : "API key with server restrictions with IPv4, IPv6 and CIDR",
            "restrictions" : {
              "serverKeyRestrictions": {
                "allowedIps": ["35.145.67.15"]
            }
        }
          }'
                */
        private List<Address> GetAddressesWithinRadius(string targetZipCode, double searchRadius)
        {
            var locationService = new GoogleLocationService(_apiKey);

            var targetZipCodeLocation = locationService.GetLatLongFromAddress(targetZipCode);
            double targetLatitude = targetZipCodeLocation.Latitude;
            double targetLongitude = targetZipCodeLocation.Longitude;

            using (_context)
            {
                var addresses = _context.Addresses.ToList();

                var addressesWithinRadius = new List<Address>();
                foreach (var address in addresses)
                {
                    double distance = CalculateDistance(targetLatitude, targetLongitude, address.Latitude, address.Longitude);

                    if (distance <= searchRadius)
                    {
                        addressesWithinRadius.Add(address);
                    }
                }

                return addressesWithinRadius;
            }
        }
        public static GoogleLocation GetLocationFromAddressAsync(string address)
        {
            try
            {
                var locationService = new GoogleLocationService(_apiKey);
                var targetZipCodeLocation = locationService.GetLatLongFromAddress(address);
                GoogleLocation gl = new GoogleLocation() { Latitude = targetZipCodeLocation.Latitude, Longitude = targetZipCodeLocation.Longitude };
                return gl;
            }
            catch(Exception ex) {
                return null;
            }

            //using (var client = new HttpClient())
            //{
            //    string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";
            //    // https://maps.googleapis.com/maps/api/geocode/json?address=326 Riley Ave Ne Palm Bay, FL 32907&key=AIzaSyBx17PDWs2heQzV65kW7ztN9PaOE42xZDU
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync(apiUrl);
            //        var content= response.Content.ReadAsStringAsync();
            //        if (response.IsSuccessStatusCode)
            //        {
            //            GoogleGeocodeResponse geocodeResponse = await response.Content.ReadFromJsonAsync<GoogleGeocodeResponse>();

            //            if (geocodeResponse?.Results?.Count > 0)
            //            {
            //                return geocodeResponse.Results[0].Geometry.Location;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Error occurred while calling the API: " + ex.Message);
            //    }

            //    return null;
            //}

        }

        public static async Task<string> GetCountyFromCoordinates(double latitude, double longitude)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={_apiKey}";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(jsonString);

                    var results = jsonObject["results"];
                    if (results != null && results.HasValues)
                    {
                        var addressComponents = results[0]["address_components"];
                        if (addressComponents != null && addressComponents.HasValues)
                        {
                            foreach (var component in addressComponents)
                            {
                                var types = component["types"];
                                if (types != null && types.HasValues)
                                {
                                    if (types.Any(t => t.ToString() == "administrative_area_level_2"))
                                    {
                                        return component["long_name"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }

                // Return null if county not found or any error occurred
                return null;
            }
        }

        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 3958.8; // Radius of the Earth in miles

            var latDiff = ToRadians(lat2 - lat1);
            var lonDiff = ToRadians(lon2 - lon1);

            var a = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(lonDiff / 2) * Math.Sin(lonDiff / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = R * c;

            return distance;
        }

        private static double ToRadians(double degree)
        {
            return degree * Math.PI / 180;
        }

        public List<Facility> GetFacilitiesWithinRadius(double centerLatitude, double centerLongitude, double radiusInKilometers)
        {
            return _context.GetFacilitiesWithinRadius(centerLatitude, centerLongitude, radiusInKilometers);
        }

        public List<Facility> GetFacilitiesWithinRadiusWithDistance(double centerLatitude, double centerLongitude, double radiusInKilometers)
        {
            return _context.GetFacilitiesWithinRadiusWithDistance(centerLatitude, centerLongitude, radiusInKilometers);
        }

    }

    //public List<Location> GetLocationsWithinRadius(double centerLatitude, double centerLongitude, double radiusInKilometers)
    //{
    //    var centerPoint = CreatePoint(centerLatitude, centerLongitude);

    //    // EF Core supports spatial functions, so we can use them in the query.
    //    return _context.Locations
    //        .Where(location => location.Point.Distance(centerPoint) <= radiusInKilometers * 1000) // Convert radius to meters
    //        .ToList();
    //}

    //private static Microsoft.EntityFrameworkCore.DbFunctionsExtensions.Point CreatePoint(double latitude, double longitude)
    //{
    //    // Use the following function to create a point from latitude and longitude.
    //    return Microsoft.EntityFrameworkCore.DbFunctionsExtensions.Point(latitude, longitude);
    //}




    //public void DoProximitySearch()
    //{
    //    string apiKey = "YOUR_API_KEY"; // Replace with your Google Maps API key
    //    string targetZipCode = "TARGET_ZIP_CODE"; // Replace with the target zip code
    //    double searchRadius = 10.0; // Specify the search radius in miles

    //    List<string> nearbyZipCodes = GetNearbyZipCodes(targetZipCode, searchRadius, apiKey);

    //    Console.WriteLine("Nearby zip codes:");
    //    foreach (string zipCode in nearbyZipCodes)
    //    {
    //        Console.WriteLine(zipCode);
    //    }
    //}

    //private static List<string> GetNearbyZipCodes(string targetZipCode, double searchRadius, string apiKey)
    //{
    //    var locationService = new GoogleLocationService(apiKey);

    //    var zipCodeLocation = locationService.GetLatLongFromAddress(targetZipCode);
    //    double targetLatitude = zipCodeLocation.Latitude;
    //    double targetLongitude = zipCodeLocation.Longitude;

    //    var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json");
    //    var request = new RestRequest(Method.GET);
    //    request.AddParameter("latlng", $"{targetLatitude},{targetLongitude}");
    //    request.AddParameter("result_type", "postal_code");
    //    request.AddParameter("key", apiKey);

    //    IRestResponse<GoogleGeocodeResponse> response = client.Execute<GoogleGeocodeResponse>(request);

    //    var nearbyZipCodes = new List<string>();
    //    if (response.IsSuccessful)
    //    {
    //        var targetZipCodeResult = response.Data.Results.FirstOrDefault();
    //        if (targetZipCodeResult != null)
    //        {
    //            string targetPostalCode = targetZipCodeResult.AddressComponents.FirstOrDefault(ac => ac.Types.Contains("postal_code"))?.LongName;

    //            if (!string.IsNullOrEmpty(targetPostalCode))
    //            {
    //                var nearbyResults = response.Data.Results.Where(r => r.AddressComponents.Any(ac => ac.Types.Contains("postal_code"))).ToList();
    //                foreach (var result in nearbyResults)
    //                {
    //                    string postalCode = result.AddressComponents.FirstOrDefault(ac => ac.Types.Contains("postal_code"))?.LongName;

    //                    if (!string.IsNullOrEmpty(postalCode) && postalCode != targetPostalCode)
    //                    {
    //                        double distance = CalculateDistance(targetLatitude, targetLongitude, result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);

    //                        if (distance <= searchRadius)
    //                        {
    //                            nearbyZipCodes.Add(postalCode);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Error occurred while calling the Google Maps API.");
    //    }

    //    return nearbyZipCodes;
    //}

    //private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    //{
    //    var R = 3958.8; // Radius of the Earth in miles

    //    var latDiff = ToRadians(lat2 - lat1);
    //    var lonDiff = ToRadians(lon2 - lon1);

    //    var a = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
    //            Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
    //            Math.Sin(lonDiff / 2) * Math.Sin(lonDiff / 2);
    //    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

    //    var distance = R * c;

    //    return distance;
    //}

    //private static double ToRadians(double degree)
    //{
    //    return degree * Math.PI / 180;
    //}


    // Models


}