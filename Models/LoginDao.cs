using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FootbalManager.Models
{
    public class LoginDao
    {
        DataProvider dp = new DataProvider();

        public Entities.Accout Login(string account, string password)
        {
            string sql = "Select * from Account where account='"+account+"' and password='"+password+"'";
            DataTable dt = dp.executeQuery(sql);
            if(dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                Entities.Accout acc = new Entities.Accout(r["account"].ToString(), r["password"].ToString());
                return acc;
            } else
            {
                return null;
            }
        }
    }
}