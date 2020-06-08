using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {

    public class Library : DatabaseRecord, IAddress {

        public IList<Employee> Employees { get; set; }

        public string EmailAddress { get; set; }
        public string Telephone { get; set; }

        public string Street { get; set; }
        public int Number { get; set; }
        public string NumberSuffix { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string AddressNote { get; set; }
    }
}