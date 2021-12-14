using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootbalManager.Entities
{
    public class Accout
    {
        public string Account { get; set; }
        public string Password { get; set; }

        public Accout(string account, string password)
        {
            Account = account;
            Password = password;
        }

    }
}