﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    
    // Stores state of Ticket statistics
    public class TicketStats : ITicketStats
    {
        private uint _created { get; set; } = 0;
        private uint _closed { get; set; } = 0;
        private uint _opened { get; set; } = 0;

        public TicketStats() { }

        // Methods to retrieve ticket statistics
        public uint GetCreated() => _created;

        public uint GetClosed() => _closed;

        public uint GetOpened() => _opened;

        // Update statistics base on status
        public void UpdateStats(string status)
        {
            switch (status)
            {
                case "Open":
                    _created += 1;
                    _opened += 1;
                    break;

                case "Closed":
                    _opened -= 1;
                    _closed += 1;
                    break;

                case "Reopened":
                    _opened += 1;
                    _closed -= 1;
                    break;
            }
        }

        // Returns a string of ticket stats information
        public string GetTicketStats()
        {   
            string ticketStatistics = $"Tickets Created: {_created}\nTickets Resolved: {_closed}\nTickets To Solve: {_opened}\n";
            return ticketStatistics;
        }
    }
}  
