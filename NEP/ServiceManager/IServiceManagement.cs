using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEP
{
    internal interface IServiceManagement
    {

        Task<string> GetAllProfiles();
        Task<string> SendSMSVerification(string phoneNumber);
        Task<string> SubmitSMSVerification(string phoneNumber, string code);
    }

}
