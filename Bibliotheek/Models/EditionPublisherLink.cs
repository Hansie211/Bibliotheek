using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.Models {

    [TableName( "EditionPublishers" )]
    public class EditionPublisherLink {

        [ForeignKey( "EditionID" )]
        public Edition Edition { get; set; }
        [ForeignKey( "PublisherID" )]
        public Publisher Publisher { get; set; }
    }
}