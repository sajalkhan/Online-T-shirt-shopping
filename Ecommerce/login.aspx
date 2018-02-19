<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email/contact"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Pas" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me" />
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="forgot.aspx">Forgot Password</asp:HyperLink>
&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="register.aspx">Register</asp:HyperLink>
</asp:Content>
