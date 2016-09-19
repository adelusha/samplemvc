using System;
using System.Collections.Generic;
using FluentAssertions;
using ILogging;
using Moq;
using NUnit.Framework;
using ServiceDeskSVC.Controllers.API;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.Managers;

namespace ServiceDeskSVC.Tests.Controllers
    {
    [TestFixture]
    public class TaskStatusControllerTest
        {
        //private TaskStatusController _TaskStatusController;
        //private Mock<IHelpDeskTasksStatusRepository> _helpDeskTaskStatusRepository;
        //private IHelpDeskTaskStatusManager _helpDeskTaskStatusManager;
        //private Mock<ILogger> _logger;

        //[SetUp]
        //public void BeforeEach()
        //    {
        //    _helpDeskTaskStatusRepository = new Mock<IHelpDeskTasksStatusRepository>();
        //    _logger = new Mock<ILogger>();
        //    _helpDeskTaskStatusManager = new HelpDeskTaskStatusManager(_helpDeskTaskStatusRepository.Object, _logger.Object);
        //    _TaskStatusController = new TaskStatusController(_helpDeskTaskStatusManager, _logger.Object);
        //    }

        //[Test]
        //public void TestEntities_ConfirmMapsIntoViewModel()
        //    {
        //    // Arrange
        //    _helpDeskTaskStatusRepository.Setup(x => x.GetAllTaskStatuses()).Returns(GetTaskStatusList);

        //    // Act
        //    var allTaskStatuses = _TaskStatusController.Get();
        //    var expectedResult = GetTaskStatusList_ResultForMappingToVM();

        //    // Assert
        //    Assert.IsNotNull(allTaskStatuses, "Result is null");
        //    allTaskStatuses.ShouldBeEquivalentTo(expectedResult);
        //    }

        //[Test]
        //public void TestAddingNewTaskStatus_DoesntReturnNull_ReturnsNewTaskStatusID()
        //    {
        //    // Arrange
        //    _helpDeskTaskStatusRepository.Setup(x => x.CreateTaskStatus(It.IsAny<HelpDesk_TaskStatus>()))
        //        .Returns(PostTaskStatus_ResultFromPostReturnInt());
        //    // Act
        //    var postTaskTypeID = _TaskStatusController.Post(PostTaskStatus());
        //    // Assert
        //    Assert.IsNotNull(postTaskTypeID, "Result is null");
        //    postTaskTypeID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestEditingTaskStatus_DoesntReturnNull_ReturnsSameTaskTypeID()
        //    {
        //    //Arrange
        //    _helpDeskTaskStatusRepository.Setup(
        //        x => x.EditTaskStatus(It.IsAny<int>(), It.IsAny<HelpDesk_TaskStatus>()))
        //        .Returns(PutTaskStatus_ResultFromPutReturnInt());
        //    //Act
        //    var putTaskStatusID = _TaskStatusController.Put(1, PutTaskStatus());
        //    //Assert
        //    Assert.IsNotNull(putTaskStatusID, "Result is null");
        //    putTaskStatusID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestDeleteTaskType_ReturnedTrue()
        //    {
        //    //Arrange
        //    _helpDeskTaskStatusRepository.Setup(x => x.DeleteTaskStatus(It.IsAny<int>())).Returns(true);
        //    //Act
        //    var isDeleted = _TaskStatusController.Delete(1);
        //    //Assert
        //    Assert.IsTrue(isDeleted);
        //    }

        //private List<HelpDesk_TaskStatus> GetTaskStatusList()
        //    {
        //    var TaskStatusValues = new List<HelpDesk_TaskStatus>
        //    {
        //        new HelpDesk_TaskStatus
        //        {
        //            Id = 1,
        //            Status = "Open",
        //            HelpDesk_Tasks = new List<HelpDesk_Tasks>
        //            {
        //                new HelpDesk_Tasks()
        //                {
        //                    Id=1,
        //                    Title = "Sample Task 1",
        //                    Description = "Sample Description 1",
        //                    StatusID = 1,
        //                    AssignedTo = 1,
        //                    CreatedDateTime = DateTime.Now,
        //                    TicketID = 1,

        //                }
        //            }
        //        },
        //        new HelpDesk_TaskStatus
        //        {
        //            Id = 2,
        //            Status = "Closed",
        //            HelpDesk_Tasks = new List<HelpDesk_Tasks>
        //            {
        //                new HelpDesk_Tasks
        //                {
        //                    Id=2,
        //                    Title = "Sample Ticket 1",
        //                    Description = "Sample Description 1",
        //                    StatusID = 1,
        //                    AssignedTo = 1,

        //                }
        //            }
        //        }
        //    };
        //    return TaskStatusValues;
        //    }

        //private List<HelpDesk_TaskStatus_vm> GetTaskStatusList_ResultForMappingToVM()
        //    {
        //    var TaskStatusValues_Result = new List<HelpDesk_TaskStatus_vm>
        //    {
        //        new HelpDesk_TaskStatus_vm
        //        {
        //            Id = 1,
        //            Status = "Open"
        //        },
        //        new HelpDesk_TaskStatus_vm
        //        {
        //            Id = 2,
        //            Status = "Closed"
        //        }
        //    };
        //    return TaskStatusValues_Result;
        //    }

        //private HelpDesk_TaskStatus_vm PostTaskStatus()
        //    {
        //    return new HelpDesk_TaskStatus_vm
        //    {
        //        Status = "Testing"
        //    };
        //    }

        //private int PostTaskStatus_ResultFromPostReturnInt()
        //    {
        //    return 1;
        //    }

        //private HelpDesk_TaskStatus_vm PutTaskStatus()
        //    {
        //    return new HelpDesk_TaskStatus_vm
        //    {
        //        Id = 1,
        //        Status = "TestingChanged"
        //    };
        //    }

        //private int PutTaskStatus_ResultFromPutReturnInt()
        //    {
        //    return 1;
        //    }
        }
    }
