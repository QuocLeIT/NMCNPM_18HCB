using Core.Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Provider;

namespace QLGym
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var listCoach = CoachService.GetAll();
            //var lstCoach = CoachService.GetList(null);
            //var dtCoach = CoachService.GetDataTable(null);
            //var dsCoach = CoachService.GetDataSet(null);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                Alert("Please Enter Username");
                return;
            }
            string Username = txtUsername.Text;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                Alert("Plase Enter Password");
                return;
            }

            string Password = txtPassword.Text.ToMD5();
            UserEntity User;
            try
            {
                User = UserService.GetByUsername(Username);
            }
            catch (Exception ex)
            {
                User = UserService.GetByUsername(Username, Password);
            }     
             
            if(User == null)
            {
                Alert("Username not exist");
                return;
            }

            if (User.ID < 1)
            {
                Alert("Login fail");
                return;
            }

            if(Password != User.Pass)
            {
                Alert("Ivalid Password");
            }
            else
            {
                Session["User"] = User;
                Response.Redirect("/Page/Coach/CoachList.aspx");
            }
        }
        public void Alert(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}