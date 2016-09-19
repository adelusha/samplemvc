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
    public class TicketTypeControllerTest
    {
    //    private TicketTypeController _ticketTypeController;
    //    private Mock<IHelpDeskTicketTypeRepository> _helpDeskTicketTypeRepository;
    //    private IHelpDeskTicketTypeManager _helpDeskTicketTypeManager;
    //    private Mock<ILogger> _logger;

    //    [SetUp]
    //    public void BeforeEach()
    //    {
    //        _helpDeskTicketTypeRepository = new Mock<IHelpDeskTicketTypeRepository>();
    //        _logger = new Mock<ILogger>();
    //        _helpDeskTicketTypeManager = new HelpDeskTicketTypeManager(_helpDeskTicketTypeRepository.Object, _logger.Object);
    //        _ticketTypeController = new TicketTypeController(_helpDeskTicketTypeManager, _logger.Object);
    //    }

    //    [Test]
    //    public void TestEntities_ConfirmMapsIntoViewModel()
    //    {
    //        // Arrange
    //        _helpDeskTicketTypeRepository.Setup(x => x.GetAllTicketTypes()).Returns(GetTicketTypeList());

    //        // Act
    //        var allTicketTypes = _ticketTypeController.Get();
    //        var expectedResult = GetTicketTypeList_ResultForMappingToVM();

    //        // Assert
    //        Assert.IsNotNull(allTicketTypes, "Result is null");
    //        allTicketTypes.ShouldBeEquivalentTo(expectedResult);
    //    }

    //    [Test]
    //    public void TestAddingNewTicketType_DoesntReturnNull_ReturnsNewTicketTypeID()
    //    {
    //        // Arrange
    //        _helpDeskTicketTypeRepository.Setup(x => x.CreateTicketType(It.IsAny<HelpDesk_TicketType>()))
    //            .Returns(PostTicketType_ResultFromPostReturnInt());

    //        // Act
    //        var postTicketTypeID = _ticketTypeController.Post(PostTicketType());

    //        // Assert
    //        Assert.IsNotNull(postTicketTypeID, "Result is null");
    //        postTicketTypeID.ShouldBeEquivalentTo(1);
    //    }

    //    [Test]
    //    public void TestEditingTicketType_DoesntReturnNull_ReturnsSameTicketTypeID()
    //    {
    //        //Arrange
    //        _helpDeskTicketTypeRepository.Setup(
    //            x => x.EditTicketTypeById(It.IsAny<int>(), It.IsAny<HelpDesk_TicketType>()))
    //            .Returns(PutTicketType_ResultFromPutReturnInt());


    //        //Act
    //        var putTicketTypeID = _ticketTypeController.Put(1, PutTicketType());

    //        //Assert
    //        Assert.IsNotNull(putTicketTypeID, "Result is null");
    //        putTicketTypeID.ShouldBeEquivalentTo(1);
    //    }

    //    [Test]
    //    public void TestDeleteTicketType_ReturnedTrue()
    //    {
    //        //Arrange
    //        _helpDeskTicketTypeRepository.Setup(x => x.DeleteTicketTypeById(It.IsAny<int>())).Returns(true);

    //        //Act
    //        var isDeleted = _ticketTypeController.Delete(1);

    //        //Assert
    //        Assert.IsTrue(isDeleted);

    //    }

    //    private List<HelpDesk_TicketType> GetTicketTypeList()
    //    {
    //        var ticketTypeValues = new List<HelpDesk_TicketType>
    //        {
    //            new HelpDesk_TicketType
    //            {
    //                Id = 1,
    //                TicketType = "Change",
    //                HelpDesk_Tickets = new List<HelpDesk_Tickets>
    //                {
    //                    new HelpDesk_Tickets
    //                    {
    //                        Id=1,
    //                        Title = "Sample Ticket 1",
    //                        Description = "Sample Description 1",
    //                        Requestor = 1,
    //                        DepartmentID = 1,
    //                        LocationID = 1,
    //                        RequestDateTime = new DateTime(),
    //                        RequestedDueDate = new DateTime(),
    //                        TicketCategoryID = 1,
    //                        PriorityCode = 1,
    //                        StatusID = 1,
    //                        AssignedTo = 1,
    //                        VendorID = 1,
    //                        VendorTicket = "Sample Vendor Ticket 1",
    //                        TicketTypeID = 1,
    //                        NeedsApproval = true,
    //                        ApprovedBy = 1,
    //                        ApprovedOn = new DateTime()

    //                    }
    //                }
    //            },
    //            new HelpDesk_TicketType
    //            {
    //                Id = 2,
    //                TicketType = "Break Fix",
    //                HelpDesk_Tickets = new List<HelpDesk_Tickets>
    //                {
    //                    new HelpDesk_Tickets
    //                    {
    //                        Id=2,
    //                        Title = "Sample Ticket 1",
    //                        Description = "Sample Description 1",
    //                        Requestor = 1,
    //                        DepartmentID = 1,
    //                        LocationID = 1,
    //                        RequestDateTime = new DateTime(),
    //                        RequestedDueDate = new DateTime(),
    //                        TicketCategoryID = 1,
    //                        PriorityCode = 1,
    //                        StatusID = 1,
    //                        AssignedTo = 1,
    //                        VendorID = 1,
    //                        VendorTicket = "Sample Vendor Ticket 1",
    //                        TicketTypeID = 2,
    //                        NeedsApproval = true,
    //                        ApprovedBy = 1,
    //                        ApprovedOn = new DateTime()

    //                    }
    //                }
    //            }
    //        };

    //        return ticketTypeValues;
    //    }

    //    private List<HelpDesk_TicketType_vm> GetTicketTypeList_ResultForMappingToVM()
    //    {
    //        var ticketTypeValues_Result = new List<HelpDesk_TicketType_vm>
    //        {
    //            new HelpDesk_TicketType_vm
    //            {
    //                Id = 1,
    //                TicketType = "Change"
    //            },
    //            new HelpDesk_TicketType_vm
    //            {
    //                Id = 2,
    //                TicketType = "Break Fix"
    //            }
    //        };

    //        return ticketTypeValues_Result;
    //    }

    //    private HelpDesk_TicketType_vm PostTicketType()
    //    {
    //        return new HelpDesk_TicketType_vm
    //        {
    //            TicketType = "Testing"
    //        };
    //    }

    //    private int PostTicketType_ResultFromPostReturnInt()
    //    {
    //        return 1;
    //    }

    //    private HelpDesk_TicketType_vm PutTicketType()
    //    {
    //        return new HelpDesk_TicketType_vm
    //        {
    //            Id = 1,
    //            TicketType = "TestingChanged"
    //        };
    //    }

    //    private int PutTicketType_ResultFromPutReturnInt()
    //    {
    //        return 1;
    //    }
    }
}
