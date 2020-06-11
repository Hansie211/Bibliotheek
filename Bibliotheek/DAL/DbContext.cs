using Bibliotheek.Attributes;
using Bibliotheek.Models;
using Bibliotheek.Extensions;
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

        public static FieldAttribute GetFieldAttribute<T>( Expression<Func<T, object>> expr ) {

            var prop = ((MemberExpression)expr.Body).Member as PropertyInfo;
            IEnumerable<FieldAttribute> attrs = prop.GetCustomAttributes<FieldAttribute>( true );

            return attrs.FirstOrDefault();
        }

        public bool CreateMember( Member member ) {

            // Create the command
            SqlCommand command = Connection.CreateCommand();

            // Set the command properties
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CreateMember";

            GetFieldAttribute<Member>( o => o.AddressNote );

            // Add the parameters
            command.Parameters.AddWithValue( "@FirstName", member.FirstName );
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

            SqlCommand command = Connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetMember";

            command.Parameters.AddWithValue( "@ID", Id );

            command.Parameters.Add<Member>( o => o.FirstName, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.Affix, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.LastName, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.BirthDate, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.EmailAddress, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.Telephone, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.Street, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.Number, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.NumberSuffix, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.ZipCode, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.Place, ParameterDirection.Output );
            command.Parameters.Add<Member>( o => o.AddressNote, ParameterDirection.Output );

            command.Parameters.Add<Membership>( o => o.ID, ParameterDirection.Output );
            command.Parameters.Add<Membership>( o => o.StartDate, ParameterDirection.Output );
            command.Parameters.Add<Membership>( o => o.EndDate, ParameterDirection.Output );

            Debug.WriteLine( $"Execute '{command.CommandText}'." );

            command.ExecuteNonQuery();

            Member member = new Member();
            command.Parameters.StoreReturnValue( member, o => o.ID );
            command.Parameters.StoreReturnValue( member, o => o.FirstName );
            command.Parameters.StoreReturnValue( member, o => o.LastName );
            command.Parameters.StoreReturnValue( member, o => o.BirthDate );
            command.Parameters.StoreReturnValue( member, o => o.EmailAddress );
            command.Parameters.StoreReturnValue( member, o => o.Telephone );
            command.Parameters.StoreReturnValue( member, o => o.Street );
            command.Parameters.StoreReturnValue( member, o => o.Number );
            command.Parameters.StoreReturnValue( member, o => o.NumberSuffix );
            command.Parameters.StoreReturnValue( member, o => o.ZipCode );
            command.Parameters.StoreReturnValue( member, o => o.Place );
            command.Parameters.StoreReturnValue( member, o => o.AddressNote );

            //if ( command.Parameters.HasReturnValue<Membership>( o => o.ID ) ) {

            //    member.Membership = new Membership();
            //    command.Parameters.StoreReturnValue( member.Membership, o => o.ID );
            //    command.Parameters.StoreReturnValue( member.Membership, o => o.StartDate );
            //    command.Parameters.StoreReturnValue( member.Membership, o => o.EndDate );
            //}

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
            command.Parameters.Add<Membership>( o => o.StartDate );
            command.Parameters.Add<Membership>( o => o.EndDate );
            command.Parameters.AddWithValue( "@MemberID", owner.ID );

            Debug.WriteLine( $"Execute '{command.CommandText}'." );

            try {

                membership.ID = (int)command.ExecuteScalar();
            } catch ( Exception exp ) {

                Debug.WriteLine( "!!ERROR!!" );
                Debug.WriteLine( exp.ToString() );

                return false;
            }

            // owner.Membership = membership;

            return true;
        }

        public void Dispose() {

            Connection.Dispose();
        }
    }
}