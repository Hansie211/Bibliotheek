using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Models {
    public class Fine : DatabaseRecord {

        public Member Member { get; set; }
        public Book Book { get; set; }

        [Field( "Price", SqlDbType.Decimal )]
        public decimal Price { get; set; }
    }
}