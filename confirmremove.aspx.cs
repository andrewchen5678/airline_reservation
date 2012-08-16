using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confirmremove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        if (!Page.IsPostBack)
        {
            ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
        }
        if(Session["userDel"]==null) Response.Redirect("removeaccount.aspx"); //no user to remove
        User u = (User)Session["userDel"];
        if (u.TheTicket == null) Label1.Text = "user has no flight booked, continue to remove?";
        else Label1.Text = "still has flight booked, continue to remove?";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        User u = (User)Session["userDel"];
        Admin a = (Admin)Interaction.LoggedInUser;
        try
        {
            a.removeUser(u);
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
            return;
        }
        //Literal1.Text = "<script language=\"javascript\">alert('account removed');</script>";
        Response.Redirect("removeaccount.aspx?success=1");
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        if(ViewState["ReferrerUrl"]!=null) Response.Redirect(ViewState["ReferrerUrl"].ToString());
        else { Response.Redirect("removeaccount.aspx"); }
    }
}
