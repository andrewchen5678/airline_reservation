using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            Response.Redirect("searchandbook.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {

    }
}
