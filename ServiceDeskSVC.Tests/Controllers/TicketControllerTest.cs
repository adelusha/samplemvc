using System;
using System.Collections.Generic;
using FluentAssertions;
using ILogging;
using Moq;
using NUnit.Framework;
using ServiceDeskSVC.Controllers.API;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.Managers;

namespace ServiceDeskSVC.Tests.Controllers
{
    [TestFixture]
    public class TicketControllerTest
    {
        //private TicketController _TicketController;
        //private Mock<IHelpDeskTicketRepository> _helpDeskTicketRepository;
        //private Mock<IHelpDeskTicketCommentRepository> _helpDeskTicketCommentRepository;
        //private IHelpDeskTicketManager _helpDeskTicketManager;
        //private Mock<ILogger> _logger;

        //[SetUp]
        //public void BeforeEach()
        //{
        //    _helpDeskTicketRepository = new Mock<IHelpDeskTicketRepository>();
        //    _helpDeskTicketCommentRepository = new Mock<IHelpDeskTicketCommentRepository>();
        //    _logger = new Mock<ILogger>();
        //    _helpDeskTicketManager = new HelpDeskTicketManager(_helpDeskTicketRepository.Object,
        //        _helpDeskTicketCommentRepository.Object, _logger.Object);
        //    _TicketController = new TicketController(_helpDeskTicketManager, _logger.Object);
        //}

        //[Test]
        //public void TestAddingNewTicket_DoesntReturnNull_ReturnsNewTicketID()
        //{
        //    // Arrange
        //    _helpDeskTicketRepository.Setup(x => x.CreateTicket(It.IsAny<HelpDesk_Tickets>()))
        //        .Returns(PostTicket_ResultFromPostReturnInt());
        //    // Act
        //    int postTaskTypeID = _TicketController.Post(PostTicket());
        //    // Assert
        //    Assert.IsNotNull(postTaskTypeID, "Result is null");
        //    postTaskTypeID.ShouldBeEquivalentTo(1);
        //}

        //[Test]
        //public void TestEditingTicket_DoesntReturnNull_ReturnsSameTaskTypeID()
        //{
        //    //Arrange
        //    _helpDeskTicketRepository.Setup(
        //        x => x.EditTicket(It.IsAny<int>(), It.IsAny<HelpDesk_Tickets>()))
        //        .Returns(PutTicket_ResultFromPutReturnInt());
        //    //Act
        //    int putTicketID = _TicketController.Put(1, PutTicket());
        //    //Assert
        //    Assert.IsNotNull(putTicketID, "Result is null");
        //    putTicketID.ShouldBeEquivalentTo(1);
        //}


        //private List<HelpDesk_Tickets> GetTicketList()
        //{
        //    var TicketValues = new List<HelpDesk_Tickets>
        //    {
        //        new HelpDesk_Tickets
        //        {
        //            Id = 1,
        //            Title = "Sample Ticket 1",
        //            Description = "Sample Description 1",
        //            Requestor = 1,
        //            DepartmentID = 1,
        //            LocationID = 1,
        //            RequestDateTime = new DateTime(),
        //            RequestedDueDate = new DateTime(),
        //            TicketCategoryID = 1,
        //            PriorityCode = 1,
        //            StatusID = 1,
        //            AssignedTo = 1,
        //            VendorID = 1,
        //            VendorTicket = "Sample Vendor Ticket 1",
        //            TicketTypeID = 1,
        //            NeedsApproval = true,
        //            ApprovedBy = 1,
        //            ApprovedOn = new DateTime()
        //        },
        //        new HelpDesk_Tickets
        //        {
        //            Id = 2,
        //            Title = "Sample Ticket 1",
        //            Description = "Sample Description 1",
        //            Requestor = 1,
        //            DepartmentID = 1,
        //            LocationID = 1,
        //            RequestDateTime = new DateTime(),
        //            RequestedDueDate = new DateTime(),
        //            TicketCategoryID = 1,
        //            PriorityCode = 1,
        //            StatusID = 1,
        //            AssignedTo = 1,
        //            VendorID = 1,
        //            VendorTicket = "Sample Vendor Ticket 1",
        //            TicketTypeID = 2,
        //            NeedsApproval = true,
        //            ApprovedOn = new DateTime()
        //        }
        //    };
        //    return TicketValues;
        //}

        //private List<HelpDesk_Tickets_vm> GetTicketList_ResultForMappingToVM()
        //{
        //    var TicketValues_Result = new List<HelpDesk_Tickets_vm>
        //    {
        //        new HelpDesk_Tickets_vm
        //        {
        //            TicketNumber = 1,
        //            Title = "Sample Ticket 1",
        //            Description = "Sample Description 1",
        //            Requestor = 1,
        //            DepartmentID = 1,
        //            LocationID = 1,
        //            RequestDateTime = new DateTime(),
        //            RequestedDueDate = new DateTime(),
        //            TicketCategoryID = 1,
        //            PriorityCode = 1,
        //            StatusID = 1,
        //            AssignedTo = 1,
        //            VendorID = 1,
        //            VendorTicket = "Sample Vendor Ticket 1",
        //            TicketTypeID = 1,
        //            NeedsApproval = true,
        //            ApprovedBy = 1,
        //            ApprovedOn = new DateTime()
        //        },
        //        new HelpDesk_Tickets_vm
        //        {
        //            TicketNumber = 2,
        //            Title = "Sample Ticket 1",
        //            Description = "Sample Description 1",
        //            Requestor = 1,
        //            DepartmentID = 1,
        //            LocationID = 1,
        //            RequestDateTime = new DateTime(),
        //            RequestedDueDate = new DateTime(),
        //            TicketCategoryID = 1,
        //            PriorityCode = 1,
        //            StatusID = 1,
        //            AssignedTo = 1,
        //            VendorID = 1,
        //            VendorTicket = "Sample Vendor Ticket 1",
        //            TicketTypeID = 2,
        //            NeedsApproval = true,
        //            ApprovedBy = 1,
        //            ApprovedOn = new DateTime()
        //        }
        //    };
        //    return TicketValues_Result;
        //}

        //private HelpDesk_Tickets_vm PostTicket()
        //{
        //    return new HelpDesk_Tickets_vm()
        //    {
        //        TicketNumber = 3,
        //        Title = "Sample Ticket New",
        //        Description = "Sample Description 1",
        //        Requestor = 1,
        //        DepartmentID = 1,
        //        LocationID = 1,
        //        RequestDateTime = new DateTime(),
        //        RequestedDueDate = new DateTime(),
        //        TicketCategoryID = 1,
        //        PriorityCode = 1,
        //        StatusID = 1,
        //        AssignedTo = 1,
        //        VendorID = 1,
        //        VendorTicket = "Sample Vendor Ticket 1",
        //        TicketTypeID = 1,
        //        NeedsApproval = true,
        //        ApprovedBy = 1,
        //        ApprovedOn = new DateTime()
        //    };
        //}

        //private int PostTicket_ResultFromPostReturnInt()
        //{
        //    return 1;
        //}

        //private HelpDesk_Tickets_vm PutTicket()
        //{
        //    return new HelpDesk_Tickets_vm
        //    {
        //        TicketNumber = 1,
        //        Title = "Sample Ticket Changed",
        //        Description = "Sample Description 1",
        //        Requestor = 1,
        //        DepartmentID = 1,
        //        LocationID = 1,
        //        RequestDateTime = new DateTime(),
        //        RequestedDueDate = new DateTime(),
        //        TicketCategoryID = 1,
        //        PriorityCode = 1,
        //        StatusID = 1,
        //        AssignedTo = 1,
        //        VendorID = 1,
        //        VendorTicket = "Sample Vendor Ticket 1",
        //        TicketTypeID = 1,
        //        NeedsApproval = true,
        //        ApprovedBy = 1,
        //        ApprovedOn = new DateTime()
        //    };
        //}

        //private int PutTicket_ResultFromPutReturnInt()
        //{
        //    return 1;
        //}
    }
}
