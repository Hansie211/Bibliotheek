using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Memberships" )]
    public class Membership : DatabaseRecord {

        public static readonly string CardNumberFormat = "9999 1164 0000 {0:D4}";

        [ForeignKey( "MemberID" )]
        public Member Member { get; set; }

        [Field( "StartDate", SqlDbType.Date )]
        public DateTime StartDate { get; set; }
        [Field( "EndDate", SqlDbType.Date )]
        public DateTime EndDate { get; set; }

        public string GetCardNumber() {
            return string.Format( CardNumberFormat, ID );
        }
    }
}