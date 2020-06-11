using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "EditionGenres" )]
    public class EditionGenreLink {

        [ForeignKey( "EditionID" )]
        public Edition Edition { get; set; }
        [ForeignKey( "GenreID" )]
        public Genre Genre { get; set; }
    }
}