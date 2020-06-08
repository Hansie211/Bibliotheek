using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Book : DatabaseRecord {

        public Edition Edition { get; set; }
        public string State { get; set; }
        public DateTime AddedAt { get; set; }

        public bool InInventory { get; set; }
    }
}