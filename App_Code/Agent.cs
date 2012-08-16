using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;

    public class Agent : User
    {
        public Agent(int theUserNum, string theAddress, string theFirstName, int theFlag, string theLastName, string thePassword, string thePhoneNumber, string theUserName):
            base(theUserNum, theAddress, theFirstName, theFlag, theLastName, thePassword, thePhoneNumber, theUserName)
        {

        }

        public void editUser(User userToEdit, string oldLastName, string oldUsername, string newFirstName, string newLastName, string newPhone, string newAddress)
        {
            userToEdit.updateInfo(newFirstName, newLastName, newPhone, newAddress);
        }
        public void exchangeFlight(User first, User second)
        {
            //int userNumber1;
            //int userNumber2;
            SqlConnection conn = Interaction.DbConnection;
            conn.Open();
            if (first.TheTicket == null) throw new Exception("first user has no flight booked");
            if (second.TheTicket == null) throw new Exception("second user has no flight booked");
            if (first.TheTicket.TheFlight.FlightNumber == second.TheTicket.TheFlight.FlightNumber) throw new Exception("both user have same flight booked");
            try{
                SqlCommand updateTicketCmd = new SqlCommand(@"update [ticket] set flightNumber=@flightNumber2
                                                             where userNumber=@userNumber1;
                                                             update [ticket] set flightNumber=@flightNumber1
                                                             where userNumber=@userNumber2;", conn);
                updateTicketCmd.Parameters.AddWithValue("@flightNumber2", second.TheTicket.TheFlight.FlightNumber);
                updateTicketCmd.Parameters.AddWithValue("@userNumber1", first.UserNumber);
                updateTicketCmd.Parameters.AddWithValue("@flightNumber1", first.TheTicket.TheFlight.FlightNumber);
                updateTicketCmd.Parameters.AddWithValue("@userNumber2", second.UserNumber);
                updateTicketCmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            Flight temp = first.TheTicket.TheFlight;
            first.TheTicket.TheFlight = second.TheTicket.TheFlight;
            second.TheTicket.TheFlight = temp;
        }
        public User getUser(string theFirstName, string theLastName, string theUserName)
        {
            SqlConnection conn = Interaction.DbConnection;
            conn.Open();
            try
            {
                SqlCommand firstCommand = new SqlCommand(@"select * from [user] where firstName=@firstName1 and lastName=@lastName1 and userName=@userName1", conn);
                firstCommand.Parameters.AddWithValue("@firstName1", theFirstName);
                firstCommand.Parameters.AddWithValue("@lastName1", theLastName);
                firstCommand.Parameters.AddWithValue("@userName1", theUserName);
                SqlDataReader r = firstCommand.ExecuteReader();
                if (r.Read())
                {
                    int theFlag=Convert.ToInt32(r["flag"]);
                    if (!(this is Admin) && theFlag == Interaction.ADMINFLAG)
                    {
                        throw new Exception("non-admin user can't access admin info");
                    }
                    User ret=new User(Convert.ToInt32(r["userNumber"]),
                            (string)r["address"],
                            (string)r["firstName"],
                             theFlag,
                            (string)r["lastName"],
                            (string)r["password"],
                            (string)r["phoneNumber"],
                            (string)r["userName"]);
                    r.Close();
                    return ret;
                    //userNumber1 = Convert.ToInt32(rd1[0]);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                conn.Close();
            }
            //return null;
        }
    }
