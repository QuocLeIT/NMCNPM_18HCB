<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisPackageList.aspx.cs" Inherits="QLGym.Page.RegisPackageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Content/css/chosen.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Danh sách đăng ký gói tập luyện</h1>
    <br />
    
     <div runat="server" class="modal in" id="dvImport" visible="false" tabindex="-1" role="dialog" aria-labelledby="modal-fa5-label" style="display: block;">
        <div class="modal-dialog modal-lg" role="document" style="padding-top: 50px">
            <div class="modal-content" style="max-height: 650px;">
                <div class="modal-header">
                    <div class="col-12" style="text-align: center">
                        <h6>Create new</h6>
                    </div>
                </div>
                <div class="modal-body mx-0" style="max-height: 600px; overflow: auto">
                    <div class="panel-body">
                        <div class="row">

                            <div class="col-8">
                                <asp:HiddenField runat="server" ID="hfUserIdEdit" />
                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">                                          
                                            <asp:TextBox runat="server" ID="txtNgayDK" placeholder="Ngày đăng ký" ></asp:TextBox>
                                        </div>
                                    </div>

                                  
                                    <div class="col-sm-6" style="z-index: 50;">
                                        <div class="receipe-post-search mb-30">
                                            <QLG:DDLCustom runat="server" ID="ddlPackageNew" CssClass="asp-select" OnSelectedIndexChanged ="ddlPackageNew_OnSelectedIndexChanged"></QLG:DDLCustom>
                                        </div>
                                    </div>

                                     <div class="col-sm-6" style="z-index: 50;">
                                        <div class="receipe-post-search mb-30">
                                            <QLG:DDLCustom runat="server" ID="ddlUserNew" CssClass="asp-select"></QLG:DDLCustom>
                                        </div>
                                    </div>               
    
                                 <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">                                          
                                            <asp:TextBox runat="server" ID="txtQuantity" type="number" placeholder="Số gói mua" ></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtNgayHH" ReadOnly="true" placeholder="Ngày hết hạn"></asp:TextBox>
                                        </div>
                                    </div>
            
                                    <div class="col-sm-6">
                                        <div class="receipe-post-search mb-30">
                                            <asp:TextBox runat="server" ID="txtGhiChu" placeholder="Ghi chú"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="col-4">
                                <div class="col-sm-12">
                                    <div class="receipe-post-search mb-30">
                                        <asp:TextBox runat="server" ID="txtPrice" ReadOnly="true" placeholder="Phí gói" autocomplete="false"></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-sm-12">
                                        <div class="receipe-post-search mb-30">
                                            <div class="row">
                                                <div class="col-6" style="padding-right: 0px">
                                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtTotal" type="number" placeholder="Tổng"></asp:TextBox>
                                                </div>
                                                <div class="col-6" style="padding-left: 2px">
                                                    <asp:TextBox runat="server" ID="txtSubSalary" Enabled="false" Text=".000 VND"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                               
                            </div>

                        </div>
                        <div class="row">
                            <div class="col align-self-center">
                                <asp:LinkButton ID="btnCreateSubmit" CssClass="btn delicious-btn" runat="server" OnClick="btnCreateSubmit_Click">Create</asp:LinkButton>
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

    <div class="receipe-post-search mb-30" style="margin-bottom: 10px !important; z-index: unset;margin-left:-4px">
        <div class="row">
            <div class="col-12 col-lg-12">
                <asp:LinkButton runat="server" ID="btnCreate" CssClass="btn delicious-btn m-1 create" OnClick="btnCreate_Click">New regis</asp:LinkButton>
            </div>
        </div>
    </div>

   <table class="table primary">
        <thead class="thead-primary">
            <tr>
                <th scope="col">STT</th>
                <th scope="col">Tên khách hàng</th>
                <th scope="col">Gói tập</th>
                <th scope="col">Phí gói tập</th>
                <th scope="col">Ngày đăng ký</th>
                <th scope="col">Số lượng gói mua</th>
                <th scope="col">Tổng phí</th>
                <th scope="col">Ngày hết hạn</th>
                <th scope="col">Ghi chú</th>
                <th scope="col">Tools</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpPackageList" OnItemCreated="rpPackageList_ItemCreated">
                <ItemTemplate>
                    <tr>
                        <asp:HiddenField runat="server" ID="hfPackagaId" Value='<%#Eval("ID") %>' />
                        <td></td>               
                        <td><%#Eval("Username") %></td>
                        <td><%#Eval("GoiTap") %></td>
                        <td><%# String.Format("{0:C0}", Eval("Price")).Replace("$","") %></td>
                        <td><%#Eval("NgayDangKy") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td><%# String.Format("{0:C0}", Eval("Total")).Replace("$","") %></td>
                        <td><%#Eval("NgayHetHan") %></td>
                        <td><%# Eval("GhiChu") %></td>

                        <td>
                            <asp:LinkButton runat="server" ID="btnEdit" CommandArgument='<%#Eval("ID") %>' Style="color: #4CAF50" ToolTip="Edit" OnClick="btnEdit_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID") %>' Style="color: #4CAF50; float: right" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Xác nhận xóa nhân viên?')"><i class="fa fa-times-circle"></i></asp:LinkButton>
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
