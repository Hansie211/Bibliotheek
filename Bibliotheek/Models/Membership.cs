using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Memberships" )]
    public class Membership : DatabaseRecord {

        public static readonly string CardNumberFormat = "9999 1164 0000 {0:D4}";

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string GetCardNumber() {
            return string.Format( CardNumberFormat, ID );
        }
    }
}