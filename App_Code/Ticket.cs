using System;
using System.Collections.Generic;
using System.Web;

    public class Ticket
    {
        private int ticketNumber;
        Flight theFlight;
        User theUser;

        public int TicketNumber
        {
            get
            {
                return ticketNumber;
            }
        }

        public User TheUser
        {
            get
            {
                return theUser;
            }
        }

        public Flight TheFlight
        {
            get
            {
                return theFlight;
            }
            set
            {
                theFlight = value;
            }
        }

        // Operations:
        public Ticket(int ticketNum,User userObj, Flight flightObj)
        {
            ticketNumber = ticketNum;
            theUser = userObj;
            theFlight = flightObj;
        }

        //public bool saveTicketToFile(string fileName)
        //{
        //}
    }

