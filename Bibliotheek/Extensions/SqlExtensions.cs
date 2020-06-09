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

        private static PropertyInfo GetPropertyInfo<T>( Expression<Func<T, object>> expr ) {

            if ( expr.Body is MemberExpression expression ) {

                return expression.Member as PropertyInfo;
            }

            var memberExpression = ( (UnaryExpression)expr.Body ).Operand as MemberExpression;
            return memberExpression.Member as PropertyInfo;
        }

        private static FieldAttribute GetFieldAttribute<T>( PropertyInfo prop ) {

            IEnumerable<FieldAttribute> attrs = prop.GetCustomAttributes<FieldAttribute>( true );
            return attrs.FirstOrDefault();
        }

        private static FieldAttribute GetFieldAttribute<T>( Expression<Func<T, object>> expr ) {

            return GetFieldAttribute<T>( GetPropertyInfo( expr ) );
        }

        public static void Add( this SqlParameterCollection collection, FieldAttribute fieldAttribute, ParameterDirection direction = ParameterDirection.Input ) {

            collection.Add( $"@{fieldAttribute.FieldName}", fieldAttribute.DbType, fieldAttribute.Size ).Direction = direction;
        }

        public static void Add<TClass>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expr, ParameterDirection direction = ParameterDirection.Input ) where TClass : class {

            Add( collection, GetFieldAttribute( expr ), direction );
        }

        public static void AddWithPrefix( this SqlParameterCollection collection, string prefix, FieldAttribute fieldAttribute, ParameterDirection direction = ParameterDirection.Input ) {

            collection.Add( $"@{prefix}{fieldAttribute.FieldName}", fieldAttribute.DbType, fieldAttribute.Size ).Direction = direction;
        }

        public static void AddWithPrefix<TClass>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expr, ParameterDirection direction = ParameterDirection.Input ) where TClass : class {

            AddWithPrefix( collection, typeof( TClass ).Name, GetFieldAttribute( expr ), direction );
        }

        public static void StoreReturnValue<TClass>( this SqlParameterCollection collection, TClass obj, Expression<Func<TClass, object>> expression ) {

            object value            = GetReturnValue<TClass, object>( collection, expression );
            PropertyInfo property   = GetPropertyInfo( expression );

            property.SetValue( obj, value );
        }

        public static TResult GetReturnValue<TClass, TResult>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expression ) {

            FieldAttribute attribute = GetFieldAttribute( expression );
            return (TResult)collection[ $"@{ attribute.FieldName }" ].Value;
        }

        public static void StoreReturnValueWithPrefix<TClass>( this SqlParameterCollection collection, TClass obj, Expression<Func<TClass, object>> expression ) {

            object value            = GetReturnValueWithPrefix<TClass, object>( collection, expression );
            PropertyInfo property   = GetPropertyInfo( expression );

            property.SetValue( obj, value );
        }

        public static TResult GetReturnValueWithPrefix<TClass, TResult>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expression ) {

            FieldAttribute attribute = GetFieldAttribute( expression );
            return (TResult)collection[ $"@{ typeof( TClass ).Name }{ attribute.FieldName }" ].Value;
        }

        public static bool HasReturnValue<TClass>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expression ) {

            FieldAttribute attribute = GetFieldAttribute( expression );
            return !( collection[ $"@{ attribute.FieldName }" ].Value  is DBNull );
        }

        public static bool HasReturnValueWithPrefix<TClass>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expression ) {

            FieldAttribute attribute = GetFieldAttribute( expression );
            return !( collection[ $"@{ typeof( TClass ).Name }{ attribute.FieldName }" ].Value  is DBNull );
        }
    }
}