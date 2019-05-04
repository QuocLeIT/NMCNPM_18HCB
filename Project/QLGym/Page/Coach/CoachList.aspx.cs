using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLGym.Coach
{
    public partial class CoachList : GymPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }
        void loadData()
        {
            var lstCoach = UserService.GetAll();
            rpCoachList.DataSource = lstCoach;
            rpCoachList.DataBind();
            Pager.BingPaging(3);
        }

        protected void Pager_ButtonClick(object sender, EventArgs e)
        {
            int page = Pager.PageIndex;
        }
    }
}