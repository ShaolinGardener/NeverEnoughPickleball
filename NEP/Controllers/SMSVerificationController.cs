using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NEP.Controllers
{
    public class SMSVerificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendSMSVerification()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SubmitSMSVerification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendSMSVerification(string phoneNumber)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // with AddHttpClient we register the IHttpClientFactory
                    services.AddHttpClient();
                    // here, we register the dependency injection  
                    services.AddTransient<IServiceManagement, ServiceManagement>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            var myService = host.Services.GetRequiredService<IServiceManagement>();

            var send = await myService.SendSMSVerification(phoneNumber);
            ViewBag.SmsVerification = send;
            ViewBag.PhoneNumber= phoneNumber;
            
            return View("SubmitSMSVerification",ViewBag.PhoneNumber);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSMSVerification(string phoneNumber, string code)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // with AddHttpClient we register the IHttpClientFactory
                    services.AddHttpClient();
                    // here, we register the dependency injection  
                    services.AddTransient<IServiceManagement, ServiceManagement>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            var myService = host.Services.GetRequiredService<IServiceManagement>();

            var submit = await myService.SubmitSMSVerification(phoneNumber, code);
            if (submit.ToLower().Contains("accepted"))
            {
                ViewBag.SMSVerified = true;
            }
            return View();
        }
    }
}



//[HttpDelete]
//public IActionResult DeleteProfile(Guid profileId)
//{


//    var client = _httpClientFactory.CreateClient();
//    client.DefaultRequestHeaders.Add("Authorization", "Bearer <YOUR_TOKEN_HERE>");
//    var VerifyProfileId = profileId;
//    var request = await client.DeleteAsync("https://api.telnyx.com/v2/verify_profiles/" + VerifyProfileId);
//    var response = await request.Content.ReadAsStringAsync();

//    return View();
//}


//    [HttpPut]
//    public IActionResult PutProfile()
//    {
//        var client = _httpClientFactory.CreateClient();
//        client.DefaultRequestHeaders.Add("Authorization", "Bearer <YOUR_TOKEN_HERE>");
//        JObject json = JObject.Parse(@"{
//    call: {
//      default_call_timeout_secs: 30,
//      default_verification_timeout_secs: 300,
//      msg_template: 'Hello, this is the Acme Inc verification code you requested: {code}.'
//    },
//    flashcall: {
//      default_verification_timeout_secs: 300
//    },
//    language: 'en-US',
//    name: 'Test Profile',
//    psd2: {
//      default_verification_timeout_secs: 300
//    },
//    sms: {
//      default_verification_timeout_secs: 300,
//      messaging_enabled: true,
//      messaging_template: 'Hello, this is the Acme Inc verification code you requested: {code}.',
//      rcs_enabled: true,
//      vsms_enabled: true
//    },
//    webhook_failover_url: 'http://example.com/webhook/failover',
//    webhook_url: 'http://example.com/webhook'
//  }");
//        var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
//        var request = await client.PostAsync("https://api.telnyx.com/v2/verify_profiles", postData);
//        var response = await request.Content.ReadAsStringAsync();

//        Console.WriteLine(response);
//    }
//}

//[HttpGet]
//public async Task<IActionResult> GetAllProfiles()
//{
//    var client = _httpClientFactory.CreateClient();
//    client.DefaultRequestHeaders.Add("Authorization", "Bearer <YOUR_TOKEN_HERE>");
//    var request = await client.GetAsync("https://api.telnyx.com/v2/verify_profiles?filter%5Bname%5D=string&page%5Bsize%5D=25&page%5Bnumber%5D=1");
//    var response = await request.Content.ReadAsStringAsync();

//    return View();
//}

//  [HttpGet]
//  public IActionResult SendVerificationSMS(string phoneNumber)
//  {
//      var client = _httpClientFactory.CreateClient();
//      client.DefaultRequestHeaders.Add("Authorization", "Bearer <YOUR_TOKEN_HERE>");
//      JObject json = JObject.Parse(@"{
//  phone_number: '+',
//  timeout_secs: 300,
//  verify_profile_id: '12ade33a-21c0-473b-b055-b3c836e1c292'
//}");
//      var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
//      var request = await client.PostAsync("https://api.telnyx.com/v2/verifications/sms", postData);
//      var response = await request.Content.ReadAsStringAsync();

//      Console.WriteLine(response);
//  }

//  [HttpGet]
//  public IActionResult RetrieveVerificationSMS(string code, string phoneNumber)
//  {
//      var client = _httpClientFactory.CreateClient();
//      client.DefaultRequestHeaders.Add("Authorization", "Bearer <YOUR_TOKEN_HERE>");
//      JObject json = JObject.Parse(@"{
//  phone_number: '+13035551234',
//  timeout_secs: 300,
//  verify_profile_id: '12ade33a-21c0-473b-b055-b3c836e1c292'
//}");
//      var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
//      var request = await client.PostAsync("https://api.telnyx.com/v2/verifications/sms", postData);
//      var response = await request.Content.ReadAsStringAsync();

//      Console.WriteLine(response);
//  }