using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exchangeflight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Agent))
        {
            Interaction.redirUnauthorize();
        }
        Literal1.Text = "";
        Literal2.Text = "";
    }
    protected void exchangeBtn_Click(object sender, EventArgs e)
    {
        if (!(Interaction.LoggedInUser is Agent))
        {
            Interaction.redirUnauthorize();
        }
        if (!Page.IsValid) return;
        Agent a = (Agent)Interaction.LoggedInUser;
        User first=a.getUser(firstNameTxt.Text, lastNameTxt.Text, userNameTxt.Text);
        if (first == null)
        {
            Interaction.setFailureMessage(Literal1,"first user information mismatch");
            return;
            //throw new UserException("first user information mismatch");
        }
        User second=a.getUser(first2.Text, last2.Text, username2.Text);
        if (second == null)
        {
            Interaction.setFailureMessage(Literal2, "<br />second user information mismatch");
            return;
            //throw new UserException("second user information mismatch");
        }
        if (first.TheTicket == null)
        {
            Interaction.setFailureMessage(Literal1, "first user has no flight booked");
            return;
        }
        else if (second.TheTicket == null)
        {
            Interaction.setFailureMessage(Literal2, "second user has no flight booked");
            return;
        }
        Session["firstExchange"] = first.TheTicket;
        Session["secondExchange"] = second.TheTicket;
        Response.Redirect("exchange2.aspx");
    }
}
