using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            MailjetClient client = new MailjetClient("d49e60a57d1ebfb25534390a758fdf6e", "92984d6f1bf3cb1d68aa82f887349d10")
            {
                
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                 new JObject {
                  {
                   "From",
                   new JObject {
                    {"Email", "jacky0405dragon@gmail.com"},
                    {"Name", "jacky"}
                   }
                  }, {
                   "To",
                   new JArray {
                    new JObject {
                     {
                      "Email",
                      email
                     }, {
                      "Name",
                      "JFun"
                     }
                    }
                   }
                  }, {
                   "Subject",
                   subject
                  }, {
                   "HTMLPart",
                   body
                  }, 
                 }
                         });
           await client.PostAsync(request);
        }
    }
}
