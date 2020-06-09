using Bibliotheek.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;

namespace Bibliotheek.Extensions {
    public static class SqlExtensions {

        private static FieldAttribute GetFieldAttribute<T>( Expression<Func<T, object>> expr ) {

            PropertyInfo prop;

            if ( expr.Body is MemberExpression expression ) {

                prop = expression.Member as PropertyInfo;
            } else {

                var memberExpression = ( (UnaryExpression)expr.Body ).Operand as MemberExpression;
                prop = memberExpression.Member as PropertyInfo;
            }

            IEnumerable<FieldAttribute> attrs = prop.GetCustomAttributes<FieldAttribute>( true );

            return attrs.FirstOrDefault();
        }

        public static void Add( this SqlParameterCollection collection, FieldAttribute fieldAttribute, ParameterDirection direction = ParameterDirection.Input ) {

            collection.Add( $"@{fieldAttribute.FieldName}", fieldAttribute.DbType, fieldAttribute.Size ).Direction = direction;
        }

        public static void Add<T>( this SqlParameterCollection collection, Expression<Func<T, object>> expr, ParameterDirection direction = ParameterDirection.Input ) where T : class {

            Add( collection, GetFieldAttribute<T>( expr ), direction );
        }

        public static void AddWithPrefix( this SqlParameterCollection collection, string prefix, FieldAttribute fieldAttribute, ParameterDirection direction = ParameterDirection.Input ) {

            collection.Add( $"@{prefix}{fieldAttribute.FieldName}", fieldAttribute.DbType, fieldAttribute.Size ).Direction = direction;
        }

        public static void AddWithPrefix<T>( this SqlParameterCollection collection, Expression<Func<T, object>> expr, ParameterDirection direction = ParameterDirection.Input ) where T : class {

            AddWithPrefix( collection, typeof( T ).Name, GetFieldAttribute<T>( expr ), direction );
        }

        public static TResult Testc<TClass, TResult>( this SqlParameterCollection collection, Expression<Func<TClass, TResult>> expression ) {

            command.Parameters[ "@ID" ].Value,
            return default;
        }
    }
}