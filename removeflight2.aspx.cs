using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class removeflight2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        if (!Page.IsPostBack)
        {
            ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
        }
        if (Session["flightRemove"] == null) Response.Redirect("searchandbook.aspx"); //no flight to remove
        Flight f = (Flight)Session["flightRemove"];
        if (f.TicketCount == 0) Label1.Text = "flight has not been booked yet, continue to remove?";
        else Label1.Text = "flight still booked, continue to remove?";
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        if (ViewState["ReferrerUrl"] != null) Response.Redirect(ViewState["ReferrerUrl"].ToString());
        else { Response.Redirect("searchandbook.aspx"); }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Flight f = (Flight)Session["flightRemove"];
        Admin a = (Admin)Interaction.LoggedInUser;
        try
        {
            a.removeFlight(f);
            //Literal1.Text = "<script language='javascript'>alert('Flight removed');</script>";
            Response.Redirect("searchandbook.aspx?removesuccess=1?editremove=1");
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
        }

    }
}
