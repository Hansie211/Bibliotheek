using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "Editions" )]
    public class Edition : DatabaseRecord {

        [ForeignKey( "LanguageID" )]
        public Language Language { get; set; }

        [Field( "Title", SqlDbType.VarChar )]
        public string Title { get; set; }
        [Field( "ISBN", SqlDbType.VarChar )]
        public string ISBN { get; set; }

        [Field( "PublishDate", SqlDbType.Date )]
        public DateTime PublishDate { get; set; }
    }
}