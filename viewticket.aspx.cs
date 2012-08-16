using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewticket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Panel1.Visible = ifThereTicket.IsValid;
        Interaction.redirIfNotLoggedIn();
        Ticket t=Interaction.LoggedInUser.TheTicket;
        if (t == null)
        {
            //Response.Write("no ticket available");
            ifThereTicket.IsValid = false;
            Panel1.Visible = false;
        }
        else
        {
            ifThereTicket.IsValid = true;
            Panel1.Visible = true;
            ticketNo.Text = t.TicketNumber+"";
            userName.Text = t.TheUser.UserName;
            flightNo.Text = t.TheFlight.FlightNumber + "";
            ori.Text = t.TheFlight.Origin;
            dst.Text = t.TheFlight.Destination;
            deptdt.Text = t.TheFlight.DepartureDateTime.ToString();
            arrivdt.Text = t.TheFlight.ArrivalDateTime.ToString();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        bool cancelled=Interaction.LoggedInUser.cancelBooking();
        if (!cancelled)
        {
            Interaction.setFailureMessage(Literal1, "nothing to cancel");
        }
        else
        {
            Interaction.setSuccessMessage(Literal1, "cancel successful");
            ifThereTicket.IsValid = false;
            Panel1.Visible = false;
            //Response.Redirect(Request.Path);
        }
    }
}
