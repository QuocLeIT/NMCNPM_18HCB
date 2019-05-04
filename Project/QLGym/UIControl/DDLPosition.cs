using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLGym.UIControl
{
    public class DDLPosition : System.Web.UI.WebControls.DropDownList
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
            }
            base.OnLoad(e);
        }

        private String _NoSelected = "-- None --";

        public class ListItem
        {
            public int Id { get; set; }
            public String Name { get; set; }
        }

        public override void DataBind()
        {
            var list = new ListItem[] {
                new ListItem() { Id = 0, Name = _NoSelected },
                new ListItem() { Id = 1, Name = "Customer"},
                new ListItem() { Id = 2, Name = "Coach" },
                new ListItem() { Id = 3, Name = "Admin" },
            };
            DataSource = list;
            DataValueField = "Id";
            DataTextField = "Name";
            base.DataBind();
        }

        public int? PositionId
        {
            get
            {
                if (String.IsNullOrWhiteSpace(SelectedValue))
                    return null;
                var PositionId = Convert.ToInt32(SelectedValue);
                return PositionId == 0 ? (int?)null : PositionId;
            }
            set { SelectedValue = Convert.ToString(value); }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HttpContext.Current.Items["GenderId"] = PositionId;
            base.OnSelectedIndexChanged(e);
        }
    }
}