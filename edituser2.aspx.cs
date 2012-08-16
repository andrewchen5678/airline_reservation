using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edituser2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = "";
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Agent)) Interaction.redirUnauthorize();
        if(Session["toEdit"]==null) Response.Redirect("edituser.aspx");
        User toEdit = (User)Session["toEdit"];
        if (!Page.IsPostBack)
        {
            Label1.Text = toEdit.UserName;
            newAddressTxt.Text = toEdit.Address;
            newFirstTxt.Text = toEdit.FirstName;
            newLastTxt.Text = toEdit.LastName;
            newPhoneTxt.Text = toEdit.PhoneNumber;
        }
    }
    protected void updateBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        if (Session["toEdit"] == null)
        {
            Response.Redirect("edituser.aspx");
            return;
        }
        else
        {
            try
            {
                ((User)Session["toEdit"]).updateInfo(newFirstTxt.Text, newLastTxt.Text, newPhoneTxt.Text, newAddressTxt.Text);
                Interaction.setSuccessMessage(Literal1, "update successful");
            }
            catch (Exception ex)
            {
                Interaction.setFailureMessage(Literal1, ex.Message);
            }
        }
    }
    protected void finishBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("edituser.aspx");
    }
}
