using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Interfaces {

    public interface IAddress {

        string Street { get; set; }

        int Number { get; set; }
        string NumberSuffix { get; set; }

        string ZipCode { get; set; }
        string Place { get; set; }

        string AddressNote { get; set; }
    }
}