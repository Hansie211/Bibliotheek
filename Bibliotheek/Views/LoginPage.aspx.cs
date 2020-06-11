using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheek.Views {

    public partial class LoginPage : System.Web.UI.Page {

        public readonly string timeNow = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds().ToString();

        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void OnSubmit( object sender, EventArgs e ) {

            string cardNumber = boxCardnumber.Text;
            cardNumber = Regex.Replace()

            // boxUsername.Text = "LOL!";
        }
    }
}