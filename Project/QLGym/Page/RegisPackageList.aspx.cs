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
using System.Data;

namespace QLGym.Page
{
    public partial class RegisPackageList : GymPage
    {
        DataProvider dp = new DataProvider();
        DataTable ta_Packages = new DataTable();
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
            DataProvider dp = new DataProvider();
            ta_Packages = dp.Fillbang("select ID, Name, Price from DMGoiTap order by Name");

            ddlUserNew.type = 1;
            ddlUserNew.DataBindData(dp.Fillbang("select ID, Name from DMUsernames where IDLoaiUser = 5 order by Name"));

            ddlPackageNew.type = 1;
            ddlPackageNew.DataBindData(ta_Packages);
           
        }
        void loadData(int pageNumber, int pageSize = 25)
        {
            var lstEmployee = RegisPackageService.GetAll();
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

            //txtName.Text = "";
            ////  ddlPositionNew.SelectedIndex = 0;
            //txtTime.Text = "";
            //txtPrice.Text = "";
            //txtGhiChu.Text = "";

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
            DateTime ngayDK, ngayHH;
            long id, idUser, idPackage;
            int quantity, soThang;
            decimal price, total;

            try
            {
                //ngayDK = Convert.ToDateTime(txtNgayDK.Text + " 00:00:00.00");
                ngayDK = DateTime.ParseExact(txtNgayDK.Text + " 00:00:00.00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                ngayDK = DateTime.Now.Date;
            }


            idUser = Convert.ToInt64(ddlUserNew.SelectedValue);
            idPackage = Convert.ToInt64(ddlPackageNew.SelectedValue);

            if (idUser < 1 || idPackage < 1)
            {
                Alert("Vui lòng chọn khách hàng hoặc gói tập!");
                return;
            }

            quantity = Convert.ToInt16(txtQuantity.Text);
            if (quantity < 1 || idPackage > 20)
            {
                Alert("Vui lòng nhập số gói mua hợp lệ (> 0)");
                return;
            }

            decimal salary = 0;
            decimal.TryParse(txtTotal.Text, out salary);

            DataTable tb = dp.Fillbang("select ID, Name, Price, ThoiGian from DMGoiTap where ID = " + idPackage.ToString());
            price = Convert.ToDecimal(tb.Rows[0]["Price"].ToString());
            soThang = Convert.ToInt16(tb.Rows[0]["ThoiGian"].ToString());

            total = price * quantity;
          
            ngayHH = ngayDK.AddMonths(soThang * quantity);


            RegisPackageEntity newUser = new RegisPackageEntity()
            {
                
                NgayDK = ngayDK,
                IDGoiTap = idPackage,
                IDUser = idUser,
                Price = price,
                GhiChu = txtGhiChu.Text,  
                NgayHH = ngayHH,
                Quantity = quantity,
                Total = total,
            };

            if (hfUserIdEdit.Value != "")
            {
                newUser.ID = Convert.ToInt32(hfUserIdEdit.Value);
                try
                {
                    RegisPackageService.Update(newUser);
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
               
                try
                {
                    RegisPackageService.Insert(newUser);
                    Alert("Thành công");
                    loadData(1);                
                }
                catch
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

            var pk = RegisPackageService.GetById(Id);

            hfUserIdEdit.Value = pk.ID.ToString();

            txtNgayDK.Text = pk.NgayDK.ToString("dd/MM/yyyy");
            txtNgayHH.Text = pk.NgayHH.ToString("dd/MM/yyyy");

            ddlUserNew.SelectedValue = pk.IDUser.ToString();
            ddlPackageNew.SelectedValue = pk.IDGoiTap.ToString();
            txtPrice.Text = pk.Price.ToString();

            txtQuantity.Text = pk.Quantity.ToString();
            txtTotal.Text = (pk.Total/1000).ToString();

            
            txtGhiChu.Text = pk.GhiChu.ToString();

            btnCreateSubmit.Text = "Update";
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btnDelete = sender as LinkButton;
            try
            {
                RegisPackageService.Delete(int.Parse(btnDelete.CommandArgument));
                //Alert("Thành công");
                loadData(1);
            }
            catch
            {
                Alert("Lỗi!!!");
            }
        }


        protected void ddlPackageNew_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //DataView dv = new DataView(ta_Packages);
            //dv.RowFilter = "ID = " + ddlPackageNew.SelectedValue.ToString();

            //txtPrice.Text =  dv[0]["Price"].ToString();
            
        }

    }
}