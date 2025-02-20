﻿using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TIcketStatsTest
    {
        // Global variables for Tests
        string staffID = "staffID test";
        string description = "description test";
        string email = "email test";
        string creatorName = "creatorName test";

        TicketStats ticketStats = new TicketStats();

        // TicketStats variables encapsulated with default value of 0
        [Fact]
        public void TicketStats_VariablesEncapsulatedWithDefaultAsZero()
        {
            TicketStats ticketStats = new TicketStats();
            var openDefault = ticketStats.GetOpened();
            var closedDefault = ticketStats.GetClosed();
            var createdDefault = ticketStats.GetCreated();

            uint expectedOpen = 0;
            uint expectedClosed = 0;
            uint expectedCreated = 0;

            Assert.Equal(expectedOpen, openDefault);
            Assert.Equal(expectedClosed, closedDefault);
            Assert.Equal(expectedCreated, createdDefault);
        }

        // For every Ticket created:
        //   TicketStats.Created += 1
        //   TicketStats.Opened += 1
        [Fact]
        public void CreateTicket_UpdatesStats_CreatedPlusOne_OpenedPlusOne()
        {
            // Get before Ticket created and opened stats
            var createdBefore = ticketStats.GetCreated();
            var openedBefore = ticketStats.GetOpened();

            Ticket ticket_2 = new Ticket(staffID, description, email, creatorName, ticketStats);

            var expectedCreatedAfter = createdBefore + 1;
            var actualCreatedAfter = ticketStats.GetCreated();

            var expectedOpenedAfter = openedBefore + 1;
            var actualOpenedAfter = ticketStats.GetOpened();

            Assert.Equal(expectedCreatedAfter, actualCreatedAfter);
            Assert.Equal(expectedOpenedAfter, actualOpenedAfter);
        }

        // Method: Ticket.Resolve() updates TicketStats.Opened -1 and TicketStats.Closed +1
        [Fact]
        public void Resolve_UpdatesStats_OpenedMinusOne_ClosedPlusOne()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var beforeOpened = ticketStats.GetOpened();
            var beforeClosed = ticketStats.GetClosed();
            
            ticket.Resolve("test");

            var expectedAfterOpened = beforeOpened - 1;
            var actualAfterOpened = ticketStats.GetOpened();

            var expectedAfterClosed = beforeClosed + 1;
            var actualAfterClosed = ticketStats.GetClosed();

            Assert.Equal(expectedAfterOpened, actualAfterOpened);
            Assert.Equal(expectedAfterClosed, actualAfterClosed);
        }

        // Method: Ticket.Reopen() updates TicketStats.Opened +1 and TicketStats.Closed -1
        [Fact]
        public void Reopen_UpdatesStats_OpenedPlusOne_ClosedMinusOne()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            ticket.Resolve("test");

            var beforeOpened = ticketStats.GetOpened();
            var beforeClosed = ticketStats.GetClosed();

            ticket.Reopen();

            var expectedAfterOpened = beforeOpened + 1;
            var actualAfterOpened = ticketStats.GetOpened();

            var expectedAfterClosed = beforeClosed - 1;
            var actualAfterClosed = ticketStats.GetClosed();

            Assert.Equal(expectedAfterOpened, actualAfterOpened);
            Assert.Equal(expectedAfterClosed, actualAfterClosed);
        }

        // Method: TicketStats.GetTicketStats exists and return type <string>
        [Fact]
        public void Method_Exist_GetTicketStats_ReturnTypeIsString()
        {
            var ticketStatsString = ticketStats.GetTicketStats();

            Assert.IsType<string>(ticketStatsString);
        }
    }
}
