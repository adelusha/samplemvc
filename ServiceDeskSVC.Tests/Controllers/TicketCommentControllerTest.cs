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
    public class TicketCommentControllerTest
        {
        //private TicketCommentController _TicketCommentController;
        //private Mock<IHelpDeskTicketCommentRepository> _helpDeskTicketCommentRepository;
        //private IHelpDeskTicketCommentManager _helpDeskTicketCommentManager;
        //private Mock<ILogger> _logger;
        //private int _TicketId;

        //[SetUp]
        //public void BeforeEach()
        //    {
        //    _helpDeskTicketCommentRepository = new Mock<IHelpDeskTicketCommentRepository>();
        //    _logger = new Mock<ILogger>();
        //    _helpDeskTicketCommentManager = new HelpDeskTicketCommentManager(_helpDeskTicketCommentRepository.Object, _logger.Object);
        //    _TicketCommentController = new TicketCommentController(_helpDeskTicketCommentManager, _logger.Object);
        //    _TicketId = 1;
        //    }

        //[Test]
        //public void TestEntities_ConfirmMapsIntoViewModel()
        //    {

        //    // Arrange
        //    _helpDeskTicketCommentRepository.Setup(x => x.GetAllTicketComments(_TicketId)).Returns(GetTicketCommentList());

        //    // Act
        //    var allTicketComments = _TicketCommentController.Get(_TicketId);
        //    var expectedResult = GetTicketCommentList_ResultForMappingToVM();

        //    // Assert
        //    Assert.IsNotNull(allTicketComments, "Result is null");
        //    allTicketComments.ShouldBeEquivalentTo(expectedResult);
        //    }

        //[Test]
        //public void TestAddingNewTicketComment_DoesntReturnNull_ReturnsNewTicketCommentID()
        //    {
        //    // Arrange
        //    _helpDeskTicketCommentRepository.Setup(x => x.CreateTicketComment(_TicketId, It.IsAny<HelpDesk_TicketComments>()))
        //        .Returns(PostTicketComment_ResultFromPostReturnInt());

        //    // Act
        //    var postTicketCommentID = _TicketCommentController.Post(_TicketId, PostTicketComment());

        //    // Assert
        //    Assert.IsNotNull(postTicketCommentID, "Result is null");
        //    postTicketCommentID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestEditingTicketComment_DoesntReturnNull_ReturnsSameTicketCommentID()
        //    {
        //    //Arrange
        //    _helpDeskTicketCommentRepository.Setup(
        //        x => x.EditTicketCommentById(It.IsAny<int>(), It.IsAny<HelpDesk_TicketComments>()))
        //        .Returns(PutTicketComment_ResultFromPutReturnInt());


        //    //Act
        //    var putTicketCommentID = _TicketCommentController.Put(1, PutTicketComment());

        //    //Assert
        //    Assert.IsNotNull(putTicketCommentID, "Result is null");
        //    putTicketCommentID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestDeleteTicketComment_ReturnedTrue()
        //    {
        //    //Arrange
        //    _helpDeskTicketCommentRepository.Setup(x => x.DeleteTicketCommentById(It.IsAny<int>())).Returns(true);

        //    //Act
        //    var isDeleted = _TicketCommentController.Delete(1);

        //    //Assert
        //    Assert.IsTrue(isDeleted);

        //    }

        //private List<HelpDesk_TicketComments> GetTicketCommentList()
        //    {
        //    var TicketCommentValues = new List<HelpDesk_TicketComments>
        //    {
        //        new HelpDesk_TicketComments
        //        {
        //            Id = 1,
        //            Comment = "Comment1",
        //            TicketID = 1,
        //            CommentDateTime = new DateTime(2014, 12, 14),
        //            CommentTypeID = 1,

        //            HelpDesk_Tickets = new HelpDesk_Tickets
        //            {
        //                Id = 1,
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
        //        },

        //        new HelpDesk_TicketComments
        //        {
        //            Id = 2,
        //            Comment = "Comment2",
        //            TicketID = 1,
        //            CommentDateTime = new DateTime(2014, 12, 11),
        //            Author = 1,
        //            CommentTypeID = 2,

        //            HelpDesk_Tickets = new HelpDesk_Tickets
        //            {
        //                Id = 1,
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

        //    };

        //    return TicketCommentValues;
        //    }

        //private List<HelpDesk_TicketComments_vm> GetTicketCommentList_ResultForMappingToVM()
        //    {
        //    var TicketCommentValues_Result = new List<HelpDesk_TicketComments_vm>
        //         {
        //             new HelpDesk_TicketComments_vm
        //             {
        //             Id = 1,
        //             Comment = "Comment1",
        //             TicketID = 1,
        //             CommentDateTime = new DateTime(2014, 12, 14),
        //             Author = 1,
        //             CommentTypeID = 1
        //             },
        //             new HelpDesk_TicketComments_vm
        //             {
        //             Id = 2,
        //             Comment = "Comment2",
        //             TicketID = 1,
        //             CommentDateTime = new DateTime(2014, 12, 11),
        //             Author = 1,
        //             CommentTypeID = 2
        //             }
        //         };

        //    return TicketCommentValues_Result;
        //    }

        //private HelpDesk_TicketComments_vm PostTicketComment()
        //    {
        //    return new HelpDesk_TicketComments_vm
        //    {
        //        Comment = "Testing"
        //    };
        //    }

        //private int PostTicketComment_ResultFromPostReturnInt()
        //    {
        //    return 1;
        //    }

        //private HelpDesk_TicketComments_vm PutTicketComment()
        //    {
        //    return new HelpDesk_TicketComments_vm
        //    {
        //        Id = 1,
        //        Comment = "TestingChanged"
        //    };
        //    }

        //private int PutTicketComment_ResultFromPutReturnInt()
        //    {
        //    return 1;
        //    }
        }
    }
