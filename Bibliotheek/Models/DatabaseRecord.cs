using System;
using System.Collections.Generic;

namespace Bibliotheek.Models {

    public abstract class DatabaseRecord {

        public int ID { get; set; }

        public override bool Equals( object obj ) {

            if ( !( obj is DatabaseRecord record ) ) {
                return false;
            }

            if ( record.GetType() != GetType() ) {
                return false;
            }

            return ID == record.ID;
        }

        public override int GetHashCode() {

            // Auto-generated
            var hashCode = -1719893075;

            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode( GetType() );

            return hashCode;
        }

        public static bool operator ==( DatabaseRecord A, DatabaseRecord B ) {

            if ( A is null ) {
                return B is null;
            }

            return A.Equals( B );
        }

        public static bool operator !=( DatabaseRecord A, DatabaseRecord B ) {

            return !( A == B );
        }
    }
}