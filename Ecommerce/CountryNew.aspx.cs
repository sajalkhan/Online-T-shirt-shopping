using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class CountryNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;

            if (txtName.Text == "")
            {
                er++;
                lblError.Text = "Required";
            }
            if (er > 0) return;

            DAL.country c = new DAL.country();
            c.Name = txtName.Text;
            if (c.Insert())
            {
                btnReset_Click(null, null);
                lblMessage.Text = "Data Saved!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = c.Error;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtName.Text = "";
            lblError.Text = "";
            txtName.Focus();
        }
    }
}