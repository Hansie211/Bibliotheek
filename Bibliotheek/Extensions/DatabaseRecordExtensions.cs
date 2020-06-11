using Bibliotheek.Attributes;
using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace Bibliotheek.Extensions {

    public static class DatabaseRecordExtensions {

        private static FieldAttribute GetFieldAttribute( PropertyInfo prop ) {

            IEnumerable<FieldAttribute> attrs = prop.GetCustomAttributes<FieldAttribute>( true );
            return attrs.FirstOrDefault();
        }

        private static string GetTableName( Type type ) {

            var attribute = type.GetCustomAttributes( typeof(TableNameAttribute), false ).FirstOrDefault() as TableNameAttribute;
            return attribute?.Name;
        }

        private static string GetTableName<T>() {

            return GetTableName( typeof( T ) );
        }

        private static string GetParameterName( string TypeName, string fieldName ) {

            return $"@{ TypeName }{ fieldName }";
        }

        private static string GetParameterName( string TypeName, FieldAttribute attribute ) {

            if ( attribute is ShadowFieldAttribute ) {

                return $"@{ attribute.FieldName }";
            }

            return GetParameterName( TypeName, attribute.FieldName );
        }

        private static PropertyInfo[] GetProperties( Type type ) {

            return type.GetProperties( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance );
        }

        private static PropertyInfo[] GetProperties<T>() {

            return GetProperties( typeof( T ) );
        }

        private static IEnumerable<FieldAttribute> GetFieldAttributes( Type type, bool includeID = false ) {

            var properties = GetProperties( type );
            foreach ( var prop in properties ) {

                FieldAttribute attribute = GetFieldAttribute( prop );
                if ( attribute == null ) {
                    continue;
                }

                if ( !includeID && attribute.FieldName == "ID" ) {
                    continue;
                }

                yield return attribute;
            }

            var shadowAttributes = type.GetCustomAttributes( typeof(ShadowFieldAttribute), false ).Cast<ShadowFieldAttribute>();
            foreach ( var shadowAttribute in shadowAttributes ) {

                yield return shadowAttribute;
            }
        }

        private static IEnumerable<FieldAttribute> GetFieldAttributes<T>() {

            return GetFieldAttributes( typeof( T ) );
        }

        public static string CreateInsertProcedure<T>() {

            string TypeName     = typeof(T).Name;
            string TableName    = GetTableName<T>();

            var attributes      = GetFieldAttributes<T>();

            StringBuilder command = new StringBuilder();

            command.AppendLine( $"CREATE OR ALTER PROCEDURE Create{ TypeName }" );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) } { attribute.DbType.ToString().ToLower() }" );
                if ( attribute.DbType == SqlDbType.VarChar ) {
                    command.Append( $"({ attribute.Size })" );
                }
                command.Append( ", " );
            }

            command.AppendLine( $"@{ TypeName }ID int OUTPUT" );
            command.AppendLine( "AS" );

            command.Append( $"INSERT INTO { TableName } ( " );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ attribute.FieldName }, " );
            }

            command.Length -= 2;
            command.AppendLine( " )" );
            command.Append( "VALUES ( " );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) }, " );
            }

            command.Length -= 2;
            command.AppendLine( ")" );

            command.AppendLine( $"SET { GetParameterName( TypeName, "ID" ) } = SCOPE_IDENTITY()" );
            command.AppendLine( $"RETURN  { GetParameterName( TypeName, "ID" ) }" );
            command.AppendLine( "GO" );

            return command.ToString();
        }

        public static string CreateUpdateProcedure<T>() {

            string TypeName     = typeof(T).Name;
            string TableName    = GetTableName<T>();

            var attributes      = GetFieldAttributes<T>();

            StringBuilder command = new StringBuilder();

            command.AppendLine( $"CREATE OR ALTER PROCEDURE Update{ TypeName }" );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) } { attribute.DbType.ToString().ToLower() }" );
                if ( attribute.DbType == SqlDbType.VarChar ) {
                    command.Append( $"({ attribute.Size })" );
                }
                command.Append( ", " );
            }

            command.AppendLine( $"{ GetParameterName( TypeName, "ID" ) } int" );
            command.AppendLine( "AS" );

            command.AppendLine( $"UPDATE { TableName } SET" );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ attribute.FieldName } = { GetParameterName( TypeName, attribute ) }, " );
            }

            command.Length -= 2;
            command.AppendLine( "" );
            command.AppendLine( $"WHERE ID = { GetParameterName( TypeName, "ID" ) }" );
            command.AppendLine( "GO" );

            return command.ToString();
        }

        public static string CreateGetProcedure<T>() {

            string TypeName     = typeof(T).Name;
            string TableName    = GetTableName<T>();

            var attributes      = GetFieldAttributes<T>();

            StringBuilder command = new StringBuilder();

            command.AppendLine( $"CREATE OR ALTER PROCEDURE Get{ TypeName }" );
            command.Append( $"{ GetParameterName( TypeName, "ID" ) } int, " );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) } { attribute.DbType.ToString().ToLower() }" );
                if ( attribute.DbType == SqlDbType.VarChar ) {
                    command.Append( $"({ attribute.Size })" );
                }
                command.Append( " OUTPUT, " );
            }

            command.Length -= 2;
            command.AppendLine( "" );
            command.AppendLine( "AS" );

            command.AppendLine( "SELECT TOP 1" );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) } = { TableName }.{ attribute.FieldName }, " );
            }

            command.Length -= 2;
            command.AppendLine( "" );

            command.AppendLine( $"FROM { TableName }" );
            command.AppendLine( "WHERE" );
            command.AppendLine( $"({GetParameterName( TypeName, "ID" ) } = { TableName }.ID)" );
            command.AppendLine( "GO" );

            return command.ToString();
        }

        public static string CreateGetAllProcedure<T>() {

            string TypeName     = typeof(T).Name;
            string TableName    = GetTableName<T>();

            var attributes      = GetFieldAttributes<T>();
            StringBuilder command = new StringBuilder();

            command.AppendLine( $"CREATE OR ALTER PROCEDURE GetAll{ TypeName }" );
            command.Append( $"{ GetParameterName( TypeName, "ID" ) } int OUTPUT, " );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) } { attribute.DbType.ToString().ToLower() }" );
                if ( attribute.DbType == SqlDbType.VarChar ) {
                    command.Append( $"({ attribute.Size })" );
                }
                command.Append( " OUTPUT, " );
            }

            command.Length -= 2;
            command.AppendLine( "" );
            command.AppendLine( "AS" );

            command.AppendLine( "SELECT" );

            command.Append( $"{ GetParameterName( TypeName, "ID" ) } = { TableName }.ID, " );

            foreach ( var attribute in attributes ) {

                command.Append( $"{ GetParameterName( TypeName, attribute ) } = { TableName }.{ attribute.FieldName }, " );
            }

            command.Length -= 2;
            command.AppendLine( "" );

            command.AppendLine( $"FROM { TableName }" );
            command.AppendLine( "GO" );

            return command.ToString();
        }

        public static string CreateDeleteProcedure<T>() {

            string TypeName     = typeof(T).Name;
            string TableName    = GetTableName<T>();

            StringBuilder command = new StringBuilder();

            command.AppendLine( $"CREATE OR ALTER PROCEDURE Delete{ TypeName }" );
            command.AppendLine( $"{ GetParameterName( TypeName, "ID" ) } int" );

            command.AppendLine( "AS" );

            command.AppendLine( "DELETE" );
            command.AppendLine( $"FROM { TableName }" );
            command.AppendLine( $"WHERE" );
            command.AppendLine( $"{ GetParameterName( TypeName, "ID" ) } = ID" );
            command.AppendLine( $"GO" );

            return command.ToString();
        }

        public static string GetAllProcedures<T>() {

            StringBuilder commands = new StringBuilder();

            commands.AppendLine( CreateInsertProcedure<T>() );
            commands.AppendLine( CreateGetProcedure<T>() );
            commands.AppendLine( CreateGetAllProcedure<T>() );
            commands.AppendLine( CreateUpdateProcedure<T>() );
            commands.AppendLine( CreateDeleteProcedure<T>() );

            return commands.ToString();
        }
    }
}
