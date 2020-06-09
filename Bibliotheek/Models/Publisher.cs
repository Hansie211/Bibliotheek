using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Publisher : DatabaseRecord {

        [Field( "Name", SqlDbType.VarChar )]
        public string Name { get; set; }
        [Field( "Location", SqlDbType.VarChar )]
        public string Location { get; set; }
    }
}