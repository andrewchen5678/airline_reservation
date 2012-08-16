using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //userExistsLbl.Visible = false;
    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        try
        {
            Interaction.register(addressTxt.Text, firstNameTxt.Text, lastNameTxt.Text, passTxt.Text, phoneTxt.Text, usernameTxt.Text);
            if (Request.QueryString["redir"] != null && Request.QueryString["redir"] != "")
            {
                Response.Redirect("login.aspx?redir="+Request.QueryString["redir"]+"&regsuccess=1");
            }
            else
            {
                Response.Redirect("login.aspx?regsuccess=1");
            }
        }
        catch (UserAlreadyExistsException ex)
        {
            userExistsValidate.ErrorMessage = "user " + ex.UserName + " already exists";
            userExistsValidate.IsValid=false;
        }
    }
    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["redir"] != null && Request.QueryString["redir"] != "")
        {
            Response.Redirect(Request.QueryString["redir"]);
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}
