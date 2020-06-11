using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek.Interfaces {

    public interface IPasswordHolder {

        string PasswordHash { get; set; }
        byte[] PasswordSalt { get; set; }
    }
}
