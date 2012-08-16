using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class resetpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
    }

    protected void resetBtn_Click(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        if (!Page.IsValid) return;
        if (GridView1.SelectedIndex < 0)
        {
            Interaction.setFailureMessage(Literal1, "please select a user first");
            return;
        }
        try
        {
            Admin u = (Admin)Interaction.LoggedInUser;
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            u.resetPass(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text), passTxt.Text);
            Interaction.setSuccessMessage(Literal1,"password reset");
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
        }
        //u.resetPass(6, passTxt.Text);
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
