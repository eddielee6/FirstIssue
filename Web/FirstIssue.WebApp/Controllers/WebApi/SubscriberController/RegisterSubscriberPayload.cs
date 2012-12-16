using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Controllers.WebApi
{
    public class RegisterSubscriberPayload
    {
        /// <summary>
        /// APNS unique device id
        /// </summary>
        public string DeviceToken { get; set; }

        /// <summary>
        /// Encrypted receipt data from store kit
        /// </summary>
        public string EncryptedReceiptData { get; set; }
    }
}