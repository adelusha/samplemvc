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
    public class TicketCategoryControllerTest
    {
        //private TicketCategoryController _TicketCategoryController;
        //private Mock<IHelpDeskTicketCategoryRepository> _helpDeskTicketCategoryRepository;
        //private IHelpDeskTicketCategoryManager _helpDeskTicketCategoryManager;
        //private Mock<ILogger> _logger;

        //[SetUp]
        //public void BeforeEach()
        //{
        //    _helpDeskTicketCategoryRepository = new Mock<IHelpDeskTicketCategoryRepository>();
        //    _logger = new Mock<ILogger>();
        //    _helpDeskTicketCategoryManager = new HelpDeskTicketCategoryManager(_helpDeskTicketCategoryRepository.Object, _logger.Object);
        //    _TicketCategoryController = new TicketCategoryController(_helpDeskTicketCategoryManager, _logger.Object);
        //}

        //[Test]
        //public void TestEntities_ConfirmMapsIntoViewModel()
        //{
        //    // Arrange
        //    _helpDeskTicketCategoryRepository.Setup(x => x.GetAllCategories()).Returns(GetTicketCategoryList());

        //    // Act
        //    var allTicketCategorys = _TicketCategoryController.Get();
        //    var expectedResult = GetTicketCategoryList_ResultForMappingToVM();

        //    // Assert
        //    Assert.IsNotNull(allTicketCategorys, "Result is null");
        //    allTicketCategorys.ShouldBeEquivalentTo(expectedResult);
        //}

        //[Test]
        //public void TestAddingNewTicketCategory_DoesntReturnNull_ReturnsNewTicketCategoryID()
        //{
        //    // Arrange
        //    _helpDeskTicketCategoryRepository.Setup(x => x.CreateCategory(It.IsAny<HelpDesk_TicketCategory>()))
        //        .Returns(PostTicketCategory_ResultFromPostReturnInt());

        //    // Act
        //    var postTicketCategoryID = _TicketCategoryController.Post(PostTicketCategory());

        //    // Assert
        //    Assert.IsNotNull(postTicketCategoryID, "Result is null");
        //    postTicketCategoryID.ShouldBeEquivalentTo(1);
        //}

        //[Test]
        //public void TestEditingTicketCategory_DoesntReturnNull_ReturnsSameTicketCategoryID()
        //{
        //    //Arrange
        //    _helpDeskTicketCategoryRepository.Setup(
        //        x => x.EditCategoryById(It.IsAny<int>(), It.IsAny<HelpDesk_TicketCategory>()))
        //        .Returns(PutTicketCategory_ResultFromPutReturnInt());


        //    //Act
        //    var putTicketCategoryID = _TicketCategoryController.Put(1, PutTicketCategory());

        //    //Assert
        //    Assert.IsNotNull(putTicketCategoryID, "Result is null");
        //    putTicketCategoryID.ShouldBeEquivalentTo(1);
        //}

        //[Test]
        //public void TestDeleteTicketCategory_ReturnedTrue()
        //{
        //    //Arrange
        //    _helpDeskTicketCategoryRepository.Setup(x => x.DeleteCategoryById(It.IsAny<int>())).Returns(true);

        //    //Act
        //    var isDeleted = _TicketCategoryController.Delete(1);

        //    //Assert
        //    Assert.IsTrue(isDeleted);

        //}

        //private List<HelpDesk_TicketCategory> GetTicketCategoryList()
        //{
        //    var TicketCategoryValues = new List<HelpDesk_TicketCategory>
        //    {
        //        new HelpDesk_TicketCategory
        //        {
        //            Id = 1,
        //            Category = "New Category",
        //            HelpDesk_Tickets = new List<HelpDesk_Tickets>
        //            {
        //                new HelpDesk_Tickets
        //                {
        //                    Id=1,
        //                    Title = "Sample Ticket 1",
        //                    Description = "Sample Description 1",
        //                    Requestor = 1,
        //                    DepartmentID = 1,
        //                    LocationID = 1,
        //                    TicketTypeID  = 1,
        //                    RequestDateTime = new DateTime(),
        //                    RequestedDueDate = new DateTime(),
        //                    PriorityCode = 1,
        //                    StatusID = 1,
        //                    AssignedTo = 1,
        //                    VendorID = 1,
        //                    VendorTicket = "Sample Vendor Ticket 1",
        //                    TicketCategoryID = 1,
        //                    NeedsApproval = true,
        //                    ApprovedBy = 1,
        //                    ApprovedOn = new DateTime()

        //                }
        //            }
        //        },
        //        new HelpDesk_TicketCategory
        //        {
        //            Id = 2,
        //            Category = "Category2",
        //            HelpDesk_Tickets = new List<HelpDesk_Tickets>
        //            {
        //                new HelpDesk_Tickets
        //                {
        //                    Id=2,
        //                    Title = "Sample Ticket 1",
        //                    Description = "Sample Description 1",
        //                    Requestor = 1,
        //                    DepartmentID = 1,
        //                    LocationID = 1,
        //                    RequestDateTime = new DateTime(),
        //                    RequestedDueDate = new DateTime(),
        //                    TicketTypeID  = 1,
        //                    PriorityCode = 1,
        //                    StatusID = 1,
        //                    AssignedTo = 1,
        //                    VendorID = 1,
        //                    VendorTicket = "Sample Vendor Ticket 1",
        //                    TicketCategoryID = 2,
        //                    NeedsApproval = true,
        //                    ApprovedBy = 1,
        //                    ApprovedOn = new DateTime()

        //                }
        //            }
        //        }
        //    };

        //    return TicketCategoryValues;
        //}

        //private List<HelpDesk_TicketCategory_vm> GetTicketCategoryList_ResultForMappingToVM()
        //{
        //    var TicketCategoryValues_Result = new List<HelpDesk_TicketCategory_vm>
        //    {
        //        new HelpDesk_TicketCategory_vm
        //        {
        //            Id = 1,
        //            Category = "New Category"
        //        },
        //        new HelpDesk_TicketCategory_vm
        //        {
        //            Id = 2,
        //            Category = "Category2"
        //        }
        //    };

        //    return TicketCategoryValues_Result;
        //}

        //private HelpDesk_TicketCategory_vm PostTicketCategory()
        //{
        //    return new HelpDesk_TicketCategory_vm
        //    {
        //        Category = "Testing"
        //    };
        //}

        //private int PostTicketCategory_ResultFromPostReturnInt()
        //{
        //    return 1;
        //}

        //private HelpDesk_TicketCategory_vm PutTicketCategory()
        //{
        //    return new HelpDesk_TicketCategory_vm
        //    {
        //        Id = 1,
        //        Category = "TestingChanged"
        //    };
        //}

        //private int PutTicketCategory_ResultFromPutReturnInt()
        //{
        //    return 1;
        //}
    }
    }
