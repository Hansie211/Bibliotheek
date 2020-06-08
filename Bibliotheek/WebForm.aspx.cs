using Bibliotheek.DAL;
using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheek {

    public partial class WebForm : System.Web.UI.Page {

        protected void Page_Load( object sender, EventArgs e ) {


            using ( DbContext context = new DbContext() ) {

                //var member = new Member() {
                //    ID = 3,
                //    AddressNote = string.Empty,
                //    Affix = string.Empty,
                //    BirthDate = DateTime.Now.AddYears( -20 ),
                //    EmailAddress = "example@example.com",
                //    FirstName = "John",
                //    LastName = "Doe",
                //    Membership = null,
                //    Number = 10,
                //    NumberSuffix = string.Empty,
                //    Place = "Amsterdam",
                //    Street = "Hoofdstraat",
                //    Telephone = "+33123458",
                //    ZipCode = "1111AA",
                //};

                //var membership = new Membership() {
                //    EndDate = DateTime.Now.AddYears( 1 ),
                //    StartDate = DateTime.Now,
                //};

                //context.CreateMember( member );
                //context.CreateMembership( member, membership );

                context.GetMember( 3 );
            }
        }
    }
}