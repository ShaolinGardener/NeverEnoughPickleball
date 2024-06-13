using NEP.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NEP
{

    internal class ServiceManagement : IServiceManagement
    {
        private readonly IHttpClientFactory _clientFactory;

        public ServiceManagement(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetAllProfiles()
        {

            List<Profile> lstProfiles = null;
            // Call the method Get

             var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H");
            var request = await client.GetAsync("https://api.telnyx.com/v2/verify_profiles?filter%5Bname%5D=string&page%5Bsize%5D=25&page%5Bnumber%5D=1");
            //var responseService = await request.Content.ReadAsStringAsync();

            string output = string.Empty;
            // Check the response
            if (request.IsSuccessStatusCode)
            {
                // Read the list of Users
                var outputService = await request.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                output = outputService;
            }

            return output;
        }

        async Task<string> IServiceManagement.SendSMSVerification(string phoneNumber)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H");
            JObject json = JObject.Parse(@"{
                phone_number: '+1" + phoneNumber + @"',
                timeout_secs: 300,
                verify_profile_id: '49000188-bedb-116f-9c98-27c0e00d9853'
              }");
            var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = await client.PostAsync("https://api.telnyx.com/v2/verifications/sms", postData);
            var response = await request.Content.ReadAsStringAsync();

            return response;
        }

        async Task<string> IServiceManagement.SubmitSMSVerification(string phoneNumber, string code)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H");
            JObject json = JObject.Parse(@"{
                code: '" + code + @"',
                verify_profile_id: '49000188-bedb-116f-9c98-27c0e00d9853'
              }");
            var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var PhoneNumber = "+1" + phoneNumber;
            var request = await client.PostAsync("https://api.telnyx.com/v2/verifications/by_phone_number/" + PhoneNumber + "/actions/verify", postData);
            var response = await request.Content.ReadAsStringAsync();

            return response;
        }
    }
}


