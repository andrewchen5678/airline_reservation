using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edituseradmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Agent)) Interaction.redirUnauthorize();
        if (!(Interaction.LoggedInUser is Admin)) Response.Redirect("edituser.aspx");
        Literal1.Text = "";
        if (!Page.IsPostBack) Session["toEdit"] = null;
        User toEdit = (User)Session["toEdit"];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.SelectCommand = "SELECT * FROM [user] ";
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
    protected void editBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        if (GridView1.SelectedIndex < 0)
        {
            Interaction.setFailureMessage(Literal1, "select a user first");
            return;
        }
        if (!(Interaction.LoggedInUser is Admin))
        {
            Interaction.redirUnauthorize();
        }
        Admin a = (Admin)Interaction.LoggedInUser;
        User toEdit = new User(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text), GridView1.SelectedRow.Cells[2].Text, GridView1.SelectedRow.Cells[3].Text,
            Convert.ToInt32(GridView1.SelectedRow.Cells[4].Text), GridView1.SelectedRow.Cells[5].Text, GridView1.SelectedRow.Cells[6].Text, GridView1.SelectedRow.Cells[7].Text,
            GridView1.SelectedRow.Cells[8].Text);
        if (toEdit == null)
        {
            Interaction.setFailureMessage(Literal1, "information mismatch:");
            return;
        }
        else if (toEdit.UserNumber == a.UserNumber)
        {
            toEdit = a;
        }
        Session["toEdit"] = toEdit;
        Response.Redirect("edituser2.aspx");
        //SqlDataSource1.SelectCommand = "SELECT * FROM [user] ";
    }
}
