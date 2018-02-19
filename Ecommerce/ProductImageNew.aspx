<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductImageNew.aspx.cs" Inherits="WebApplication3.ProductImageNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" DefaultMode="Insert" GridLines="Horizontal" Height="50px" Width="125px" OnItemInserting="DetailsView1_ItemInserting" OnItemInserted="DetailsView1_ItemInserted">
        <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="productId" SortExpression="productId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("productId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlProduct" runat="server" Selectedvalue='<%# Bind("productId") %>' DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [Id], [Name] FROM [Product]"></asp:SqlDataSource>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlProduct" ErrorMessage="Required" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("productId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="title" SortExpression="title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="filename" SortExpression="filename">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("filename") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:FileUpload ID="fleImage" runat="server" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("filename") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <InsertItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyCon %>" DeleteCommand="DELETE FROM [productimage] WHERE [id] = @original_id AND [productId] = @original_productId AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([datetime] = @original_datetime) OR ([datetime] IS NULL AND @original_datetime IS NULL)) AND (([image] = @original_image) OR ([image] IS NULL AND @original_image IS NULL)) AND (([filename] = @original_filename) OR ([filename] IS NULL AND @original_filename IS NULL))" InsertCommand="INSERT INTO [productimage] ([productId], [title], [datetime], [filename]) VALUES (@productId, @title, @datetime, @filename)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [productimage]" UpdateCommand="UPDATE [productimage] SET [productId] = @productId, [title] = @title, [datetime] = @datetime, [image] = @image, [filename] = @filename WHERE [id] = @original_id AND [productId] = @original_productId AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([datetime] = @original_datetime) OR ([datetime] IS NULL AND @original_datetime IS NULL)) AND (([image] = @original_image) OR ([image] IS NULL AND @original_image IS NULL)) AND (([filename] = @original_filename) OR ([filename] IS NULL AND @original_filename IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_id" Type="Int32" />
            <asp:Parameter Name="original_productId" Type="Int32" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_datetime" Type="DateTime" />
            <asp:Parameter Name="original_image" Type="Object" />
            <asp:Parameter Name="original_filename" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="productId" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="datetime" Type="DateTime" />
            <asp:Parameter Name="filename" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="productId" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="datetime" Type="DateTime" />
            <asp:Parameter Name="image" Type="Object" />
            <asp:Parameter Name="filename" Type="String" />
            <asp:Parameter Name="original_id" Type="Int32" />
            <asp:Parameter Name="original_productId" Type="Int32" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_datetime" Type="DateTime" />
            <asp:Parameter Name="original_image" Type="Object" />
            <asp:Parameter Name="original_filename" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
