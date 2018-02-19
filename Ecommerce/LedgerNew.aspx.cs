using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class LedgerNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList ddlCountry = (DropDownList)DetailsView1.FindControl("ddlCountry");
            ddlCountry.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["employeeId"] = Session["id"];
            e.Values["cityId"]= ((DropDownList)DetailsView1.FindControl("ddlCity")).SelectedValue;
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCity = (DropDownList)DetailsView1.FindControl("ddlCity");
            
            DAL.city city = new DAL.city();
            city.CountryId = Convert.ToInt32(((DropDownList)DetailsView1.FindControl("ddlCountry")).SelectedValue);

            ddlCity.DataSource = city.Select().Tables[0];
            ddlCity.DataTextField = "name";
            ddlCity.DataValueField = "id";

            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
}