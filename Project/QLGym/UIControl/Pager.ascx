<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="QLGym.UIControl.Pager" %>
<div class="pagination">
    <asp:Repeater runat="server" ID="rpPager">
        <ItemTemplate>
            <%--<a href="#"><%#Eval("PageIndex") %></a>--%>
            <asp:LinkButton runat="server" ID="lnkPageIndex" CssClass='<%# bool.Parse(Eval("isActive").ToString()) == true ? "active" : "" %>' OnClick="lnkPageIndex_Click" CommandArgument='<%#Eval("PageIndex") %>'><%#Eval("PageIndex") %></asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
</div>
