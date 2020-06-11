﻿using Bibliotheek.Attributes;
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

        private static FieldAttribute GetFieldAttribute( PropertyInfo prop ) {

            IEnumerable<FieldAttribute> attrs = prop.GetCustomAttributes<FieldAttribute>( true );
            return attrs.FirstOrDefault();
        }

        private static FieldAttribute GetFieldAttribute<T>( Expression<Func<T, object>> expr ) {

            return GetFieldAttribute( GetPropertyInfo( expr ) );
        }

        private static string GetParameterName<T>( string fieldName ) {

            return $"@{ typeof( T ).Name }{ fieldName }";
        }

        public static SqlParameter Add<TClass>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expr, ParameterDirection direction = ParameterDirection.Input ) where TClass : class {

            FieldAttribute attribute = GetFieldAttribute( expr );

            var param = collection.Add( GetParameterName<TClass>( attribute.FieldName ), attribute.DbType, attribute.Size );
            param.Direction = direction;

            return param;
        }

        public static SqlParameter AddWithValue<TClass>( this SqlParameterCollection collection, TClass obj, Expression<Func<TClass, object>> expr, ParameterDirection direction = ParameterDirection.Input ) where TClass : class {

            PropertyInfo prop           = GetPropertyInfo( expr );
            FieldAttribute attribute    = GetFieldAttribute( prop );

            object value = prop.GetValue( obj );

            var param = collection.Add( GetParameterName<TClass>( attribute.FieldName ), attribute.DbType, attribute.Size );
            param.Direction = direction;
            param.Value = value;

            return param;
        }

        public static void StoreReturnValue<TClass>( this SqlParameterCollection collection, TClass obj, Expression<Func<TClass, object>> expression ) {

            object value            = GetReturnValue<TClass, object>( collection, expression );
            PropertyInfo property   = GetPropertyInfo( expression );

            property.SetValue( obj, value );
        }

        public static TResult GetReturnValue<TClass, TResult>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expression ) {

            FieldAttribute attribute = GetFieldAttribute( expression );
            return (TResult)collection[ GetParameterName<TClass>( attribute.FieldName ) ].Value;
        }

        public static bool HasReturnValue<TClass>( this SqlParameterCollection collection, Expression<Func<TClass, object>> expression ) {

            FieldAttribute attribute = GetFieldAttribute( expression );
            return !( collection[ GetParameterName<TClass>( attribute.FieldName ) ].Value  is DBNull );
        }

    }
}