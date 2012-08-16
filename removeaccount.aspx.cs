using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class removeaccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();        
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        if (!Page.IsPostBack)
        {
            Session["userDel"] = null;
            if (Request.QueryString["success"] == ("1"))
            {
                Interaction.setSuccessMessage(Literal1, "user removed");
            }
        }
        else
        {
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex < 0)
        {
            Interaction.setFailureMessage(Literal1, "please select a user first");
            return;
        }
        else
        {
            int theUserNumber=Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            if (theUserNumber == Interaction.LoggedInUser.UserNumber)
            {
                Interaction.setFailureMessage(Literal1, "cannot remove admin himself");
                return;
            }
            User u = new User(theUserNumber, GridView1.SelectedRow.Cells[2].Text, GridView1.SelectedRow.Cells[3].Text, Convert.ToInt32(GridView1.SelectedRow.Cells[4].Text), GridView1.SelectedRow.Cells[5].Text,
                GridView1.SelectedRow.Cells[6].Text, GridView1.SelectedRow.Cells[7].Text, GridView1.SelectedRow.Cells[8].Text);
            Session["userDel"] = u;
            Response.Redirect("confirmremove.aspx");
        }
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "SqlDataSource1";
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            Interaction.setFailureMessage(Literal1, "no result found");
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }
    }
}
