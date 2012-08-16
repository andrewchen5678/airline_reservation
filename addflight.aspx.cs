using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class addflight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        deptDateTxt.Attributes.Add("readonly", "readonly");
        arrivDateTxt.Attributes.Add("readonly", "readonly");
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        if (!(Interaction.LoggedInUser is Admin)) Interaction.redirUnauthorize();
        if (!Page.IsValid) return;
        Admin ad = (Admin)Interaction.LoggedInUser;
        DateTime deptdate = new DateTime();
        DateTime deptdtime = new DateTime();
        DateTime arrivaldate = new DateTime();
        DateTime arrivaldtime = new DateTime();
        string origin = originTxt.Text;
        string destination = destTxt.Text;
        int openseats=0;
        try
        {
            String DateTimeFormat = "MM/dd/yyyy";
            //DateTime.ParseExact("05-12-2008", DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            deptdate = DateTime.ParseExact(deptDateTxt.Text, DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            deptdtime = new DateTime(deptdate.Year, deptdate.Month, deptdate.Day, Convert.ToInt32(hour1.SelectedValue) + Convert.ToInt32(ampm1.SelectedValue),
                Convert.ToInt32(minute1.SelectedValue),0);
            arrivaldate = DateTime.ParseExact(arrivDateTxt.Text, DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            arrivaldtime = new DateTime(arrivaldate.Year, arrivaldate.Month, arrivaldate.Day, Convert.ToInt32(hour2.SelectedValue) + Convert.ToInt32(ampm2.SelectedValue),
                Convert.ToInt32(minute2.SelectedValue), 0);
            openseats = Convert.ToInt32(openSeatTxt.Text);
        }
        catch (FormatException ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
            return;
        }
            //ad.addFlight(origin, destination, deptdate, depttime, arrivaldate, arrivaltime, openseats);
        try
        {
            ad.addFlight(origin, destination, deptdtime, arrivaldtime, openseats);
            Interaction.setSuccessMessage(Literal1, "flight added");
        }
        catch (Exception ex)
        {
            Interaction.setFailureMessage(Literal1, ex.Message);
        }
    }
}
