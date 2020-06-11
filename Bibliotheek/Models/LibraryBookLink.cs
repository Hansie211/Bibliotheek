using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "LibraryBooks" )]
    public class LibraryBookLink {

        [ForeignKey( "LibraryID" )]
        public Library Library { get; set; }
        [ForeignKey( "BookID" )]
        public Book Book { get; set; }
    }
}