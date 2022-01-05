using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YachtRent.Models
{
    [MetadataType(typeof(CustomersMetaData))]
    public partial class Customers
    {
        public class CustomersMetaData
        {
            [DisplayName("Imię")]
            public string CustomerName { get; set; }
            [DisplayName("Kraj")]
            public string Country { get; set; }
            [DisplayName("Tel. Komórkowy")]
            public Nullable<int> MobilePhone { get; set; }
        }
    }
}