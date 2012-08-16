using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personalinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        curPassGood.IsValid = true;
        //Response.Write("point1");
        updateSuccessLbl.Visible = false;
        if (!Page.IsPostBack)
        {
            firstNameTxt.Text = Interaction.LoggedInUser.FirstName;
            lastNameTxt.Text = Interaction.LoggedInUser.LastName;
            phoneTxt.Text = Interaction.LoggedInUser.PhoneNumber;
            addressTxt.Text = Interaction.LoggedInUser.Address;
        }
    }
    protected void updateBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        Interaction.LoggedInUser.updateInfo(firstNameTxt.Text, lastNameTxt.Text, phoneTxt.Text, addressTxt.Text);
        updateSuccessLbl.Visible = true;
    }
    protected void updatePassBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        bool success=Interaction.LoggedInUser.updatePass(currentTxt.Text, newPassTxt.Text);
        //Response.Write("point2");
        if (!success)
        {
            curPassGood.IsValid = false;
        }
        else
        {
            Interaction.setSuccessMessage(passSuccess,"password update success");
        }
    }
}
