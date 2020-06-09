using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Reservation : DatabaseRecord {

        public Book Book { get; set; }
        public Library Library { get; set; }
        public Member Member { get; set; }

        [Field( "StartDate", SqlDbType.Date )]
        public DateTime StartDate { get; set; }
        [Field( "ReturnDate", SqlDbType.Date )]
        public DateTime ReturnDate { get; set; }

    }
}