using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection dbConnection = Interaction.DbConnection;
        try
        {
            dbConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) FROM [user];", dbConnection);
            //SqlDataReader myReader = myCommand.ExecuteReader();
            //myReader.Read();
            int totalUserRows = (Int32)myCommand.ExecuteScalar();
            //myReader.Close();
            Console.WriteLine(totalUserRows);
            if (totalUserRows <= 0)
            {
                Response.Write("no user exists yet, creating default admin user with password admin and default info...");
                SqlCommand createCommand = new SqlCommand(@"INSERT INTO [user]
                       ([address]
                       ,[firstName]
                       ,[flag]
                       ,[lastName]
                       ,[password]
                       ,[phoneNumber]
                       ,[userName])
                 VALUES
                       ('addr1'
                       ,'adminfirst'
                       ,@flag
                       ,'adminlast'
                       ,@password
                       ,1234567890
                       ,'admin')", dbConnection);
                createCommand.Parameters.AddWithValue("@flag", Interaction.ADMINFLAG);
                createCommand.Parameters.AddWithValue("@password", Interaction.MD5SUM("admin"));
                //+Interaction.ADMINFLAG+
                //+ Interaction.MD5SUM("admin") +
                createCommand.ExecuteNonQuery();
                Response.Write("<br />success...<a href=\"javascript:window.location.reload();\">click here to continue...</a>");
                Response.End();
            }
            //}
            //catch (SqlException ex)
            //{
            //    Response.Write(ex.ToString());
            //    Response.End();
            //}
        }
        finally
        {
            dbConnection.Close();
        }
        if (!Page.IsPostBack && Request.QueryString["regsuccess"] == "1")
        {
            regsuccessLbl.Visible = true;
        }
        else
        {
            regsuccessLbl.Visible = false;
        }
        //errLabel.Text = "";
        //if (Session["user"] != null)
        //{
        //    redir();
        //}
    }

    private void redir()
    {
        if (Request.QueryString["redir"] != null && Request.QueryString["redir"] != "")
        {
            Response.Redirect(Request.QueryString["redir"]);
        }
        else
        {
            Response.Redirect("searchandbook.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        //if (Request.QueryString["regsuccess"] != null) Request.QueryString["regsuccess"] = null;
        if (!Page.IsValid) return;
        //if (userNameTxt.Text.Length == 0 || passTxt.Text.Length == 0)
        //{
        //    return;
        //}
        else
        {
            try
            {
                Session["user"] = Interaction.login(userNameTxt.Text, passTxt.Text);
                redir();
            }
            catch (LoginException ex)
            {
                showError(ex.Message);
            }
        }
    }

    private void showError(string errmsg)
    {
        //errLabel.Visible = true;
        //errLabel.Text += (errmsg);
        CustomValidator1.ErrorMessage = errmsg;
        CustomValidator1.IsValid = false;
    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["redir"] != null && Request.QueryString["redir"] != "")
        {
            Response.Redirect("register.aspx?redir=" + Request.QueryString["redir"]);
        }
        else
        {
            Response.Redirect("register.aspx");
        }
    }
}
