using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ProductImageNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DropDownList ddlProduct = (DropDownList)DetailsView1.FindControl("ddlProduct");
                ddlProduct.Items.Insert(0,new ListItem("Select","0"));
            }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["datetime"] = DateTime.Now;
            e.Values["filename"] = ((FileUpload)DetailsView1.FindControl("fleImage")).FileName;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            FileUpload file = (FileUpload)DetailsView1.FindControl("fleImage");
            file.SaveAs(Server.MapPath("uploads/images/"+file.FileName));
        }
    }
}