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
        public class TicketStatusControllerTest
            {
            //private TicketStatusController _ticketStatusController;
            //private Mock<IHelpDeskTicketStatusRepository> _helpDeskTicketStatusRepository;
            //private IHelpDeskTicketStatusManager _helpDeskTicketStatusManager;
            //private Mock<ILogger> _logger;

            //[SetUp]
            //public void BeforeEach()
            //    {
            //    _helpDeskTicketStatusRepository = new Mock<IHelpDeskTicketStatusRepository>();
            //    _logger = new Mock<ILogger>();
            //    _helpDeskTicketStatusManager = new HelpDeskTicketStatusManager(_helpDeskTicketStatusRepository.Object, _logger.Object);
            //    _ticketStatusController = new TicketStatusController(_helpDeskTicketStatusManager, _logger.Object);
            //    }

            //[Test]
            //public void TestEntities_ConfirmMapsIntoViewModel()
            //    {
            //    // Arrange
            //    _helpDeskTicketStatusRepository.Setup(x => x.GetAllStatuses()).Returns(GetTicketStatusList);

            //    // Act
            //    var allTicketStatuses = _ticketStatusController.Get();
            //    var expectedResult = GetTicketStatusList_ResultForMappingToVM();

            //    // Assert
            //    Assert.IsNotNull(allTicketStatuses, "Result is null");
            //    allTicketStatuses.ShouldBeEquivalentTo(expectedResult);
            //    }

            //[Test]
            //public void TestAddingNewTicketStatus_DoesntReturnNull_ReturnsNewTicketStatusID()
            //    {
            //    // Arrange
            //    _helpDeskTicketStatusRepository.Setup(x => x.CreateStatus(It.IsAny<HelpDesk_TicketStatus>()))
            //        .Returns(PostTicketStatus_ResultFromPostReturnInt());

            //    // Act
            //    var postTicketTypeID = _ticketStatusController.Post(PostTicketStatus());

            //    // Assert
            //    Assert.IsNotNull(postTicketTypeID, "Result is null");
            //    postTicketTypeID.ShouldBeEquivalentTo(1);
            //    }

            //[Test]
            //public void TestEditingTicketStatus_DoesntReturnNull_ReturnsSameTicketTypeID()
            //    {
            //    //Arrange
            //    _helpDeskTicketStatusRepository.Setup(
            //        x => x.EditStatusById(It.IsAny<int>(), It.IsAny<HelpDesk_TicketStatus>()))
            //        .Returns(PutTicketStatus_ResultFromPutReturnInt());


            //    //Act
            //    var putTicketStatusID = _ticketStatusController.Put(1, PutTicketStatus());

            //    //Assert
            //    Assert.IsNotNull(putTicketStatusID, "Result is null");
            //    putTicketStatusID.ShouldBeEquivalentTo(1);
            //    }

            //[Test]
            //public void TestDeleteTicketType_ReturnedTrue()
            //    {
            //    //Arrange
            //    _helpDeskTicketStatusRepository.Setup(x => x.DeleteStatusById(It.IsAny<int>())).Returns(true);

            //    //Act
            //    var isDeleted = _ticketStatusController.Delete(1);

            //    //Assert
            //    Assert.IsTrue(isDeleted);

            //    }

            //private List<HelpDesk_TicketStatus> GetTicketStatusList()
            //    {
            //    var ticketStatusValues = new List<HelpDesk_TicketStatus>
            //{
            //    new HelpDesk_TicketStatus
            //    {
            //        Id = 1,
            //        Status = "Open",
            //        HelpDesk_Tickets = new List<HelpDesk_Tickets>
            //        {
            //            new HelpDesk_Tickets
            //            {
            //                Id=1,
            //                Title = "Sample Ticket 1",
            //                Description = "Sample Description 1",
            //                Requestor = 1,
            //                DepartmentID = 1,
            //                LocationID = 1,
            //                RequestDateTime = new DateTime(),
            //                RequestedDueDate = new DateTime(),
            //                TicketCategoryID = 1,
            //                PriorityCode = 1,
            //                StatusID = 1,
            //                AssignedTo = 1,
            //                VendorID = 1,
            //                VendorTicket = "Sample Vendor Ticket 1",
            //                TicketTypeID = 1,
            //                NeedsApproval = true,
            //                ApprovedBy = 1,
            //                ApprovedOn = new DateTime()

            //            }
            //        }
            //    },
            //    new HelpDesk_TicketStatus
            //    {
            //        Id = 2,
            //        Status = "Closed",
            //        HelpDesk_Tickets = new List<HelpDesk_Tickets>
            //        {
            //            new HelpDesk_Tickets
            //            {
            //                Id=2,
            //                Title = "Sample Ticket 1",
            //                Description = "Sample Description 1",
            //                Requestor = 1,
            //                DepartmentID = 1,
            //                LocationID = 1,
            //                RequestDateTime = new DateTime(),
            //                RequestedDueDate = new DateTime(),
            //                TicketCategoryID = 1,
            //                PriorityCode = 1,
            //                StatusID = 1,
            //                AssignedTo = 1,
            //                VendorID = 1,
            //                VendorTicket = "Sample Vendor Ticket 1",
            //                TicketTypeID = 2,
            //                NeedsApproval = true,
            //                ApprovedBy = 1,
            //                ApprovedOn = new DateTime()

            //            }
            //        }
            //    }
            //};

            //    return ticketStatusValues;
            //    }

            //private List<HelpDesk_TicketStatus_vm> GetTicketStatusList_ResultForMappingToVM()
            //    {
            //    var ticketStatusValues_Result = new List<HelpDesk_TicketStatus_vm>
            //{
            //    new HelpDesk_TicketStatus_vm
            //    {
            //        Id = 1,
            //        Status = "Open"
            //    },
            //    new HelpDesk_TicketStatus_vm
            //    {
            //        Id = 2,
            //        Status = "Closed"
            //    }
            //};

            //    return ticketStatusValues_Result;
            //    }

            //private HelpDesk_TicketStatus_vm PostTicketStatus()
            //    {
            //    return new HelpDesk_TicketStatus_vm
            //    {
            //        Status = "Testing"
            //    };
            //    }

            //private int PostTicketStatus_ResultFromPostReturnInt()
            //    {
            //    return 1;
            //    }

            //private HelpDesk_TicketStatus_vm PutTicketStatus()
            //    {
            //    return new HelpDesk_TicketStatus_vm
            //    {
            //        Id = 1,
            //        Status = "TestingChanged"
            //    };
            //    }

            //private int PutTicketStatus_ResultFromPutReturnInt()
            //    {
            //    return 1;
            //    }
            }
        }
