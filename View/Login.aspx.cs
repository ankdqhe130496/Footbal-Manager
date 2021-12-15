using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootbalManager.View
{
    public partial class Login : System.Web.UI.Page
    {
        Controller.LoginController loginCon = new Controller.LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserId.Text.Equals(""))
            {
                txtUserId.BackColor = Color.Red;
            }
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.BackColor = Color.Red;
            }
            Entities.Accout acc = loginCon.Login(txtUserId.Text, txtPassword.Text);
            if(acc == null)
            {
                Response.Write("<script>alert('Accout or Password wrong')</script>");
            } else
            {
                Response.Write("<script>alert('Login successful')</script>");
                Response.Redirect("");
            }
        }

        protected void txtUserId_TextChanged(object sender, EventArgs e)
        {
            txtUserId.BackColor = Color.White;
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }
    }
}