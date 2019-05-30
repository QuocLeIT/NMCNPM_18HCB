using Core.Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Provider;

namespace QLGym.UIControl
{
    public class DDLCustom : System.Web.UI.WebControls.DropDownList
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
            }
            base.OnLoad(e);
        }

        private String _NoSelected = "-- All --";
        public int? type { get; set; } // 0 All, 1 Nhân viên, 2  khách hàng
        public bool? haveOptionAll { get; set; }

        object listType;

        public class ListItem
        {
            public int Id { get; set; }
            public String Name { get; set; }
        }

        public void DataBindData(object _listType)
        {
            listType = _listType;
            DataBind();
        }

        public override void DataBind()
        {
           
           
            DataSource = listType;
            DataValueField = "ID";
            DataTextField = "Name";
            base.DataBind();

        }

        public int PositionId
        {
            get
            {
                if (String.IsNullOrWhiteSpace(SelectedValue))
                    return 0;
                var PositionId = Convert.ToInt32(SelectedValue);
                return PositionId;
            }
            set { SelectedValue = Convert.ToString(value); }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HttpContext.Current.Items["PositionId"] = PositionId;
            base.OnSelectedIndexChanged(e);
        }
    }
}