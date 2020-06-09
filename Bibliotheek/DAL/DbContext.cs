﻿using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.DAL {

    public partial class DbContext : IDisposable {

        private static readonly string AssemblyDirectory    = Path.GetDirectoryName( new Uri( Assembly.GetExecutingAssembly().CodeBase ).LocalPath );
        private static readonly string DatabaseFileLocation = Path.GetFullPath( Path.Combine( AssemblyDirectory, @"..\App_Data\MainDatabase.mdf") );
        private static readonly string ConnectionString = $@"
                            Data Source=(localdb)\MSSQLLocalDB; 
                            AttachDbFilename={ DatabaseFileLocation };
                            Integrated Security=True;
                            Connect Timeout=30";

        public SqlConnection Connection { get; }

        public DbContext() {

            Connection = new SqlConnection {
                ConnectionString = ConnectionString,
            };

            Connection.Open();
        }

        private static string GetTableName<T>() {

            var attribute = typeof(T).GetCustomAttributes( typeof(TableNameAttribute), false ).FirstOrDefault() as TableNameAttribute;
            return attribute?.Name;
        }

        private static void GetAttr<T>( Expression<Func<T>> expr ) {

            var propertyInfo = ((MemberExpression)expr.Body).Member as PropertyInfo;

            // return null;
        }

        public bool CreateMember( Member member ) {

            // Create the command
            SqlCommand command = Connection.CreateCommand();

            // Set the command properties
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CreateMember";

            GetAttr<Member>( o => o.AddressNote );

            // Add the parameters
            command.Parameters.AddWithValue( o => o.FirstName );
            command.Parameters.AddWithValue( "@Affix", member.Affix );
            command.Parameters.AddWithValue( "@LastName", member.LastName );
            command.Parameters.AddWithValue( "@BirthDate", member.BirthDate );
            command.Parameters.AddWithValue( "@EmailAddress", member.EmailAddress );
            command.Parameters.AddWithValue( "@Telephone", member.Telephone );
            command.Parameters.AddWithValue( "@Street", member.Street );
            command.Parameters.AddWithValue( "@Number", member.Number );
            command.Parameters.AddWithValue( "@NumberSuffix", member.NumberSuffix );
            command.Parameters.AddWithValue( "@ZipCode", member.ZipCode );
            command.Parameters.AddWithValue( "@Place", member.Place );
            command.Parameters.AddWithValue( "@AddressNote", member.AddressNote );

            // Add the return value
            command.Parameters.Add( "@ID", SqlDbType.Int ).Direction = ParameterDirection.Output;

            Debug.WriteLine( $"Execute '{command.CommandText}'." );

            try {

                command.ExecuteNonQuery();
                member.ID = (int)command.Parameters[ "@id" ].Value;
            } catch ( Exception exp ) {

                Debug.WriteLine( "!!ERROR!!" );
                Debug.WriteLine( exp.ToString() );

                return false;
            }

            return true;
        }

        public Member GetMember( int Id ) {

            // Without join:
            // $"FROM {GetTableName<Member>()} as Member," + " " +
            // $"{GetTableName<Membership>()} as Membership" + " " +
            // $"WHERE" + " " +
            // $"(@ID = Member.ID) AND (Membership.MemberID = Member.ID)"
            //

            //string query = $"SELECT TOP 1" + " " +
            //    $"Member.ID, Member.FirstName, Member.Affix, Member.LastName, Member.BirthDate, Member.EmailAddress, Member.Telephone, Member.Street, Member.Number, Member.NumberSuffix, Member.ZipCode, Member.Place, Member.AddressNote," + " " +
            //    $"Membership.ID as MembershipID, Membership.StartDate as MembershipStartDate, Membership.EndDate as MembershipEndDate" + " " +
            //    $"FROM {GetTableName<Member>()} as Member" + " " +
            //    $"LEFT JOIN {GetTableName<Membership>()} as Membership ON Membership.MemberID = Member.ID" + " " +
            //    $"WHERE" + " " +
            //    $"(@ID = Member.ID)"
            //    ;

            SqlCommand command = Connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetMember";

            command.Parameters.AddWithValue( "@ID", Id );

            command.Parameters.Add( "@FirstName", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@Affix", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@LastName", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@BirthDate", SqlDbType.Date ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@EmailAddress", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@Telephone", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@Street", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@Number", SqlDbType.Int ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@NumberSuffix", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@ZipCode", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@Place", SqlDbType.VarChar, 255 ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@AddressNote", SqlDbType.VarChar, 1023 ).Direction = ParameterDirection.Output;

            command.Parameters.Add( "@MembershipID", SqlDbType.Int ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@MembershipStartDate", SqlDbType.Date ).Direction = ParameterDirection.Output;
            command.Parameters.Add( "@MembershipEndDate", SqlDbType.Date ).Direction = ParameterDirection.Output;

            Debug.WriteLine( $"Execute '{command.CommandText}'." );

            command.ExecuteNonQuery();

            Member member = new Member(){
                ID              = (int)command.Parameters[ "@ID" ].Value,
                FirstName       = (string)command.Parameters[ "@FirstName" ].Value,
                Affix           = (string)command.Parameters[ "@Affix" ].Value,
                LastName        = (string)command.Parameters[ "@LastName" ].Value,
                BirthDate       = (DateTime)command.Parameters[ "@BirthDate" ].Value,
                EmailAddress    = (string)command.Parameters[ "@EmailAddress" ].Value,
                Telephone       = (string)command.Parameters[ "@Telephone" ].Value,
                Street          = (string)command.Parameters[ "@Street" ].Value,
                Number          = (int)command.Parameters[ "@Number" ].Value,
                NumberSuffix    = (string)command.Parameters[ "@NumberSuffix" ].Value,
                ZipCode         = (string)command.Parameters[ "@ZipCode" ].Value,
                Place           = (string)command.Parameters[ "@Place" ].Value,
                AddressNote     = (string)command.Parameters[ "@AddressNote" ].Value,
            };

            return member;
        }

        // public bool UpdateMember()

        public bool CreateMembership( Member owner, Membership membership ) {

            string query = $"INSERT INTO { GetTableName<Membership>() }" +
                $"( StartDate, EndDate, MemberID )" + " " +
                $"output INSERTED.ID" + " " +
                $"VALUES" + " " +
                $"( @StartDate, @EndDate, @MemberID )";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue( "@StartDate", membership.StartDate );
            command.Parameters.AddWithValue( "@EndDate", membership.EndDate );
            command.Parameters.AddWithValue( "@MemberID", owner.ID );

            Debug.WriteLine( $"Execute '{command.CommandText}'." );

            try {

                membership.ID = (int)command.ExecuteScalar();
            } catch ( Exception exp ) {

                Debug.WriteLine( "!!ERROR!!" );
                Debug.WriteLine( exp.ToString() );

                return false;
            }

            owner.Membership = membership;

            return true;
        }

        public void Dispose() {

            Connection.Dispose();
        }
    }
}