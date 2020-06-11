using Bibliotheek.DAL;
using Bibliotheek.Extensions;
using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheek {

    public partial class HomePage : System.Web.UI.Page {

        protected void Page_Load( object sender, EventArgs e ) {


            using ( DbContext context = new DbContext() ) {

                var member = new Member() {
                    AddressNote = string.Empty,
                    Affix = string.Empty,
                    BirthDate = DateTime.Now.AddYears( -20 ),
                    EmailAddress = "example@example.com",
                    FirstName = "John",
                    LastName = "Doe",
                    // Membership = null,
                    Number = 10,
                    NumberSuffix = string.Empty,
                    Place = "Amsterdam",
                    Street = "Hoofdstraat",
                    Telephone = "+33123458",
                    ZipCode = "1111AA",
                };

                var membership = new Membership() {
                    EndDate = DateTime.Now.AddYears( 1 ),
                    StartDate = DateTime.Now,
                };

                StringBuilder commands = new StringBuilder();

                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Author>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Book>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Edition>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Employee>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Fine>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Genre>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Language>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Library>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Member>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Membership>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Publisher>() );
                commands.AppendLine( DatabaseRecordExtensions.GetAllProcedures<Reservation>() );

                string fileName = "StoredProcedures.sql";
                string filePath = Path.Combine( @"X:\Bibliotheek\Queries", fileName);

                File.WriteAllText( filePath, commands.ToString() );

                // context.CreateMember( member );
                //context.CreateMembership( member, membership );

                //var x = DbContext.GetFieldAttribute<Member>( o => o.AddressNote );

                //var a = context.GetMember( 1 );
                //var b = context.GetMember( 2 );
            }
        }
    }
}