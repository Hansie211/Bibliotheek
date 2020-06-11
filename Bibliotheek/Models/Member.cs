using Bibliotheek.Attributes;
using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Members" )]
    public class Member : DatabaseRecord, IAddress, IPerson {

        [Field( "FirstName", SqlDbType.VarChar )]
        public string FirstName { get; set; }
        [Field( "Affix", SqlDbType.VarChar )]
        public string Affix { get; set; }
        [Field( "LastName", SqlDbType.VarChar )]
        public string LastName { get; set; }
        [Field( "BirthDate", SqlDbType.Date )]
        public DateTime BirthDate { get; set; }

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
        [Field( "AddressNote", SqlDbType.VarChar, 1023 )]
        public string AddressNote { get; set; }

        public Member() {

        }
    }
}