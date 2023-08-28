using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmadminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if ((txt_username.Text == "PRK22MS1043") && (txt_password.Text == "29092001"))
        {
            Response.Redirect("frmadminmenu.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Invalid Login');</script>");
            return;
        }

    }
}