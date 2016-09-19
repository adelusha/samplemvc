using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Domain.Utilities;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTicketManager:IHelpDeskTicketManager
        {
        private readonly IHelpDeskTicketRepository _helpDeskTicketRepository;
        private readonly IHelpDeskTicketCommentRepository _helpDeskTicketCommentRepository;
        private readonly INSUserRepository _nsUserRepository;
        private readonly ILogger _logger;

        public HelpDeskTicketManager(IHelpDeskTicketRepository helpDeskTicketRepository, 
            IHelpDeskTicketCommentRepository helpDeskTicketCommentRepository, 
            INSUserRepository nsUserRepository,
            ILogger logger)
            {
            _helpDeskTicketRepository = helpDeskTicketRepository;
            _helpDeskTicketCommentRepository = helpDeskTicketCommentRepository;
            _nsUserRepository = nsUserRepository;
            _logger = logger;
            }

        public List<HelpDesk_Tickets_View_vm> GetAllTickets()
            {
            var allTickets = _helpDeskTicketRepository.GetAllTickets();
            if(allTickets == null)
                {
                _logger.Info("There are no tickets.");
                }
            return allTickets.Select(mapEntityToViewModelTicket).ToList();
            }

        public HelpDesk_Tickets_vm GetTicketByID(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            var ticketById = _helpDeskTicketRepository.GetTicketByID(id);
            return mapEntityToViewModelSingleTicket(ticketById);
            }

        public List<HelpDesk_Tickets_View_vm> GetTicketsByUser(string userName)
            {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("Must specify an user name.");
            }

            var ticketsByUser = _helpDeskTicketRepository.GetTicketsByUser(userName);
            if(ticketsByUser == null)
            {
                _logger.Info("There are not tickets for the specified user.");
            }

            return ticketsByUser.Select(mapEntityToViewModelTicket).ToList();
            }

        public List<HelpDesk_Tickets_View_vm> GetTicketsByDepartment(int departmentID)
            {
            var ticketsByDepartment = _helpDeskTicketRepository.GetTicketsByDepartment(departmentID);
            if(ticketsByDepartment == null)
            {
                _logger.Info("There are not tickets for the specified department.");
            }

            return ticketsByDepartment.Select(mapEntityToViewModelTicket).ToList();
            }

        public int CreateTicket(HelpDesk_Tickets_vm ticket)
            {
            return _helpDeskTicketRepository.CreateTicket(mapViewModelToEntityTicket(ticket));
            }

        public int CreateSimpleTicket(HelpDesk_Tickets_SimplePost_vm ticket)
        {
            var priority = 2;
            if(ticket.RequestedDueDate != null)
            {
                priority = 1;
            }
           
            var fullTicket = new HelpDesk_Tickets_vm
            {
                TicketNumber = 0,
                Title = ticket.Title,
                Description = ticket.Description,
                RequestorUserName = ticket.RequestorUserName,
                RequestDateTime = DateTime.Now,
                RequestedDueDate = ticket.RequestedDueDate ?? null,
                TicketCategoryID = ticket.TicketCategoryID,
                PriorityCode = (byte)priority,
                StatusID = 2,
                AssignedToUserName = "apopa", //Temporary need to get username of the default user the ticket will be assgined to
                TicketTypeID = 1,
                NeedsApproval = false
            };

            return CreateTicket(fullTicket);
        }

        public int EditTicket(int id, HelpDesk_Tickets_vm ticket)
            {
            if(id == 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
            }

            return _helpDeskTicketRepository.EditTicket(id, mapViewModelToEntityTicket(ticket));
            }

        private HelpDesk_Tickets_vm mapEntityToViewModelSingleTicket(HelpDesk_Tickets EFTicket)
            {
                var vmT = new HelpDesk_Tickets_vm
            {
                TicketNumber = EFTicket.TicketNumber,
                Title = EFTicket.Title,
                Description = EFTicket.Description,
                RequestorUserName = EFTicket.ServiceDesk_Users2 == null ? null : EFTicket.ServiceDesk_Users2.UserName,
                DepartmentID = EFTicket.DepartmentID,
                LocationID = EFTicket.LocationID,
                RequestDateTime = EFTicket.RequestDateTime,
                RequestedDueDate = EFTicket.RequestedDueDate,
                TicketCategoryID = EFTicket.TicketCategoryID,
                PriorityCode = EFTicket.PriorityCode,
                StatusID = EFTicket.StatusID,
                AssignedToUserName = EFTicket.ServiceDesk_Users1 == null ? null : EFTicket.ServiceDesk_Users1.UserName,
                VendorID = EFTicket.VendorID,
                VendorTicket = EFTicket.VendorTicket,
                TicketTypeID = EFTicket.TicketTypeID,
                NeedsApproval = EFTicket.NeedsApproval,
                ApprovedByUserName = EFTicket.ServiceDesk_Users == null ? null : EFTicket.ServiceDesk_Users.UserName,
                ApprovedOn = EFTicket.ApprovedOn,
                ApprovedByUser = EFTicket.ServiceDesk_Users ==null ? null: new Ticket_User()
                {
                    SID = EFTicket.ServiceDesk_Users.SID,
                    UserName = EFTicket.ServiceDesk_Users.UserName,
                    DisplayName = EFTicket.ServiceDesk_Users.FirstName + " "+EFTicket.ServiceDesk_Users.LastName,
                    UserDepartment = EFTicket.ServiceDesk_Users.Department.DepartmentName,
                    UserLocation = EFTicket.ServiceDesk_Users.NSLocation.LocationCity
                },
                AssignedToUser = EFTicket.ServiceDesk_Users1 == null ? null : new Ticket_User()
                {
                    SID = EFTicket.ServiceDesk_Users1.SID,
                    UserName = EFTicket.ServiceDesk_Users1.UserName,
                    DisplayName = EFTicket.ServiceDesk_Users1.FirstName + " " + EFTicket.ServiceDesk_Users1.LastName,
                    UserDepartment = EFTicket.ServiceDesk_Users1.Department.DepartmentName,
                    UserLocation = EFTicket.ServiceDesk_Users1.NSLocation.LocationCity
                },
                RequestorUser =  EFTicket.ServiceDesk_Users2 == null ? null : new Ticket_User()
                {
                    SID = EFTicket.ServiceDesk_Users2.SID,
                    UserName = EFTicket.ServiceDesk_Users2.UserName,
                    DisplayName = EFTicket.ServiceDesk_Users2.FirstName + " " + EFTicket.ServiceDesk_Users2.LastName,
                    UserDepartment = EFTicket.ServiceDesk_Users2.Department.DepartmentName,
                    UserLocation = EFTicket.ServiceDesk_Users2.NSLocation.LocationCity
                }
            };

            return vmT;
            }

        private HelpDesk_Tickets_View_vm mapEntityToViewModelTicket(HelpDesk_Tickets EFTicket)
        {
            var vmT = new HelpDesk_Tickets_View_vm
            {
                Id = EFTicket.Id,
                TicketNumber = EFTicket.TicketNumber,
                Title = EFTicket.Title,
                Description = EFTicket.Description,
                Requestor = EFTicket.ServiceDesk_Users2== null ? "" : (EFTicket.ServiceDesk_Users2.FirstName + " " + EFTicket.ServiceDesk_Users2.LastName),
                Department = EFTicket.Department.DepartmentName,
                Location = EFTicket.NSLocation.LocationCity,
                RequestDateTime = EFTicket.RequestDateTime,
                RequestedDueDate = EFTicket.RequestedDueDate,
                TicketCategory = EFTicket.HelpDesk_TicketCategory.Category,
                Priority = GetEnumDescription((TicketPriorityEnum)Convert.ToInt32(EFTicket.PriorityCode)),
                Status = EFTicket.HelpDesk_TicketStatus.Status,
                AssignedTo = EFTicket.ServiceDesk_Users1== null ? "" : (EFTicket.ServiceDesk_Users1.FirstName + " " + EFTicket.ServiceDesk_Users1.LastName),
                Vendor = EFTicket.VendorTicket,
                VendorTicket = EFTicket.VendorTicket,
                TicketType = EFTicket.HelpDesk_TicketType.TicketType,
                NeedsApproval = EFTicket.NeedsApproval,
                ApprovedBy = EFTicket.ServiceDesk_Users== null ? "" : (EFTicket.ServiceDesk_Users.FirstName + " " + EFTicket.ServiceDesk_Users.LastName),
                ApprovedOn = EFTicket.ApprovedOn
            };

            return vmT;
        }

        private HelpDesk_Tickets mapViewModelToEntityTicket(HelpDesk_Tickets_vm VMTicket)
            {
            ServiceDesk_Users approvedBy = _nsUserRepository.GetUserByUserName(VMTicket.ApprovedByUserName);
            ServiceDesk_Users assignedTo = _nsUserRepository.GetUserByUserName(VMTicket.AssignedToUserName);
            ServiceDesk_Users requestor = _nsUserRepository.GetUserByUserName(VMTicket.RequestorUserName);
            var vmT = new HelpDesk_Tickets
            {
                TicketNumber = VMTicket.TicketNumber,
                Title = VMTicket.Title,
                Description = VMTicket.Description,
                Requestor = requestor.Id,
                DepartmentID = requestor.DepartmentId,
                LocationID = requestor.LocationId,
                RequestDateTime = VMTicket.RequestDateTime,
                RequestedDueDate = VMTicket.RequestedDueDate,
                TicketCategoryID = VMTicket.TicketCategoryID,
                PriorityCode = VMTicket.PriorityCode,
                StatusID = VMTicket.StatusID,
                AssignedTo = assignedTo.Id,
                VendorID = VMTicket.VendorID,
                VendorTicket = VMTicket.VendorTicket,
                TicketTypeID = VMTicket.TicketTypeID,
                NeedsApproval = VMTicket.NeedsApproval,
                ApprovedBy = approvedBy == null ? (int?)null : approvedBy.Id,
                ApprovedOn = VMTicket.ApprovedOn
            };

            return vmT;
            }

        private string GetEnumDescription(TicketPriorityEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if(attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        }
    }
