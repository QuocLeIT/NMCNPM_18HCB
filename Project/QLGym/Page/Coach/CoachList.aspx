<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoachList.aspx.cs" Inherits="QLGym.Coach.CoachList" %>

<%@ Register Src="~/UIControl/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Content/css/chosen.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="receipe-post-search mb-30">
        <div class="row">
            <div class="col-12 col-lg-3">
                <QLG:DDLPosition runat="server"></QLG:DDLPosition>
            </div>
            <div class="col-12 col-lg-3">
                <select name="select1" id="select2">
                    <option value="1">All Receipies Categories</option>
                    <option value="1">All Receipies Categories 2</option>
                    <option value="1">All Receipies Categories 3</option>
                    <option value="1">All Receipies Categories 4</option>
                    <option value="1">All Receipies Categories 5</option>
                </select>
            </div>
            <div class="col-12 col-lg-3">
                <input type="search" name="search" placeholder="Search Receipies">
            </div>
            <div class="col-12 col-lg-3 text-right">
                <button type="submit" class="btn delicious-btn">Search</button>
            </div>
        </div>
    </div>
    <table class="table">
        <thead class="thead-primary">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Ten</th>
                <th scope="col">NamSinh</th>
                <th scope="col">Phone</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpCoachList">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("ID") %></td>
                        <td><%#Eval("Name") %></td>
                        <td><%#Eval("NamSinh") %></td>
                        <td><%# Eval("Phone") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div class="row">
        <uc1:Pager runat="server" ID="Pager" OnButtonClick="Pager_ButtonClick" />

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script src="../../Content/js/chosen.jquery.min.js"></script>
</asp:Content>
