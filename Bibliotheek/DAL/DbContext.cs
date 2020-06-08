using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.DynamicData;

namespace Bibliotheek.DAL {

    public class DbContext : IDisposable {

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

        private string GetTableName<T>() {

            var attribute = typeof(T).GetCustomAttributes( typeof(TableNameAttribute), false ).FirstOrDefault() as TableNameAttribute;
            return attribute?.Name;
        }

        public bool CreateMember( Member member ) {

            SqlCommand command = Connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CreateMember";

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

            // return value
            command.Parameters.Add( "@ID", SqlDbType.Int ).Direction = ParameterDirection.Output;

            Console.WriteLine( $"Execute '{command.CommandText}'." );

            try {

                command.ExecuteNonQuery();

                member.ID = (int)command.Parameters[ "@id" ].Value;
            } catch ( Exception exp ) {

                Console.WriteLine( "!!ERROR!!" );
                Console.WriteLine( exp.ToString() );

                return false;
            }

            return true;
        }

        public Member GetMember( int Id ) {

            string query = $"SELECT" + " " +
                $"Member.ID, Member.FirstName, Member.Affix, Member.LastName, Member.BirthDate, Member.EmailAddress, Member.Telephone, Member.Street, Member.Number, Member.NumberSuffix, Member.ZipCode, Member.Place, Member.AddressNote," + " " +
                $"Membership.ID, Membership.StartDate, Membership.EndDate" + " " +
                $"FROM {GetTableName<Member>()} Member" + " " +
                $"LEFT JOIN {GetTableName<Membership>()} Membership ON Membership.MemberID=Member.ID" + " " +
                $"WHERE" + " " +
                $"(@ID = Member.ID)";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue( "@ID", Id );

            Console.WriteLine( $"Execute '{command.CommandText}'." );

            using ( SqlDataReader reader = command.ExecuteReader() ) {
                // iterate your results here
                Console.WriteLine( String.Format( "{0}", reader[ "id" ] ) );
            }

            return null;
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

            Console.WriteLine( $"Execute '{command.CommandText}'." );

            try {

                membership.ID = (int)command.ExecuteScalar();
            } catch ( Exception exp ) {

                Console.WriteLine( "!!ERROR!!" );
                Console.WriteLine( exp.ToString() );

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