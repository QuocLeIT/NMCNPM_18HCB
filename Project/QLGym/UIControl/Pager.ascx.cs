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

        public int TotalRow { get; set; }
        public int PageSize { get; set; }
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

        public void BingPaging(int totalRow,int pageSize,int pageNumber = 1)
        {
            if(pageNumber != 1)
            {
                return;
            }
            TotalRow = totalRow;
            PageSize = pageSize;

            int TotalPage = ((TotalRow - 1) / PageSize) + 1;

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
                for (int i = 1; i < rpPager.Items.Count - 1; i++)
                {
                    var lnkPageIndex = rpPager.Items[i].FindControl("lnkPageIndex") as LinkButton;
                    string Class = lnkPageIndex.CssClass;
                    lnkPageIndex.CssClass = "";
                    if(Class == "active")
                    {
                        if(lnkPageIndex.CommandArgument == "1")
                        {
                            lnkPageIndex.CssClass = "active";
                            PageIndex = int.Parse(lnkPageIndex.CommandArgument);
                        }
                        else
                        {
                            PageIndex = int.Parse(lnkPageIndex.CommandArgument) -1;
                            var lnkPageActive = rpPager.Items[PageIndex].FindControl("lnkPageIndex") as LinkButton;
                            lnkPageActive.CssClass = "active";
                        }
                    }
                }
            }
            else if (pagesend.CommandArgument == "&raquo;")
            {
                for (int i = rpPager.Items.Count - 2; i >= 1; i--)
                {
                    var lnkPageIndex = rpPager.Items[i].FindControl("lnkPageIndex") as LinkButton;
                    string Class = lnkPageIndex.CssClass;
                    lnkPageIndex.CssClass = "";
                    if (Class == "active")
                    {
                        if (lnkPageIndex.CommandArgument == (rpPager.Items.Count - 2).ToString())
                        {
                            lnkPageIndex.CssClass = "active";
                            PageIndex = int.Parse(lnkPageIndex.CommandArgument);
                        }
                        else
                        {
                            PageIndex = int.Parse(lnkPageIndex.CommandArgument) + 1;
                            var lnkPageActive = rpPager.Items[PageIndex].FindControl("lnkPageIndex") as LinkButton;
                            lnkPageActive.CssClass = "active";
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < rpPager.Items.Count-1; i++)
                {
                    var lnkPageIndex = rpPager.Items[i].FindControl("lnkPageIndex") as LinkButton;
                    lnkPageIndex.CssClass = "";
                }
                pagesend.CssClass = "active";
                PageIndex = int.Parse(pagesend.CommandArgument);
            }
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
    }
}