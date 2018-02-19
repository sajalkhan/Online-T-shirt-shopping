using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DAL.country c = new DAL.country();
            //GridView1.DataSource = c.Select().Tables[0];
            //GridView1.DataBind();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            lblMessage.Text = "Data Updated";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            lblMessage.Text = "Data Deleted";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Server.Transfer("CountryEdit.aspx?country="+btn.CommandArgument);
            Response.Redirect("CountryEdit.aspx?country=" + btn.CommandArgument);

        }
    }
}