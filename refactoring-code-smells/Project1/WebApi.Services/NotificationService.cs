using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class NotificationService
    {

        public bool SendNotification(string email = null, string sms = null)
        {
            if (!string.IsNullOrEmpty(email))
                SendEmail();
            else
                SendSMS();

            return true;
        }

        private void SendEmail()
        {
            // ...
        }

        private void SendSMS()
        {
            // ...
        }
    }
}
