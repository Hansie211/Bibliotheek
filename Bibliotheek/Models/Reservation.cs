using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Reservation : DatabaseRecord {

        public Book Book { get; set; }
        public Library Library { get; set; }
        public Member Member { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}