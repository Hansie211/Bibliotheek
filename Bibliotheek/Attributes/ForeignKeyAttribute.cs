using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Attributes {

    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
    public class ForeignKeyAttribute : FieldAttribute {

        public ForeignKeyAttribute( string fieldName, SqlDbType dbType = SqlDbType.Int, int size = 0 ) : base( fieldName, dbType, size ) {
        }
    }
}