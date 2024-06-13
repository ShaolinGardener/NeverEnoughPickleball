using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Transcriptions;

namespace NEP.Models

{
    internal class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string record_type { get; set; }
        public string enabled { get; set; }
        public string messaging_enabled { get; set; }
        public string messaging_template { get; set; }
        public string default_verification_timeout_secs { get; set; }
        public string rcs_enabled { get; set; }
        public string vsms_enabled { get; set; }
        public string language { get; set; }
        //public string sms\":{\"enabled\":true,\"messaging_enabled\":true,\"messaging_template\":\"Never Enough Pickleball asks that you use this code to verify your account: {code}.\",\"default_verification_timeout_secs\":300,\"rcs_enabled\":true,\"vsms_enabled\":true,\"code_length\":5},\"psd2\":{\"enabled\":true,\"default_verification_timeout_secs\":300,\"messaging_template\":\"Your code is {code} for payment to {payee} in the amount of {amount} {currency}.\"},\"call\":{\"enabled\":true,\"messaging_template\":\"Never Enough Pickleball asks that you use this code to verify your account: {code}.\",\"default_verification_timeout_secs\":300,\"default_call_timeout_sec\":30,\"code_length\":5},\"whatsapp\":null,\"flashcall\":{\"enabled\":true,\"default_verification_timeout_secs\":300},\"webhook_url\":\"http://example.com/webhook\",\"webhook_failover_url\":\"http://example.com/webhook/failover\"}],\"meta\":{\"total_pages\":1,\"total_results\":1,\"page_number\":1,\"page_size\":25}}"
    }
}


/*
{'data': [{'id': '49000188-bedb-116f-9c98-27c0e00d9853', 'name': 'NEP Profile', 'created_at': '2023-06-15T11:40:07.925967', 'updated_at': '2023-06-15T11:40:07.925967', 'record_type': 'verify_profile', 'enabled': True, 'messaging_enabled': True, 'messaging_template': 'Never Enough Pickleball asks that you use this code to verify your account: {code}.', 'default_verification_timeout_secs': 300, 'rcs_enabled': True, 'vsms_enabled': True, 'language': 'en-US', 'sms': {'enabled': True, 'messaging_enabled': True, 'messaging_template': 'Never Enough Pickleball asks that you use this code to verify your account: {code}.', 'default_verification_timeout_secs': 300, 'rcs_enabled': True, 'vsms_enabled': True, 'code_length': 5}, 'psd2': {'enabled': True, 'default_verification_timeout_secs': 300, 'messaging_template': 'Your code is {code} for payment to {payee} in the amount of {amount} {currency}.'}, 'call': {'enabled': True, 'messaging_template': 'Never Enough Pickleball asks that you use this code to verify your account: {code}.', 'default_verification_timeout_secs': 300, 'default_call_timeout_sec': 30, 'code_length': 5}, 'whatsapp': None, 'flashcall': {'enabled': True, 'default_verification_timeout_secs': 300}, 'webhook_url': 'http://example.com/webhook', 'webhook_failover_url': 'http://example.com/webhook/failover'}], 'meta': {'total_pages': 1, 'total_results': 1, 'page_number': 1, 'page_size': 25}}
*/