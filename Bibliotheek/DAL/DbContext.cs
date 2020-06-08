using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Bibliotheek.DAL {
    public class DbContext {

        private static readonly string DatabaseFileLocation = Path.Combine( Directory.GetCurrentDirectory(), @"App_Data\MainDatabase.mdf");
        private static readonly string ConnectionString = $@"
                            Data Source=(localdb)\MSSQLLocalDB; 
                            AttachDbFilename={ DatabaseFileLocation };
                            Integrated Security=True;
                            Connect Timeout=30";

        private SqlConnection Connection { get; }

        public DbContext() {

            Connection = new SqlConnection();
            Connection.ConnectionString = ConnectionString;

            Connection.Open();
        }
    }
}