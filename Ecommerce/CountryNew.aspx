<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryNew.aspx.cs" Inherits="WebApplication3.CountryNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img alt="" src="images/loading5.gif" style="width: 107px; height: 71px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
<br />
<br />
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
<br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:Label ID="lblError" runat="server" ForeColor="#FF5050"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Required JS" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
            <asp:Button ID="btnSave" runat="server" Height="26px" OnClick="btnSave_Click" Text="Save" />
            &nbsp;<asp:Button ID="btnReset" runat="server" CausesValidation="False" OnClick="btnReset_Click" Text="Reset" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
