using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addagent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        if (!Page.IsValid) return;
        Admin ad = (Admin)Interaction.LoggedInUser;
        try
        {
            ad.addAgent(addressTxt.Text, firstNameTxt.Text, lastNameTxt.Text, passTxt.Text, phoneTxt.Text, usernameTxt.Text);
            Interaction.setSuccessMessage(Literal1, "agent added");
        }
        catch (UserAlreadyExistsException ex)
        {
            userExistsValidate.ErrorMessage = "user " + ex.UserName + " already exists";
            userExistsValidate.IsValid = false;
        }
    }
}
