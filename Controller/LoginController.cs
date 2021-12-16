using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootbalManager.Controller
{
    public class LoginController
    {
        Models.LoginDao loginDAO = new Models.LoginDao();
        public Entities.Accout Login(string account, string password)
        {
            if(account.Trim().Equals("") || password.Trim().Equals(""))
            {
                return null;
            } else
            {
                Entities.Accout acc = loginDAO.Login(account, password);
                return acc;
            }
        }
    }
}
