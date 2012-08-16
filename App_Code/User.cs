using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Diagnostics;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Data.SqlClient;

    public class User
    {
        //flag 0=customer, 1=agent, 2=admin
        protected int userNumber;
        protected string address;
        protected string firstName;
        protected int flag;
        protected string lastName;
        protected string password;
        protected string phoneNumber;
        protected string userName;
        protected Ticket theTicket;

        public Ticket TheTicket
        {
            get
            {
                return theTicket;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public int UserNumber
        {
            get
            {
                return userNumber;
            }
        }

        public User(int theUserNum, string theAddress, string theFirstName, int theFlag, string theLastName, string thePassword, string thePhoneNumber, string theUserName)
        {
            SqlConnection conn= Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand checkCommand = new SqlCommand("select * from [ticket] where userNumber=@userNumber", conn);
                //Debug.WriteLine(userNumber);
                checkCommand.Parameters.AddWithValue("@userNumber", theUserNum);
                SqlDataReader rd = checkCommand.ExecuteReader();
                if (rd.Read())
                {
                    int ticketNumber=(Int32)rd["ticketNumber"];
                    int flightNumber=(Int32)rd["flightNumber"];
                    rd.Close();
                    SqlCommand flightCommand=new SqlCommand("select * from [flight] where flightNumber=@flightNumber", conn);
                    flightCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
                    SqlDataReader flightrd = flightCommand.ExecuteReader();
                    flightrd.Read();
                    Debug.WriteLine("getting ticket");
                    theTicket = new Ticket(ticketNumber, this, new Flight(flightNumber, (string)flightrd["origin"], (string)flightrd["destination"], (DateTime)flightrd["departureDateTime"],
                        (DateTime)flightrd["arrivalDateTime"]));
                    flightrd.Close();
                }else{
                    Debug.WriteLine("no ticket");
                    rd.Close();
                }
            }
            finally
            {
                conn.Close();
            }
             userNumber=theUserNum;
             address=theAddress;
             firstName=theFirstName;
             flag=theFlag;
             lastName=theLastName;
             password=thePassword;
             phoneNumber=thePhoneNumber;
             userName=theUserName;
        }

        public void updateInfo(string theFirstName, string theLastName, string thePhone, string theAddress)
        {
            SqlConnection conn= Interaction.DbConnection;
            try{
                conn.Open();
                //SqlCommand com = new SqlCommand(string.Format("update [user] set firstName='{0}', lastName='{1}', phoneNumber='{2}', address='{3}' where userName='{4}';",theFirstName,theLastName,thePhone,theAddress,userName), conn);
                SqlCommand com = new SqlCommand("update [user] set firstName=@firstName, lastName=@lastName, phoneNumber=@phoneNumber, address=@address where userName=@userName;", conn);
                com.Parameters.AddWithValue("@firstName", theFirstName);
                com.Parameters.AddWithValue("@lastName",theLastName);
                com.Parameters.AddWithValue("@phoneNumber",thePhone);
                com.Parameters.AddWithValue("@address",theAddress);
                com.Parameters.AddWithValue("@userName",userName);
                com.ExecuteNonQuery();
            }finally{
                conn.Close();
            }
            firstName = theFirstName;
            lastName = theLastName;
            phoneNumber = thePhone;
            address = theAddress;
        }

        public bool updatePass(string oldpass, string newpass)
        {
            if (Interaction.MD5SUM(oldpass) != password)
            {
                return false;
            }
            else
            {
                string newpassmd5 = Interaction.MD5SUM(newpass);
                SqlConnection conn = Interaction.DbConnection;
                conn.Open();
                SqlCommand com = new SqlCommand("update [user] set password=@password where userName=@userName;", conn);
                com.Parameters.AddWithValue("@password",newpassmd5);
                com.Parameters.AddWithValue("@userName", userName);
                com.ExecuteNonQuery();
                conn.Close();
                password = newpassmd5;
                return true;
            }
        }

        public override string ToString()
        {
            return userNumber + "\n" +
            address + "\n" +
            firstName + "\n" +
            flag + "\n" +
            lastName + "\n" +
            password + "\n" +
            phoneNumber + "\n" +
            userName + "\n";
        }
        public void book(Flight theFlight)
        {
            if (theFlight.OpenSeats <= 0)
            {
                throw new Exception("Flight Already Full");
            }
            //Ticket ret = null;
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand checkCommand = new SqlCommand("select count(*) from [ticket] where userNumber=@userNumber", conn);
                checkCommand.Parameters.AddWithValue("@userNumber", userNumber);
                //checkCommand.Parameters.AddWithValue("@flightNumber", theFlight.FlightNumber);
                //SqlDataReader rd = checkCommand.ExecuteReader();
                //rd.Read();
                //int userCount=rd.GetInt32(0);
                //rd.Close();
                int ticketCount = (Int32)checkCommand.ExecuteScalar();
                if (ticketCount > 0)
                {
                    throw new Exception("user already booked flight");
                }
                SqlCommand createCommand = new SqlCommand(@"INSERT INTO [ticket]
                   ([userNumber]
                   ,[flightNumber])
             VALUES
                   (@userNumber
                   ,@flightNumber);SELECT @@IDENTITY;", conn);
                createCommand.Parameters.AddWithValue("@userNumber", userNumber);
                createCommand.Parameters.AddWithValue("@flightNumber", theFlight.FlightNumber);
                int id=Convert.ToInt32(createCommand.ExecuteScalar());
                theFlight.decrementOpenSeats();
                theTicket = new Ticket(id, this, theFlight);
            }
            finally
            {
                conn.Close();
            }
            //return true;
        }
        public bool cancelBooking()
        {
            if (theTicket == null)
            {
                return false;
            }
            else
            {
                SqlConnection conn = Interaction.DbConnection;
                try
                {
                    conn.Open();
                    SqlCommand deleteCommand = new SqlCommand(@"delete from [ticket]
                       where ticketNumber=@ticketNumber;", conn);
                    deleteCommand.Parameters.AddWithValue("@ticketNumber", theTicket.TicketNumber);
                    deleteCommand.ExecuteNonQuery();
                    theTicket.TheFlight.incrementOpenSeats();
                    theTicket = null;
                }
                finally
                {
                    conn.Close();
                }
                return true;
            }
        }

        public List<Flight> searchFlight(string ori, string dst, DateTime deptdt)
        {
            SqlCommand searchCommand = new SqlCommand(@"select * from [flight]
                   where origin=@ori and destination=@dst and DATEADD(day, DATEDIFF(day, 0, departureDateTime),0) = @deptdt");
            searchCommand.Parameters.AddWithValue("@ori", ori);
            searchCommand.Parameters.AddWithValue("@dst", dst);
            searchCommand.Parameters.AddWithValue("@deptdt", deptdt.Date);
            return helperSearch(searchCommand);
        }

        public List<Flight> searchFlight(string ori, string dst, DateTime deptdt, DateTime deptdt2)
        {
            DateTime deptdtbetter = new DateTime(deptdt2.Year, deptdt2.Month, deptdt2.Day, 23, 59, 59, 0);
                SqlCommand searchCommand = new SqlCommand(@"select * from [flight]
                   where origin=@ori and destination=@dst and departureDateTime BETWEEN @deptdt and @deptdt2;");
                searchCommand.Parameters.AddWithValue("@ori", ori);
                searchCommand.Parameters.AddWithValue("@dst", dst);
                searchCommand.Parameters.AddWithValue("@deptdt", deptdt);
                searchCommand.Parameters.AddWithValue("@deptdt2", deptdtbetter);
                return helperSearch(searchCommand);
        }

        private List<Flight> helperSearch(SqlCommand searchCommand)
        {
            List<Flight> ret = new List<Flight>();
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                searchCommand.Connection = conn;
                SqlDataReader r = searchCommand.ExecuteReader();
                while (r.Read())
                {
                    Flight f = new Flight(Convert.ToInt32(r["flightNumber"]), (string)r["origin"], (string)r["destination"], Convert.ToDateTime(r["departureDateTime"]), Convert.ToDateTime(r["arrivalDateTime"]));
                    ret.Add(f);
                    Debug.WriteLine("flight:" + f.ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return ret;
        }

//        public List<Flight> searchFlight(string ori, string dst, DateTime deptdt, DateTime arridt)
//        {
//            List<Flight> ret = new List<Flight>();
//            SqlConnection conn = Interaction.DbConnection;
//            try
//            {
//                conn.Open();
//                SqlCommand searchCommand = new SqlCommand(@"select * from [flight]
//                       where origin=@ori and destination=@dst and departureDateTime=@deptdt and arrivalDateTime=@arridt;", conn);
//                searchCommand.Parameters.AddWithValue("@ori", ori);
//                searchCommand.Parameters.AddWithValue("@dst", dst);
//                searchCommand.Parameters.AddWithValue("@deptdt", deptdt);
//                searchCommand.Parameters.AddWithValue("@arridt", arridt);
//                SqlDataReader r = searchCommand.ExecuteReader();
//                while (r.Read())
//                {
//                    Flight f = new Flight(Convert.ToInt32(r["flightNumber"]), (string)r["origin"], (string)r["destination"], Convert.ToDateTime(r["departureDateTime"]), Convert.ToDateTime(r["arrivalDateTime"]));
//                    ret.Add(f);
//                    Debug.WriteLine("flight:" + f.ToString());
//                }
//            }
//            finally
//            {
//                conn.Close();
//            }
//            return ret;
//        }
        //public bool editInfo(string address, string firstName, string lastName, string phoneNumber)
        //{
        //}
        //public bool changePass(string oldPass, string newPass)
        //{
        //}
        //public Ticket getBooking()
        //{
        //}
    }
