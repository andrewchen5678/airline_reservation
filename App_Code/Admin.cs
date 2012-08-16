using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;

    public class Admin : Agent
    {

        public Admin(int theUserNum, string theAddress, string theFirstName, int theFlag, string theLastName, string thePassword, string thePhoneNumber, string theUserName):
            base(theUserNum, theAddress, theFirstName, theFlag, theLastName, thePassword, thePhoneNumber, theUserName)
        {
             
        }

        // Operations:

        /** Operations:
         * Operations: */
        public void addAgent(string address, string firstName, string lastName, string password, string phoneNumber, string userName)
        {
            Interaction.addUser(address, firstName, lastName, password, phoneNumber, userName, Interaction.AGENTFLAG);
        }
        public void addFlight(string ori, string dst, DateTime deptdt, DateTime arridt, int os)
        {
            //DateTime deptdatetime = new DateTime(deptd.Year, deptd.Month, deptd.Day, deptt.Hour, deptt.Minute, deptt.Second);
            //DateTime arrivdatetime = new DateTime(arrid.Year, arrid.Month, arrid.Day, arrit.Hour, arrit.Minute, arrit.Second);
            if (deptdt > arridt) throw new Exception("departure time can't be greater than arrival time");
            //deptdatetime. = deptt.TimeOfDay;
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand checkCommand = new SqlCommand(@"select count(*) from [flight] 
                            where origin=@ori and destination=@dst and departureDateTime=@ddatetime
                            and arrivalDateTime=@arrivDateTime", conn);
                checkCommand.Parameters.AddWithValue("@ori", ori);
                checkCommand.Parameters.AddWithValue("@dst", dst);
                checkCommand.Parameters.AddWithValue("@ddatetime", deptdt);
                //checkCommand.Parameters.AddWithValue("@dtime", deptt.TimeOfDay);
                checkCommand.Parameters.AddWithValue("@arrivdatetime", arridt);
                //checkCommand.Parameters.AddWithValue("@arrivtime", arrit);
                //checkCommand.Parameters.AddWithValue("@openseats", os);
                int flightCount = (Int32)checkCommand.ExecuteScalar();
                if (flightCount > 0)
                {
                    throw new Exception("flight already exists");
                }
                SqlCommand createCommand = new SqlCommand(@"INSERT INTO [flight]
                   ([origin]
                   ,[destination]
                   ,[departureDateTime]
                   ,[arrivalDateTime]
                   ,[openSeats])
             VALUES
                   (@ori
                   ,@dst
                   ,@ddatetime
                   ,@arrivdatetime
                   ,@openseats)", conn);
                createCommand.Parameters.AddWithValue("@ori", ori);
                createCommand.Parameters.AddWithValue("@dst", dst);
                createCommand.Parameters.AddWithValue("@ddatetime", deptdt);
                //createCommand.Parameters.AddWithValue("@dtime", deptt);
                createCommand.Parameters.AddWithValue("@arrivdatetime", arridt);
                //createCommand.Parameters.AddWithValue("@arrivtime", arrit);
                createCommand.Parameters.AddWithValue("@openseats", os);
                //Console.Error.WriteLine(createCommand.ToString());
                createCommand.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

//        public void exchangeFlight(User first, User second)
//        {
//            SqlConnection conn = Interaction.DbConnection;
//            conn.Open();
//            if (first.TheTicket == null) throw new Exception("first user has no flight booked");
//            if (second.TheTicket == null) throw new Exception("second user has no flight booked");
//            if (first.TheTicket.TheFlight.FlightNumber == second.TheTicket.TheFlight.FlightNumber) throw new Exception("both user have same flight booked");
//            try
//            {
//                SqlCommand updateTicketCmd = new SqlCommand(@"update [ticket] set flightNumber=@flightNumber2
//                                                             where userNumber=@userNumber1;
//                                                             update [ticket] set flightNumber=@flightNumber1
//                                                             where userNumber=@userNumber2;", conn);
//                updateTicketCmd.Parameters.AddWithValue("@flightNumber2", second.TheTicket.TheFlight.FlightNumber);
//                updateTicketCmd.Parameters.AddWithValue("@userNumber1", first.UserNumber);
//                updateTicketCmd.Parameters.AddWithValue("@flightNumber1", first.TheTicket.TheFlight.FlightNumber);
//                updateTicketCmd.Parameters.AddWithValue("@userNumber2", second.UserNumber);
//                updateTicketCmd.ExecuteNonQuery();
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
        //public bool exchangeFlight(User user1, User user2)
        //{
        //}
        public void removeFlight(Flight f)
        {
            //if (userNumber == theUser.UserNumber) throw new PermissionException("cannot remove admin himself");
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("delete FROM [flight] where flightNumber=@flightNumber;", conn);
                myCommand.Parameters.AddWithValue("@flightNumber", f.FlightNumber);
                myCommand.ExecuteNonQuery();
                SqlCommand myCommand2 = new SqlCommand("delete FROM [ticket] where flightNumber=@flightNumber;", conn);
                myCommand2.Parameters.AddWithValue("@flightNumber", f.FlightNumber);
                myCommand2.ExecuteNonQuery();
                if (theTicket!=null && theTicket.TheFlight.FlightNumber == f.FlightNumber) theTicket = null;
                //theUser.cancelBooking();
                //SqlCommand myCommand2 = new SqlCommand("delete FROM [ticket] where userNumber=@userNumber;", conn);
                //myCommand2.Parameters.AddWithValue("@userNumber", theUserNumber);
                //myCommand2.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public void removeUser(User theUser)
        {
            if (userNumber == theUser.UserNumber) throw new Exception("cannot remove admin himself");
            SqlConnection conn=Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("delete FROM [user] where userNumber=@userNumber;", conn);
                myCommand.Parameters.AddWithValue("@userNumber", theUser.UserNumber);
                myCommand.ExecuteNonQuery();
                theUser.cancelBooking();
                //SqlCommand myCommand2 = new SqlCommand("delete FROM [ticket] where userNumber=@userNumber;", conn);
                //myCommand2.Parameters.AddWithValue("@userNumber", theUserNumber);
                //myCommand2.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public void resetPass(int theUserNumber, string newpass)
        {
            string newpassmd5=Interaction.MD5SUM(newpass);
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand checkCommand = new SqlCommand(@"select count(*) from [user] 
                            where userNumber=@theUserNumber", conn);
                checkCommand.Parameters.AddWithValue("@theUserNumber", theUserNumber);
                int userCount = (Int32)checkCommand.ExecuteScalar();
                if (userCount <= 0)
                {
                    throw new Exception("user doesn't exists");
                }
                //SqlCommand com = new SqlCommand(string.Format("update [user] set firstName='{0}', lastName='{1}', phoneNumber='{2}', address='{3}' where userName='{4}';",theFirstName,theLastName,thePhone,theAddress,userName), conn);
                SqlCommand com = new SqlCommand("update [user] set password=@password where userNumber=@theUserNumber;", conn);
                com.Parameters.AddWithValue("@password", newpassmd5);
                com.Parameters.AddWithValue("@theUserNumber", theUserNumber);
                com.ExecuteNonQuery();
                if (userNumber == theUserNumber) password = newpassmd5;
            }
            finally
            {
                conn.Close();
            }
        }
        //public User[] searchUser(string firstName, string lastName, string phoneNumber, string userName)
        //{
        //}
    }
