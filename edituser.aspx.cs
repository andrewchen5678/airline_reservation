using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class edituser : System.Web.UI.Page
{
    //User toEdit;
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Agent)) Interaction.redirUnauthorize();
        Literal2.Text = "";
        if (!Page.IsPostBack) Session["toEdit"] = null;
        //if (Interaction.LoggedInUser is Admin) Response.Redirect("edituseradmin.aspx");
        User toEdit = (User)Session["toEdit"];
        //if (toEdit == null) Panel1.Visible = false;
    }
    protected void searchUserBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        if (!(Interaction.LoggedInUser is Agent))
        {
            Interaction.redirUnauthorize();
        }
        Agent a = (Agent)Interaction.LoggedInUser;
        try
        {
            User toEdit = a.getUser(firstNameTxt.Text, lastNameTxt.Text, userNameTxt.Text);
            if (toEdit == null)
            {
                Interaction.setFailureMessage(Literal2, "information mismatch:");
                return;
            }
            else if (toEdit.UserNumber == a.UserNumber)
            {
                toEdit = a;
            }
            Session["toEdit"] = toEdit;
            Response.Redirect("edituser2.aspx");
            //Panel1.Visible = true;
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal2, ex.Message);
        }
    }
    protected void updateBtn_Click(object sender, EventArgs e)
    {

    }
}
