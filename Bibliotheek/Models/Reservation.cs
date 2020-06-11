using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Reservations" )]
    public class Reservation : DatabaseRecord {

        [ForeignKey( "BookID" )]
        public Book Book { get; set; }
        [ForeignKey( "LibraryID" )]
        public Library Library { get; set; }
        [ForeignKey( "MemberID" )]
        public Member Member { get; set; }

        [Field( "StartDate", SqlDbType.Date )]
        public DateTime StartDate { get; set; }
        [Field( "ReturnDate", SqlDbType.Date )]
        public DateTime ReturnDate { get; set; }
    }
}