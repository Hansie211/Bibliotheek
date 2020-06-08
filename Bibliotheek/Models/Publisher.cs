using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Publisher : DatabaseRecord {

        public string Name { get; set; }
        public string Location { get; set; }
    }
}