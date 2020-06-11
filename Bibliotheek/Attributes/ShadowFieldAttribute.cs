using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Attributes {

    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
    public class ShadowFieldAttribute : FieldAttribute {

        public ShadowFieldAttribute( string fieldName, SqlDbType dbType, int size = 0 ) : base( fieldName, dbType, size ) {
        }
    }
}