using Bibliotheek.DAL;
using Bibliotheek.Extensions;
using Bibliotheek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheek.Views.Admin {

    public partial class CreateUser : System.Web.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void OnSubmit( object sender, EventArgs e ) {

            Member member = new Member(){

                FirstName = boxFirstName.Text,
                Affix = boxAffix.Text,
                LastName = boxLastName.Text,
                BirthDate = DateTime.Parse( boxBirthDate.Text ),
                EmailAddress = boxEmailAddress.Text,
                Telephone = boxTelephone.Text,
                Street = boxStreet.Text,
                Number = int.Parse( boxNumber.Text ),
                NumberSuffix = boxNumberSuffix.Text,
                ZipCode = boxZipCode.Text,
                Place = boxPlace.Text,
                AddressNote = boxAddressNote.Text,
            };

            member.SetPassword( "RANDOM" );

            DbContext dbContext = new DbContext();
            dbContext.CreateMember( member );

            // boxUsername.Text = "LOL!";
        }
    }
}