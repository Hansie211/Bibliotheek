using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Edition : DatabaseRecord {

        public Language Language { get; set; }

        public string Title { get; set; }
        public string ISBN { get; set; }

        public DateTime PublishDate { get; set; }
    }
}