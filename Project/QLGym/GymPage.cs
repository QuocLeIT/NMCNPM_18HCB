using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace QLGym
{
    public class GymPage : System.Web.UI.Page
    {
        
        public static UserEntity _user;

        protected override void OnInit(EventArgs e)
        {
            CheckLogin();
        }

        public static UserEntity User()
        {
            return _user;
        }

        public void CheckLogin()
        {
            if(Session["User"] != null)
            {
                _user = (UserEntity)Session["User"];
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

        public void Alert(string message)
        {
            String alert = "<script>alert('" + message + "')</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert_" + DateTime.Now.Ticks, alert, false);
        }
    }
}