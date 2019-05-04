using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLGym
{
    public partial class SiteMaster : MasterPage
    {
        public static UserEntity _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = GymPage.User();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Default");
        }
    }
}