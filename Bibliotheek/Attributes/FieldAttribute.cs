using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bibliotheek.Attributes {

    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
    public class FieldAttribute : Attribute {

        public string FieldName { get; set; }
        public SqlDbType DbType { get; set; }
        public int Size { get; set; }

        private int GetDefaultSize( SqlDbType dbType ) {

            switch ( dbType ) {
                case SqlDbType.VarChar:
                    return 255;
            }

            return 0;
        }

        public FieldAttribute( string fieldName, SqlDbType dbType, int size = 0 ) {

            if ( size < 1 ) {

                size =  GetDefaultSize( dbType );
            }

            FieldName   = fieldName;
            DbType      = dbType;
            Size        = size;
        }
    }
}