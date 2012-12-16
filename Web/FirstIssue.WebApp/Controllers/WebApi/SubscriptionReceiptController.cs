using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers.WebApi
{
    public class SubscriptionReceiptController : ApiBaseController
    {
        public HttpResponseMessage RegisterSubscription(SubscriptionReceiptData transactionReceipt)
        {
            // MR - TODO 
            var receipt = ReceiptVerificationService.GetReceipt(true, transactionReceipt.RecieptData);
                        
            var result = new ReceiptVerificationResult();

            if (ReceiptVerificationService.IsReceiptValid(receipt))
            {
                result.IsReceiptValid = true;
            }
            else
            {
                result.IsReceiptValid = false;
            }

            return Request.CreateResponse<ReceiptVerificationResult>(HttpStatusCode.OK, result);
        }

    }
}
