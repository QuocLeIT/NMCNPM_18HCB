using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLGym.UIControl
{
    public partial class Pager : System.Web.UI.UserControl
    {
        public event EventHandler ButtonClick;

        public int TotalPage { get; set; }
        public int PageIndex { get; set; }
        public class Paging
        {
            public string PageIndex { get; set; }
            public bool isActive { get; set; }
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    load();
        //}

        public void BingPaging(int totalPage)
        {
            TotalPage = totalPage;

            List<Paging> paging = new List<Paging>();
            for (int i = 1; i <= TotalPage; i++)
            {
                paging.Add(new Paging { PageIndex = i.ToString(), isActive = false });
            }
            paging[0].isActive = true;
            paging.Insert(0, new Paging { PageIndex = "&laquo;", isActive = false });
            paging.Add(new Paging { PageIndex = "&raquo;", isActive = false });
            rpPager.DataSource = paging;
            rpPager.DataBind();
        }

        protected void lnkPageIndex_Click(object sender, EventArgs e)
        {
            var pagesend = sender as LinkButton;
            if (pagesend.CommandArgument == "&laquo;")
            {

            }
            else if (pagesend.CommandArgument == "&raquo;")
            {

            }
            else
            {
                for (int i = 1; i < rpPager.Items.Count-1; i++)
                {
                    var lnkPageIndex = rpPager.Items[i].FindControl("lnkPageIndex") as LinkButton;
                    lnkPageIndex.CssClass = "";
                }
                pagesend.Attributes.Add("class", "active");
                PageIndex = int.Parse(pagesend.CommandArgument);
            }
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
    }
}