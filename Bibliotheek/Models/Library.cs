using Bibliotheek.Attributes;
using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {

    public class Library : DatabaseRecord, IAddress {

        public IList<Employee> Employees { get; set; }

        [Field( "EmailAddress", SqlDbType.VarChar )]
        public string EmailAddress { get; set; }
        [Field( "Telephone", SqlDbType.VarChar )]
        public string Telephone { get; set; }

        [Field( "Street", SqlDbType.VarChar )]
        public string Street { get; set; }
        [Field( "Number", SqlDbType.Int )]
        public int Number { get; set; }
        [Field( "NumberSuffix", SqlDbType.VarChar )]
        public string NumberSuffix { get; set; }
        [Field( "ZipCode", SqlDbType.VarChar )]
        public string ZipCode { get; set; }
        [Field( "Place", SqlDbType.VarChar )]
        public string Place { get; set; }
        [Field( "AddressNote", SqlDbType.VarChar )]
        public string AddressNote { get; set; }
    }
}