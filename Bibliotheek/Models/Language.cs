using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Languages" )]
    public class Language : DatabaseRecord {

        [Field( "Name", SqlDbType.VarChar )]
        public string Name { get; set; }
    }
}