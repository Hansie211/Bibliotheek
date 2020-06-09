using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Edition : DatabaseRecord {

        public Language Language { get; set; }

        [Field( "Title", SqlDbType.VarChar )]
        public string Title { get; set; }
        [Field( "ISBN", SqlDbType.VarChar )]
        public string ISBN { get; set; }

        [Field( "PublishDate", SqlDbType.Date )]
        public DateTime PublishDate { get; set; }
    }
}