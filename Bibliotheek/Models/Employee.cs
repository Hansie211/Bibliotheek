﻿using Bibliotheek.Attributes;
using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Employees" )]
    public class Employee : DatabaseRecord, IAddress, IPerson {

        [ForeignKey( "LibraryID" )]
        public Library Library { get; set; }

        [Field( "FirstName", SqlDbType.VarChar )]
        public string FirstName { get; set; }
        [Field( "Affix", SqlDbType.VarChar )]
        public string Affix { get; set; }
        [Field( "LastName", SqlDbType.VarChar )]
        public string LastName { get; set; }

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

        [Field( "PasswordHash", SqlDbType.VarChar )]
        public string PasswordHash { get; set; }
        [Field( "PasswordSalt", SqlDbType.VarChar, 48 )]
        public byte[] PasswordSalt { get; set; }
    }
}