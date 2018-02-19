using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ProductNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DropDownList ddlCategory = (DropDownList)DetailsView1.FindControl("ddlCategory");
                DropDownList ddlBrand = (DropDownList)DetailsView1.FindControl("ddlBrand");


                ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
                ddlBrand.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
    }
}