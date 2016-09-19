using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
{
    public class HelpDeskTicketRepository : IHelpDeskTicketRepository
    {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTicketRepository(ServiceDeskContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<HelpDesk_Tickets> GetAllTickets()
        {
            List<HelpDesk_Tickets> allTickets = _context.HelpDesk_Tickets.ToList();
            return allTickets;
        }


        public HelpDesk_Tickets GetTicketByID(int id)
        {
            HelpDesk_Tickets ticket = _context.HelpDesk_Tickets.FirstOrDefault(x => x.TicketNumber == id);
            return ticket;
        }

        public List<HelpDesk_Tickets> GetTicketsByUser(string userName)
            {
            //List<HelpDesk_Tickets> allTicketsByUser =
            //    _context.HelpDesk_Tickets.Where(
            //        x =>
            //            x.AssignedTo.Contains(userName) || x.Requestor.Contains(userName) ||
            //            x.ApprovedBy.Contains(userName)).ToList();

            //return allTicketsByUser;
            return null;
            }


        public List<HelpDesk_Tickets> GetTicketsByDepartment(int departmentID)
        {
            List<HelpDesk_Tickets> allTicketsByDepartment =
                _context.HelpDesk_Tickets.Where(x => x.DepartmentID == departmentID).ToList();
            return allTicketsByDepartment;
        }

        public int CreateTicket(HelpDesk_Tickets ticket)
        {
            ticket.TicketNumber = GetNextTicketNumber();
            _context.HelpDesk_Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket.Id;
        }

        public int EditTicket(int id, HelpDesk_Tickets ticket)
        {
            try
            {
                HelpDesk_Tickets oldTicket = _context.HelpDesk_Tickets.FirstOrDefault(x => x.TicketNumber == id);
                if(oldTicket != null)
                {
                    oldTicket.Title = ticket.Title;
                    oldTicket.Description = ticket.Description;
                    oldTicket.Requestor = ticket.Requestor;
                    oldTicket.DepartmentID = ticket.DepartmentID;
                    oldTicket.LocationID = ticket.LocationID;
                    oldTicket.RequestedDueDate = ticket.RequestedDueDate;
                    oldTicket.TicketCategoryID = ticket.TicketCategoryID;
                    oldTicket.PriorityCode = ticket.PriorityCode;
                    oldTicket.StatusID = ticket.StatusID;
                    oldTicket.AssignedTo = ticket.AssignedTo;
                    oldTicket.VendorID = ticket.VendorID;
                    oldTicket.VendorTicket = ticket.VendorTicket;
                    oldTicket.TicketTypeID = ticket.TicketTypeID;
                    oldTicket.NeedsApproval = ticket.NeedsApproval;
                    oldTicket.ApprovedBy = ticket.ApprovedBy;
                    oldTicket.ApprovedOn = ticket.ApprovedOn;
                }
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }


            return ticket.Id;

        }

        private int GetNextTicketNumber()
        {
            var ticket = _context.HelpDesk_Tickets.OrderByDescending(t => t.TicketNumber).FirstOrDefault();

            if (ticket != null)
            {
                return ticket.TicketNumber + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
