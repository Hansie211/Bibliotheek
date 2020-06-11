using Bibliotheek.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Bibliotheek.Extensions {
    public static class PasswordExtensions {

        private static RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();

        public static string ToHexStr( byte[] data ) {

            StringBuilder builder = new StringBuilder();
            for ( int i = 0; i < data.Length; i++ ) {
                builder.Append( data[ i ].ToString( "X2" ) );
            }

            return builder.ToString();
        }

        private static string GetPasswordHash( byte[] salt, string text ) {

            byte[] passwordBytes    = Encoding.UTF8.GetBytes( text );
            byte[] passwordData     = salt.Concat(passwordBytes).ToArray();

            using ( SHA256 hashAlgo = SHA256.Create() ) {

                byte[] hash = hashAlgo.ComputeHash( passwordData );
                return ToHexStr( hash );
            }
        }

        public static void SetPassword( this IPasswordHolder holder, string text ) {

            var salt = new byte[32];
            RNG.GetBytes( salt );

            holder.PasswordSalt = salt;
            holder.PasswordHash = GetPasswordHash( salt, text );
        }

        public static bool ComparePassword( this IPasswordHolder holder, string text ) {

            string textHash = GetPasswordHash( holder.PasswordSalt, text );
            return textHash == holder.PasswordHash;
        }
    }
}