using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {

    public class Employee : DatabaseRecord, IAddress, IPerson {

        public string FirstName { get; set; }
        public string Affix { get; set; }
        public string LastName { get; set; }

        public string Street { get; set; }
        public int Number { get; set; }
        public string NumberSuffix { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string AddressNote { get; set; }

        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}