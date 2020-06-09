using Bibliotheek.Attributes;
using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;

namespace Bibliotheek.Extensions {

    public static class DatabaseRecordExtensions {

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

        public static string CreateInsertProcedure<T>() {

            string TypeName = typeof(T).Name;
            var properties  = typeof(T).GetProperties();

            StringBuilder command = new StringBuilder();

            command.AppendLine( $"CREATE PROCEDURE Create{ TypeName }" );

            foreach ( var prop in properties ) {

                FieldAttribute attribute = GetFieldAttribute( prop );
                if ( attribute == null ) {
                    continue;
                }

                if ( attribute.FieldName == "ID" ) {
                    continue;
                }

                command.Append( $"@{ TypeName }{ attribute.FieldName } { attribute.DbType.ToString().ToLower() }({ attribute.Size }), " );
            }

            command.AppendLine( $"@{ TypeName }ID int OUTPUT" );
            command.AppendLine( "AS" );

            command.Append( $"INSERT INTO {TypeName}s (" );

            foreach ( var prop in properties ) {

                FieldAttribute attribute = GetFieldAttribute( prop );
                if ( attribute == null ) {
                    continue;
                }

                if ( attribute.FieldName == "ID" ) {
                    continue;
                }

                command.Append( $"{ attribute.FieldName }, " );
            }

            command.AppendLine( ")" );
            command.Append( "VALUES ( " );

            foreach ( var prop in properties ) {

                FieldAttribute attribute = GetFieldAttribute( prop );
                if ( attribute == null ) {
                    continue;
                }

                if ( attribute.FieldName == "ID" ) {
                    continue;
                }

                command.Append( $"@{ TypeName }{ attribute.FieldName }, " );
            }
            command.AppendLine( ")" );

            command.AppendLine( $"SET @{ TypeName }ID = SCOPE_IDENTITY()" );
            command.AppendLine( $"RETURN  @{ TypeName }ID" );
            command.AppendLine( "GO" );

            return command.ToString();

            /*
            CREATE PROCEDURE CreateMember 
            @MemberFirstName varchar(255), @MemberAffix varchar(255), @MemberLastName varchar(255), @MemberBirthDate date, @MemberEmailAddress varchar(255), @MemberTelephone varchar(255), @MemberStreet varchar(255), 
            @MemberNumber int, @MemberNumberSuffix varchar(255), @MemberZipCode char(6), @MemberPlace varchar(255), @MemberAddressNote varchar(1023), @MemberID int OUTPUT
            AS
            INSERT INTO Members ( FirstName, Affix, LastName, BirthDate, EmailAddress, Telephone, Street, Number, NumberSuffix, ZipCode, Place, AddressNote )
            VALUES ( @MemberFirstName, @MemberAffix, @MemberLastName, @MemberBirthDate, @MemberEmailAddress, @MemberTelephone, @MemberStreet, @MemberNumber, @MemberNumberSuffix, @MemberZipCode, @MemberPlace, @MemberAddressNote )
            SET @MemberID = SCOPE_IDENTITY()
            RETURN  @MemberID
            GO
            */
            return null;
        }
    }
}
