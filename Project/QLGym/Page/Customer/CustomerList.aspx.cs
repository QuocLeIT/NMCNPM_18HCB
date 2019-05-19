using Core.Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLGym.Page.Customer
{
    public partial class CustomerList : GymPage
    {
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
            ddlPosition.type = 2;
            ddlPosition.haveOptionAll = false;
            ddlPosition.DataBind();
            ddlPositionNew.type = 2;
            ddlPositionNew.haveOptionAll = false;
            ddlPosition.DataBind();
        }
        void loadData(int pageNumber, int pageSize = 25)
        {
            int Type = ddlPosition.PositionId;
            string Email = string.IsNullOrWhiteSpace(txtSearchEmail.Text) ? null : txtSearchEmail.Text;
            string Username = string.IsNullOrWhiteSpace(txtUsername.Text) ? null : txtUsername.Text;
            string Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;
            var lstEmployee = UserService.GetDynamic(Username, Phone, Email, Type, pageSize, pageNumber);
            int TotalRow = 0;

            if (lstEmployee.Rows.Count > 0)
            {
                rpCoachList.DataSource = lstEmployee;
                rpCoachList.DataBind();
                TotalRow = Convert.ToInt32(lstEmployee.Rows[0]["Total"]);
            }
            else
            {
                rpCoachList.DataSource = null;
                rpCoachList.DataBind();
            }

            Pager.BingPaging(TotalRow, pageSize, pageNumber);
        }

        protected void Pager_ButtonClick(object sender, EventArgs e)
        {
            int page = Pager.PageIndex;
            loadData(page);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            hfUserIdEdit.Value = "";
            dvImport.Visible = true;

            txtName.Text = "";
            ddlPositionNew.SelectedIndex = 0;
            txtNamSinh.Text = "";
            txtPhoneNew.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
            txtUsernew.Text = "";
            txtPassNew.Text = "";

            txtUsernew.Enabled = true;
            txtPassNew.Enabled = true;
            btnCreateSubmit.Text = "Create Customer";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string position = ddlPosition.SelectedValue;
            loadData(1);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            dvImport.Visible = false;
        }

        protected void btnCreateSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Alert("Vui lòng nhập Tên Khách hàng");
                return;
            }
            if (ddlPositionNew.PositionId == 0)
            {
                Alert("Vui lòng chọn Loại Khách hàng");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNew.Text))
            {
                Alert("Vui lòng nhập điện thoại Khách hàng");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsernew.Text))
            {
                Alert("Vui lòng nhập tài khoản");
                return;
            }
            if (hfUserIdEdit.Value == "")
            {
                if (string.IsNullOrWhiteSpace(txtPassNew.Text))
                {
                    Alert("Vui lòng nhập mật khẩu");
                    return;
                }
                var validUser = UserService.GetByUsername(txtUsernew.Text);
                if (validUser != null)
                {
                    Alert("User name đã tồn tại");
                    return;
                }
            }

            decimal salary = 0;
            //decimal.TryParse(txtSalary.Text, out salary);

            UserEntity newUser = new UserEntity()
            {
                Name = txtName.Text,
                IDLoaiUser = ddlPositionNew.PositionId,
                NamSinh = Convert.ToInt32(txtNamSinh.Text),
                DiaChi = txtAddress.Text,
                Phone = txtPhoneNew.Text,
                Email = txtEmail.Text,
                Luong = salary * 1000,
                Username = txtUsernew.Text,
                Pass = txtPassNew.Text.ToMD5(),
            };
            if (hfUserIdEdit.Value != "")
            {
                newUser.ID = Convert.ToInt32(hfUserIdEdit.Value);
                try
                {
                    UserService.Update(newUser);
                    Alert("Cập nhật Khách hàng thành công");
                    loadData(1);
                }
                catch
                {
                    Alert("Lỗi!!!");
                }
            }
            else
            {
                UserService.Insert(ref newUser);
                if (newUser.ID != 0)
                {
                    Alert("Thêm Khách hàng thành công");
                }
                else
                {
                    Alert("Lỗi!!!");
                }
            }
        }

        protected void rpCoachList_ItemCreated(object sender, RepeaterItemEventArgs e)
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
            var UserEdit = UserService.GetById(Id);
            hfUserIdEdit.Value = UserEdit.ID.ToString();
            txtName.Text = UserEdit.Name;
            ddlPositionNew.PositionId = UserEdit.IDLoaiUser;
            txtNamSinh.Text = UserEdit.NamSinh.ToString();
            txtPhoneNew.Text = UserEdit.Phone;
            txtAddress.Text = UserEdit.DiaChi;
            txtEmail.Text = UserEdit.Email;
            txtSalary.Text = Convert.ToInt32(UserEdit.Luong / 1000).ToString();
            txtUsernew.Text = UserEdit.Username;
            txtPassNew.Text = "123456";

            txtUsernew.Enabled = false;
            txtPassNew.Enabled = false;
            btnCreateSubmit.Text = "Update Customer";
        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            var btnReset = sender as LinkButton;
            try
            {
                UserService.UpdatePass(int.Parse(btnReset.CommandArgument), "123456".ToMD5());
                Alert("Reset password thành công");
            }
            catch
            {
                Alert("Lỗi");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btnDelete = sender as LinkButton;
            try
            {
                UserService.Delete(int.Parse(btnDelete.CommandArgument));
                Alert("Xóa Khách hàng thành công");
                loadData(1);
            }
            catch
            {
                Alert("Lỗi!!!");
            }
        }
    }
}