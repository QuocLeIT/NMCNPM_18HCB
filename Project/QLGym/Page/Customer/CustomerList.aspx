<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="QLGym.Page.Customer.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Modal -->
    <div runat="server" class="modal in" id="dvImport" visible="false" tabindex="-1" role="dialog" aria-labelledby="modal-fa5-label" style="display: block;">
        <div class="modal-dialog modal-lg" role="document" style="padding-top: 50px">
            <div class="modal-content" style="max-height: 650px;">
                <div class="modal-header">
                    <div class="col-12" style="text-align: center">
                        <h6>Create new employee</h6>
                    </div>
                </div>
                <div class="modal-body mx-0" style="max-height: 600px; overflow: auto">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-8">
                                <asp:HiddenField runat="server" ID="hfUserIdEdit" />
                                <div class="row">
                                    <div class="col-6">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtName" placeholder="Tên Khách hàng"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6" style="z-index: 50; display:none">
                                        <div class="receipe-post-search mb-30">
                                            <QLG:DDLPosition runat="server" ID="ddlPositionNew" Visible="false" CssClass="asp-select"></QLG:DDLPosition>
                                        </div>
                                    </div>
                                    <div class="col-6" style="z-index: 50;">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtNamSinh" placeholder="Năm sinh" CssClass="birth-date"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtPhoneNew" placeholder="Số điện thoại"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtEmail" placeholder="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtAddress" placeholder="Địa chỉ"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">
                                            <div class="row">
                                                <div class="col-6" style="padding-right: 0px">
                                                    <asp:TextBox runat="server" ID="txtSalary" Visible="false" type="number" placeholder="Lương"></asp:TextBox>
                                                </div>
                                                <div class="col-6" style="padding-left: 2px">
                                                    <asp:TextBox runat="server" ID="txtSubSalary" Visible="false" Enabled="false" Text=".000 VND"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="col-sm-12">
                                    <div class="receipe-post-search mb-30">
                                        <asp:TextBox runat="server" ID="txtUsernew" placeholder="Tài khoản" autocomplete="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="receipe-post-search mb-30">
                                        <asp:TextBox runat="server" ID="txtPassNew" placeholder="mật khẩu" type="password" autocomplete="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col align-self-center">
                                <asp:LinkButton ID="btnCreateSubmit" CssClass="btn delicious-btn" runat="server" OnClick="btnCreateSubmit_Click">Create Customer</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" ID="btnCancel" CssClass="btn delicious-btn" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <div class="receipe-post-search mb-30">
        <div class="row">
            <div class="col-12 col-lg-3">
                <QLG:DDLPosition runat="server" ID="ddlPosition" Visible="false" CssClass="asp-select"></QLG:DDLPosition>
                <asp:TextBox runat="server" ID="txtSearchEmail" placeholder="Search by Email"></asp:TextBox>
            </div>
            <div class="col-12 col-lg-3">
                <asp:TextBox runat="server" ID="txtUsername" placeholder="Search by Username"></asp:TextBox>
            </div>
            <div class="col-12 col-lg-3">
                <asp:TextBox runat="server" ID="txtPhone" placeholder="Search by phone"></asp:TextBox>
            </div>
            <div class="col-12 col-lg-3 text-right">
                <%--<button type="submit" class="btn delicious-btn">Search</button>--%>
                <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn delicious-btn" OnClick="btnSearch_Click">Search</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="receipe-post-search mb-30" style="margin-bottom: 10px !important; z-index: unset;margin-left:-4px">
        <div class="row">
            <div class="col-12 col-lg-12">
                <asp:LinkButton runat="server" ID="btnCreate" CssClass="btn delicious-btn m-1 create" OnClick="btnCreate_Click">New Customer</asp:LinkButton>
            </div>
        </div>
    </div>
    <table class="table primary">
        <thead class="thead-primary">
            <tr>
                <th scope="col">STT</th>
                <th scope="col">Tên</th>
                <th scope="col">Năm sinh</th>
                <th scope="col">Số điện thoại</th>
                <th scope="col">Email</th>
                <th scope="col">Địa chỉ</th>
                <th scope="col">Username</th>
                <th scope="col">Tools</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpCoachList" OnItemCreated="rpCoachList_ItemCreated">
                <ItemTemplate>
                    <tr>
                        <asp:HiddenField runat="server" ID="hfUserId" Value='<%#Eval("ID") %>' />
                        <td><%#Eval("RowNum") %></td>
                        <td><%#Eval("Name") %></td>
                        <td><%#Eval("NamSinh") %></td>
                        <td><%# Eval("Phone") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("DiaChi") %></td>
                        <td><%# Eval("Username") %></td>
                        <td>
                            <asp:LinkButton runat="server" ID="btnEdit" CommandArgument='<%#Eval("ID") %>' Style="color: #4CAF50" ToolTip="Edit" OnClick="btnEdit_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnResetPass" CommandArgument='<%#Eval("ID") %>' Style="color: #4CAF50;" ToolTip="Reset password" OnClick="btnResetPass_Click" OnClientClick="return confirm('Xác nhận reset mật khẩu Khách hàng?')"><i class="fa fa-sync"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID") %>' Style="color: #4CAF50; float: right" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Xác nhận xóa Khách hàng?')"><i class="fa fa-times-circle"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div class="row">
        <Paging:Pager runat="server" ID="Pager" OnButtonClick="Pager_ButtonClick" />

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script src="../../Content/js/chosen.jquery.min.js"></script>
    <script>
        $(window).keydown(function (e) {
            switch (e.keyCode) {
                case 13: // enter key
                    <%--try {
                        var submit = $("#<%=btnCreateSubmit.ClientID%>");
                        submit.click();
                    }
                    catch{
                        $("#<%=btnSearch.ClientID%>").click();
                        this.console.log('b');
                    }--%>
                    e.preventDefault();
                    return;
            }
        });
    </script>
</asp:Content>
