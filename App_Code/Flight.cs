using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;

    public class Flight
    {
        private string origin; // Created from Attribute: 'Private string origin'
        private string destination; // Created from Attribute: 'Private string destination'
        private DateTime departureDateTime; // Created from Attribute: 'Private DateTime departureDate'
        //private DateTime departureTime; // Created from Attribute: 'Private DateTime departureTime'
        private DateTime arrivalDateTime; // Created from Attribute: 'Private DateTime arrivalDate'
        //private DateTime arrivalTime; // Created from Attribute: 'Private DateTime arrivalTime'
        //private int openSeats; // Created from Attribute: 'Private int openSeats'
        private int flightNumber; // Created from Attribute: 'Private int flightNumber'
        //Ticket theTickets;

        public string Origin
        {
            get
            {
                return origin;
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }
        }

        public DateTime DepartureDateTime
        {
            get
            {
                return departureDateTime;
            }
        }

        public DateTime ArrivalDateTime
        {
            get
            {
                return arrivalDateTime;
            }
        }

        public int OpenSeats
        {
            get
            {
                SqlConnection conn = Interaction.DbConnection;
                try
                {
                    conn.Open();
                    SqlCommand selectCommand = new SqlCommand(@"select openSeats from [flight]
                                               WHERE flightNumber=@flightNumber;", conn);
                    selectCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
                    int os = Convert.ToInt32(selectCommand.ExecuteScalar());
                    return os;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
            public int TicketCount
            {
                get{
                    SqlConnection conn = Interaction.DbConnection;
                    try
                    {
                        conn.Open();
                        SqlCommand selectCommand = new SqlCommand(@"select count(*) from [ticket]
                                                   WHERE flightNumber=@flightNumber;", conn);
                        selectCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
                        int os=Convert.ToInt32(selectCommand.ExecuteScalar());
                        return os;
                    }
                    finally
                    {
                        conn.Close();
                    }                    
                }
            }
//            set
//            {
//                SqlConnection conn = Interaction.DbConnection;
//                try
//                {
//                    conn.Open();
//                    SqlCommand updateCommand = new SqlCommand(@"UPDATE [flight]
//                                               SET openSeats = @openSeats
//                                               WHERE flightNumber=@flightNumber;", conn);
//                    updateCommand.Parameters.AddWithValue("@openSeats", value);
//                    updateCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
//                    updateCommand.ExecuteNonQuery();
//                }
//                finally
//                {
//                    conn.Close();
//                }
//                openSeats = value;
//            }

        public void editFlight(string newOrigin, string newDestination, DateTime newDept, DateTime newArriv, int newOpenSeat)
        {
            if (!(Interaction.LoggedInUser is Admin)) throw new Exception("permission denied");
            if (newOpenSeat < 0) throw new Exception("open seats can't be <0");
            //DateTime deptdatetime = flightToEdit.DepartureDateTime;
            //DateTime arrivdatetime = flightToEdit.ArrivalDateTime;
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand checkCommand = new SqlCommand(@"select count(*) from [flight] 
                            where flightNumber<>@flightNumber and origin=@ori and destination=@dst and departureDateTime=@ddatetime
                            and arrivalDateTime=@arrivDateTime and openSeats=@openSeats", conn);
                checkCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
                checkCommand.Parameters.AddWithValue("@ori", newOrigin);
                checkCommand.Parameters.AddWithValue("@dst", newDestination);
                checkCommand.Parameters.AddWithValue("@ddatetime", newDept);
                //checkCommand.Parameters.AddWithValue("@dtime", deptt.TimeOfDay);
                checkCommand.Parameters.AddWithValue("@arrivdatetime", newArriv);
                //checkCommand.Parameters.AddWithValue("@arrivtime", arrit);
                checkCommand.Parameters.AddWithValue("@openseats", newOpenSeat);
                int flightCount = (Int32)checkCommand.ExecuteScalar();
                if (flightCount > 0)
                {
                    throw new Exception("flight already exists");
                }

                SqlCommand checkCommand2 = new SqlCommand(@"select count(*) from [ticket] 
                            where flightNumber=@flightNumber", conn);
                checkCommand2.Parameters.AddWithValue("@flightNumber", flightNumber);
                int bookCount = (Int32)checkCommand2.ExecuteScalar();
                if (bookCount > 0)
                {
                    throw new Exception("flight still booked");
                }

                SqlCommand createCommand = new SqlCommand(@"update [flight]
                   set [origin]=@ori
                   ,[destination]=@dst
                   ,[departureDateTime]=@ddatetime
                   ,[arrivalDateTime]=@arrivdatetime
                   ,[openSeats]=@openseats  where flightNumber=@flightNumber", conn);
                createCommand.Parameters.AddWithValue("@ori", newOrigin);
                createCommand.Parameters.AddWithValue("@dst", newDestination);
                createCommand.Parameters.AddWithValue("@ddatetime", newDept);
                //createCommand.Parameters.AddWithValue("@dtime", deptt);
                createCommand.Parameters.AddWithValue("@arrivdatetime", newArriv);
                //createCommand.Parameters.AddWithValue("@arrivtime", arrit);
                createCommand.Parameters.AddWithValue("@openseats", newOpenSeat);
                createCommand.Parameters.AddWithValue("@flightNumber", FlightNumber);
                //Console.Error.WriteLine(createCommand.ToString());
                createCommand.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            origin = newOrigin;
            destination = newDestination;
            departureDateTime = newDept;
            arrivalDateTime = newArriv;
        }

        public int FlightNumber
        {
            get
            {
                return flightNumber;
            }
        }

        public Flight(int flightNum, string ori, string dest, DateTime deptDateTime, DateTime arrivDateTime)
        {
            flightNumber = flightNum;
            origin = ori;
            destination = dest;
            departureDateTime = deptDateTime;
            arrivalDateTime = arrivDateTime;
            //openSeats = os;
        }

        public override string ToString()
        {
            return flightNumber + "\n" +
            origin + "\n" +
            destination + "\n" +
            departureDateTime + "\n" +
            arrivalDateTime + "\n" +
            OpenSeats + "\n";
//            phoneNumber + "\n" +
            //userName + "\n";
        }

        public void decrementOpenSeats()
        {
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand updateCommand = new SqlCommand(@"UPDATE [flight]
                                                           SET openSeats = openSeats-1
                                                           WHERE flightNumber=@flightNumber;", conn);
                //updateCommand.Parameters.AddWithValue("@openSeats", value);
                updateCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
                updateCommand.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public void incrementOpenSeats()
        {
            SqlConnection conn = Interaction.DbConnection;
            try
            {
                conn.Open();
                SqlCommand updateCommand = new SqlCommand(@"UPDATE [flight]
                                                           SET openSeats = openSeats+1
                                                           WHERE flightNumber=@flightNumber;", conn);
                //updateCommand.Parameters.AddWithValue("@openSeats", value);
                updateCommand.Parameters.AddWithValue("@flightNumber", flightNumber);
                updateCommand.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        // Operations:

        //public bool setOpenSeats(int newOpenSeats)
        //{
        //}
        //public int getOpenSeats()
        //{
        //}
        //public bool saveBookedUsersToFile(string filename)
        //{
        //}
        //public bool cancelAllBooking()
        //{
        //}
    }
