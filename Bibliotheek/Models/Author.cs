using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Author : DatabaseRecord, IPerson {

        public string FirstName { get; set; }
        public string Affix { get; set; }
        public string LastName { get; set; }
    }
}