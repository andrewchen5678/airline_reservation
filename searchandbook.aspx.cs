using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Diagnostics;

public partial class mainmenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Interaction.redirIfNotLoggedIn();
        if (!Page.IsPostBack) Session["flightEdit"] = null;
        if (Request["removesuccess"] == "1")
        {
            Interaction.setSuccessMessage(Literal3, "flight removed");
        }
        else
        {
            Literal3.Text = "";
        }

        if (Request["editremove"] != "1")
        {
            editBtn.Visible = false;
            removeBtn.Visible = false;
        }
        else if (!(Interaction.LoggedInUser is Admin))
        {
            Interaction.redirUnauthorize();
        }
        if (!(Interaction.LoggedInUser is Admin))
        {
            editBtn.Enabled = false;
            removeBtn.Enabled = false;
        }
        //GridView1.DataSourceID = "";
        deptDateTxt.Attributes.Add("readonly", "readonly");
        arrivDateTxt.Attributes.Add("readonly", "readonly");
    }
    protected void bookBtn_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex < 0)
        {
            selectValidate.IsValid = false;
            return;
        }
        if (!Page.IsValid)
        {
            return;
        }
        else
        {
            GridViewRow row = GridView1.SelectedRow;
            //Response.Write(string.Format("{0},{1},{2},{3},{4},{5}", row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text,
            //    row.Cells[4].Text,row.Cells[5].Text));
            //GridViewRow h = GridView1.HeaderRow;
            Flight f = new Flight(Convert.ToInt32(row.Cells[1].Text), row.Cells[2].Text,
                row.Cells[3].Text, Convert.ToDateTime(row.Cells[4].Text), Convert.ToDateTime(row.Cells[5].Text));
            try
            {
                Interaction.LoggedInUser.book(f);
                Interaction.setSuccessMessage(Literal1, "Book Successful");
            }
            catch (Exception ex)
            {
                Interaction.setFailureMessage(Literal1, ex.Message);
            }
            GridView1.DataBind();
            //Ticket t = new Ticket(Interaction.LoggedInUser, f);
        }
    }

    //protected int getCellIndex(GridViewRow headerRow, String ColumnName)
    //{
    //    for (int i = 0; i < headerRow.Cells.Count; i++)
    //    {
    //        if (headerRow.Cells[i].Text.ToLower().Equals(ColumnName.ToLower()))
    //            return i;
    //    }
    //    return -1;
    //}

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        String DateTimeFormat = "MM/dd/yyyy";
        DateTime deptdate = DateTime.ParseExact(deptDateTxt.Text, DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
        //DateTime deptdtime = new DateTime(deptdate.Year, deptdate.Month, deptdate.Day, Convert.ToInt32(hour1.SelectedValue) + Convert.ToInt32(ampm1.SelectedValue),
        //    Convert.ToInt32(minute1.SelectedValue), 0);
        DateTime deptdate2=new DateTime();
        if(CheckBox1.Checked) deptdate2 = DateTime.ParseExact(arrivDateTxt.Text, DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
        //DateTime arrivaldtime = new DateTime(arrivaldate.Year, arrivaldate.Month, arrivaldate.Day, Convert.ToInt32(hour2.SelectedValue) + Convert.ToInt32(ampm2.SelectedValue),
        //    Convert.ToInt32(minute2.SelectedValue), 0);
        ObjectDataSource1.SelectParameters.Clear();
        ObjectDataSource1.SelectParameters.Add("ori", originTxt.Text);
        ObjectDataSource1.SelectParameters.Add("dst", destTxt.Text);
        //ObjectDataSource1.SelectParameters.Add("deptdt", TypeCode.DateTime, deptdtime.ToString());
        //ObjectDataSource1.SelectParameters.Add("arridt", TypeCode.DateTime, arrivaldtime.ToString());
        ObjectDataSource1.SelectParameters.Add("deptdt", TypeCode.DateTime, deptdate.ToString());
        if(CheckBox1.Checked) ObjectDataSource1.SelectParameters.Add("deptdt2", TypeCode.DateTime, deptdate2.ToString());
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            Interaction.setFailureMessage(Literal2, "no result found");
            Panel2.Visible = false;
        }
        else
        {
            Panel2.Visible = true;
        }
    }
    //protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    //{
    //    User u = Interaction.LoggedInUser;
    //    e.InputParameters.Add("account", dealer.Account);
    //}
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = Interaction.LoggedInUser;
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            betweenPanel.Visible = true;
        }
        else
        {
            betweenPanel.Visible = false;
        }
    }
    protected void editBtn_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex < 0)
        {
            selectValidate.IsValid = false;
            return;
        }
        if (!Page.IsValid)
        {
            return;
        }
        //GridView1.DataBind();
        Session["flightEdit"]=new Flight(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text),GridView1.SelectedRow.Cells[2].Text,
            GridView1.SelectedRow.Cells[3].Text, Convert.ToDateTime(GridView1.SelectedRow.Cells[4].Text), Convert.ToDateTime(GridView1.SelectedRow.Cells[5].Text));
        Response.Redirect("editflight.aspx");
    }
    protected void removeBtn_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex < 0)
        {
            selectValidate.IsValid = false;
            return;
        }
        if (!Page.IsValid)
        {
            return;
        }
        Session["flightRemove"] = new Flight(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text), GridView1.SelectedRow.Cells[2].Text,
                    GridView1.SelectedRow.Cells[3].Text, Convert.ToDateTime(GridView1.SelectedRow.Cells[4].Text), Convert.ToDateTime(GridView1.SelectedRow.Cells[5].Text));
        Response.Redirect("removeflight2.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (GridView1.SelectedIndex<0) return;
        //Debug.WriteLine(GridView1.SelectedIndex);
        //Flight f = (Flight)GridView1.SelectedRow.DataItem;
        //Session["flightEdit"] = f;
    }
    protected void ObjectDataSource1_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
    {

    }
}
