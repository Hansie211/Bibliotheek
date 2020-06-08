using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace Bibliotheek.Interfaces {
    public interface IPerson {

        string FirstName { get; set; }
        string Affix { get; set; }
        string LastName { get; set; }
    }

    public static class PersonExtensions {

        public static string GetFullName( this IPerson person ) {

            StringBuilder fullName = new StringBuilder( person.FirstName );
            if ( person.Affix != null ) {
                fullName.Append( $" {person.Affix}" );
            }

            fullName.Append( $" {person.LastName}" );

            return fullName.ToString();
        }
    }
}