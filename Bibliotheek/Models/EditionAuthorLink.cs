using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "EditionAuthors" )]
    public class EditionAuthorLink {

        [ForeignKey( "EditionID" )]
        public Edition Edition { get; set; }
        [ForeignKey( "AuthorID" )]
        public Author Author { get; set; }
    }
}