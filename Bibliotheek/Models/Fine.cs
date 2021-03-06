﻿using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Fines" )]
    public class Fine : DatabaseRecord {

        [ForeignKey( "BookID" )]
        public Book Book { get; set; }
        [ForeignKey( "MemberID" )]
        public Member Member { get; set; }

        [Field( "Price", SqlDbType.Decimal )]
        public decimal Price { get; set; }
    }
}