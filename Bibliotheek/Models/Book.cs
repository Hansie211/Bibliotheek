using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Books" )]
    public class Book : DatabaseRecord {

        [ForeignKey( "EditionID" )]
        public Edition Edition { get; set; }

        [Field( "State", SqlDbType.VarChar )]
        public string State { get; set; }
        [Field( "AddedAt", SqlDbType.Date )]
        public DateTime AddedAt { get; set; }

        [Field( "InInventory", SqlDbType.Bit )]
        public bool InInventory { get; set; }
    }
}