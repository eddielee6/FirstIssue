using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class Subscriber
    {
        [Key, Column(Order = 0)]
        public int MagazineId { get; set; }
        public Magazine Magazine { get; set; }

        [Key, Column(Order = 1)]
        public string DeviceToken { get; set; }

        public string ReceiptData { get; set; }   
    }
}