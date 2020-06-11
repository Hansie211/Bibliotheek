using Bibliotheek.Attributes;
using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Authors" )]
    public class Author : DatabaseRecord, IPerson {

        [Field( "FirstName", SqlDbType.VarChar )]
        public string FirstName { get; set; }
        [Field( "Affix", SqlDbType.VarChar )]
        public string Affix { get; set; }
        [Field( "LastName", SqlDbType.VarChar )]
        public string LastName { get; set; }
    }
}