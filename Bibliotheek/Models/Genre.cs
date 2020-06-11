using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Genres" )]
    public class Genre : DatabaseRecord {

        [Field( "Name", SqlDbType.VarChar )]
        public string Name { get; set; }
    }
}