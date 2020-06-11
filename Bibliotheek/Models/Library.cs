using Bibliotheek.Attributes;
using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Libraries" )]
    public class Library : DatabaseRecord, IAddress {

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
        [Field( "ZipCode", SqlDbType.Char, 6 )]
        public string ZipCode { get; set; }
        [Field( "Place", SqlDbType.VarChar )]
        public string Place { get; set; }
        [Field( "AddressNote", SqlDbType.VarChar )]
        public string AddressNote { get; set; }
    }
}