using Core.Entity;
using QLGym.UIControl;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Provider;

namespace QLGym.Page
{
    public partial class PackageList : GymPage
    {
        DataProvider dp = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                init();
                loadData(1);
            }
        }
        void init()
        {
            //ddlPosition.type = 1;
            //ddlPosition.DataBind();
            //ddlPositionNew.type = 1;
            //ddlPosition.DataBind();
        }
        void loadData(int pageNumber, int pageSize = 25)
        {
            var lstEmployee = PackageService.GetAll_2();
            int TotalRow = 0;

            if (lstEmployee.Rows.Count > 0)
            {
                rpPackageList.DataSource = lstEmployee;
                rpPackageList.DataBind();
                TotalRow = lstEmployee.Rows.Count;
            }
            else
            {
                rpPackageList.DataSource = null;
                rpPackageList.DataBind();
            }

            Pager.BingPaging(TotalRow, pageSize, pageNumber);
        }


        protected void Pager_ButtonClick(object sender, EventArgs e)
        {
           
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            hfUserIdEdit.Value = "";
            dvImport.Visible = true;

            txtName.Text = "";
          //  ddlPositionNew.SelectedIndex = 0;
            txtTime.Text = "";
            txtPrice.Text = "";
            txtGhiChu.Text = "";
          
           btnCreateSubmit.Text = "Create Employee";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            dvImport.Visible = false;
        }

        protected void btnCreateSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Alert("Vui lòng nhập Tên gói tập");
                return;
            }
            //if (ddlPositionNew.PositionId == 0)
            //{
            //    Alert("Vui lòng chọn Loại nhân viên");
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(txtTime.Text))
            {
                Alert("Vui lòng nhập thời gian");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                Alert("Vui lòng nhập phí");
                return;
            }
            

            decimal salary = 0;
            decimal.TryParse(txtPrice.Text, out salary);

            PackageEntity newUser = new PackageEntity()
            {               
                Name = txtName.Text,
                ThoiGian = Convert.ToInt16(txtTime.Text),
                GhiChu = txtGhiChu.Text,
                Price = Convert.ToDecimal(txtPrice.Text) * 1000,         
            };

            if (hfUserIdEdit.Value != "")
            {
                newUser.ID = Convert.ToInt32(hfUserIdEdit.Value);
                try
                {
                    PackageService.Update_2(newUser);
                    Alert("Cập nhật thành công");
                    loadData(1);
                    dvImport.Visible = false;
                }
                catch
                {
                    Alert("Lỗi!!!");
                }
            }
            else
            {
                PackageService.Insert(ref newUser);
                if (newUser.ID > 0)
                {
                    Alert("Thành công");
                    loadData(1);
                }
                else
                {
                    Alert("Lỗi!!!");
                }
            }
        }

        protected void rpPackageList_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var btnEdit = e.Item.FindControl("btnEdit") as LinkButton;
            var btnDelete = e.Item.FindControl("btnDelete") as LinkButton;
            ScriptManager scriptManager = ScriptManager.GetCurrent(this);
            if (btnEdit != null)
                scriptManager.RegisterAsyncPostBackControl(btnEdit);
            if (btnDelete != null)
                scriptManager.RegisterAsyncPostBackControl(btnDelete);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btnEdit = sender as LinkButton;
            dvImport.Visible = true;
            int Id = Convert.ToInt32(btnEdit.CommandArgument);

            var pk = PackageService.GetById_2(Id);

            hfUserIdEdit.Value = pk.ID.ToString();
            txtName.Text = pk.Name;
            //ddlPositionNew.PositionId = UserEdit.IDLoaiUser;
            txtGhiChu.Text = pk.GhiChu.ToString();
            txtTime.Text = pk.ThoiGian.ToString();
            txtPrice.Text = Convert.ToInt32(pk.Price / 1000).ToString();

            btnCreateSubmit.Text = "Update";
        }

      

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btnDelete = sender as LinkButton;
            try
            {
                PackageService.Delete_2(int.Parse(btnDelete.CommandArgument));
                //Alert("Thành công");
                loadData(1);
            }
            catch
            {
                Alert("Lỗi!!!");
            }
        }
    }
}