using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

public partial class Interaction : System.Web.UI.Page
{
    //private static SqlConnection dbConnection;


    public const int USERFLAG = 0;
    public const int AGENTFLAG = 1;
    public const int ADMINFLAG = 2;

    public static SqlConnection DbConnection
    {
        get
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["airlineConnectionString"].ConnectionString);
        }
    }

    public static User LoggedInUser
    {
        get
        {
            return (User)HttpContext.Current.Session["user"];
        }
        set
        {
            HttpContext.Current.Session["user"] = value;
        }
    }

    //static User theUser;

    //public static void initDatabase()
    //{
        //dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["airlineConnectionString"].ConnectionString);
        //try
        //{
        //    dbConnection.Open();
        //    SqlCommand myCommand = new SqlCommand("SELECT count(*) FROM [user];", dbConnection);
        //    SqlDataReader myReader = myCommand.ExecuteReader();
        //    myReader.Read();
        //    int totalUserRows = myReader.GetInt32(0);
        //    Console.WriteLine(totalUserRows);
        //    if (totalUserRows <= 0)
        //    {
        //        Response.Write("no user exists yet");
        //    }
        //}
        //catch (SqlException e)
        //{
        //    Response.Write(e.ToString());
        //    Response.End();
        //    return false;
        //}
        //return true;
    //}
    public static void register(string address, string firstName, string lastName, string password, string phoneNumber, string userName)
    {
        addUser(address, firstName, lastName, password, phoneNumber, userName, USERFLAG);
    }
    public static void addUser(string address, string firstName, string lastName, string password, string phoneNumber, string userName,int flag)
    {
        SqlConnection conn = DbConnection;
        try
        {
            conn.Open();
            SqlCommand checkCommand = new SqlCommand("select count(*) from [user] where userName=@userName", conn);
            checkCommand.Parameters.AddWithValue("@userName", userName);
            //SqlDataReader rd = checkCommand.ExecuteReader();
            //rd.Read();
            //int userCount=rd.GetInt32(0);
            //rd.Close();
            int userCount = (Int32)checkCommand.ExecuteScalar();
            if (userCount > 0)
            {
                throw new UserAlreadyExistsException(userName);
            }
            SqlCommand createCommand = new SqlCommand(@"INSERT INTO [user]
                   ([address]
                   ,[firstName]
                   ,[flag]
                   ,[lastName]
                   ,[password]
                   ,[phoneNumber]
                   ,[userName])
             VALUES
                   (@address
                   ,@firstName
                   ,@flag
                   ,@lastName
                   ,@password
                   ,@phoneNumber
                   ,@userName)", conn);
            createCommand.Parameters.AddWithValue("@address", address);
            createCommand.Parameters.AddWithValue("@firstName", firstName);
            createCommand.Parameters.AddWithValue("@flag", flag);
            createCommand.Parameters.AddWithValue("@lastName", lastName);
            createCommand.Parameters.AddWithValue("@password", MD5SUM(password));
            createCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            createCommand.Parameters.AddWithValue("@userName", userName);
            createCommand.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
    }

    public static void redirUnauthorize()
    {
        HttpContext.Current.Response.Redirect("unauthorized.aspx");
    }

    public static void setSuccessMessage(Literal l, string message)
    {
        l.Text = string.Format(@"<span style='background-color:#00ff00'>{0}</span><br/>", message);
    }

    public static void setFailureMessage(Literal l, string message)
    {
        l.Text = string.Format(@"<span style='background-color:#ff0000'>{0}</span><br/>", message);
    }

    public static User login(string userName, string password)
    {
        //int errCode = 0;
        User ret = null;
        SqlConnection dbConnection = Interaction.DbConnection;
        try
        {
            dbConnection.Open();
            SqlCommand myCommand2 = new SqlCommand("SELECT * FROM [user] where username=@userName", dbConnection);
            myCommand2.Parameters.AddWithValue("@userName", userName);
                SqlDataReader r = myCommand2.ExecuteReader();
                if (!r.Read())
                {
                    //username not found
                    throw new LoginException(1);
                    
                }
                else if (Interaction.MD5SUM(password) != (string)r["password"])
                {
                    //invalid password
                    throw new LoginException(2);
                }
                else
                {
                    int flag=Convert.ToInt32(r["flag"]);
                    if (flag == USERFLAG)
                    {
                        ret = new User(Convert.ToInt32(r["userNumber"]),
                            (string)r["address"],
                            (string)r["firstName"],
                            flag,
                            (string)r["lastName"],
                            (string)r["password"],
                            (string)r["phoneNumber"],
                            (string)r["userName"]);
                    }
                    else if (flag == AGENTFLAG)
                    {
                        ret = new Agent(Convert.ToInt32(r["userNumber"]),
                            (string)r["address"],
                            (string)r["firstName"],
                            flag,
                            (string)r["lastName"],
                            (string)r["password"],
                            (string)r["phoneNumber"],
                            (string)r["userName"]);
                    }
                    else if (flag == ADMINFLAG)
                    {
                        ret = new Admin(Convert.ToInt32(r["userNumber"]),
                        (string)r["address"],
                        (string)r["firstName"],
                        flag,
                        (string)r["lastName"],
                        (string)r["password"],
                        (string)r["phoneNumber"],
                        (string)r["userName"]);
                    }
                }
        }
        finally
        {
            dbConnection.Close();
        }
        return ret;
    }
    //public User[] getUserListDB(string firstName, string lastName, string phoneNumber, string userName)
    //{
    //}
    //public SqlConnection getDBConnection()
    //{
    //}
    public static string MD5SUM(string text)
    {
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        return BitConverter.ToString(new
            MD5CryptoServiceProvider().ComputeHash(encoding.GetBytes(text))).Replace("-", "").ToLower();
    }

    public static void redirIfNotLoggedIn()
    {
        if (HttpContext.Current.Session["user"] == null)
        {
            HttpContext.Current.Response.Redirect("login.aspx?redir=" + HttpContext.Current.Request.Url.PathAndQuery);
        }
    }

    //public static void logout()
    //{
    //    Response.Redirect("logout.aspx?redir=" + Request.Url.PathAndQuery);
    //}

}

public class LoginException : Exception
{
    public const int USERNOTFOUND=1;
    public const int INVALIDPASSWORD = 2;
    private int errCode = 0;
    public int ErrorCode
    {
        get
        {
            return errCode;
        }
    }
    public override string Message
    {
        get
        {
            if (ErrorCode == USERNOTFOUND) return "username not found";
            else if (ErrorCode == INVALIDPASSWORD) return "invalid password";
            else return "unknown login error";
        }
    }
    public LoginException(int theErrCode)
    {
        errCode = theErrCode;
    }
}

public class UserAlreadyExistsException : Exception{
    private string userName;
    public string UserName
    {
        get
        {
            return userName;
        }
    }    
    public UserAlreadyExistsException(string name)
    {
        userName = name;
    }
}