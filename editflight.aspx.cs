using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class editflight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        deptDateTxt.Attributes.Add("readonly", "readonly");
        arrivDateTxt.Attributes.Add("readonly", "readonly");
        if (Session["flightEdit"] == null) 
        {
            Response.Redirect("searchandbook.aspx");
        }
        Flight f = (Flight)Session["flightEdit"];
        if (!Page.IsPostBack)
        {
            FlightNumberLbl.Text = f.FlightNumber+"";
            originTxt.Text = f.Origin;
            destTxt.Text = f.Destination;
            deptDateTxt.Text = f.DepartureDateTime.Date.ToString("MM/dd/yyyy");
            arrivDateTxt.Text = f.ArrivalDateTime.Date.ToString("MM/dd/yyyy");
            hour1.SelectedIndex = f.DepartureDateTime.Hour%12;
            minute1.SelectedIndex = f.DepartureDateTime.Minute/15;
            ampm1.SelectedIndex = f.DepartureDateTime.Hour / 12;
            hour2.SelectedIndex = f.ArrivalDateTime.Hour % 12;
            minute2.SelectedIndex = f.ArrivalDateTime.Minute / 15;
            ampm2.SelectedIndex = f.ArrivalDateTime.Hour / 12;
            openSeatTxt.Text = f.OpenSeats+"";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchandbook.aspx?editremove=1");
    }
    protected void editBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["flightEdit"] == null)
            {
                Response.Redirect("searchandbook.aspx");
            }
            DateTime deptdate = new DateTime();
            DateTime deptdtime = new DateTime();
            DateTime arrivaldate = new DateTime();
            DateTime arrivaldtime = new DateTime();
            String DateTimeFormat = "MM/dd/yyyy";
            deptdate = DateTime.ParseExact(deptDateTxt.Text, DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            deptdtime = new DateTime(deptdate.Year, deptdate.Month, deptdate.Day, Convert.ToInt32(hour1.SelectedValue) + Convert.ToInt32(ampm1.SelectedValue),
                Convert.ToInt32(minute1.SelectedValue),0);
            arrivaldate = DateTime.ParseExact(arrivDateTxt.Text, DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            arrivaldtime = new DateTime(arrivaldate.Year, arrivaldate.Month, arrivaldate.Day, Convert.ToInt32(hour2.SelectedValue) + Convert.ToInt32(ampm2.SelectedValue),
                Convert.ToInt32(minute2.SelectedValue), 0);
            Flight f = (Flight)Session["flightEdit"];
            f.editFlight(originTxt.Text, destTxt.Text, deptdtime, arrivaldtime, Convert.ToInt32(openSeatTxt.Text));
            Interaction.setSuccessMessage(Literal1, "Edit successful");
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
        }
    }
}
