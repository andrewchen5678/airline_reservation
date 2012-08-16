using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exchange2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Agent))
        {
            Interaction.redirUnauthorize();
        }
        if (!Page.IsPostBack)
        {
            Ticket t1 = (Ticket)Session["firstExchange"];
            Ticket t2 = (Ticket)Session["secondExchange"];
            if (t1 == null || t2 == null)
            {
                Response.Write("need two tickets to exchange");
                Response.End();
            }
            updateTicketDisplay(t1, t2);
        }
    }
    protected void exchangeBtn_Click(object sender, EventArgs e)
    {
        if (!(Interaction.LoggedInUser is Agent))
        {
            Interaction.redirUnauthorize();
        }
        if (!Page.IsValid) return;
        Agent a = (Agent)Interaction.LoggedInUser;
        try
        {
            Ticket first = (Ticket)Session["firstExchange"];
            Ticket second = (Ticket)Session["secondExchange"];
            a.exchangeFlight(first.TheUser, second.TheUser);
            Interaction.setSuccessMessage(Literal1, "exchange successful");
            updateTicketDisplay(first, second);
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
        }
    }

    private void updateTicketDisplay(Ticket t1,Ticket t2)
    {
        ticketNo.Text = t1.TicketNumber + "";
        userName.Text = t1.TheUser.UserName;
        flightNo.Text = t1.TheFlight.FlightNumber + "";
        ori.Text = t1.TheFlight.Origin;
        dst.Text = t1.TheFlight.Destination;
        deptdt.Text = t1.TheFlight.DepartureDateTime.ToString();
        arrivdt.Text = t1.TheFlight.ArrivalDateTime.ToString();

        ticketNo0.Text = t2.TicketNumber + "";
        userName0.Text = t2.TheUser.UserName;
        flightNo0.Text = t2.TheFlight.FlightNumber + "";
        ori0.Text = t2.TheFlight.Origin;
        dst0.Text = t2.TheFlight.Destination;
        deptdt0.Text = t2.TheFlight.DepartureDateTime.ToString();
        arrivdt0.Text = t2.TheFlight.ArrivalDateTime.ToString();
    }
}
