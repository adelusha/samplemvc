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
    public class TaskControllerTest
        {
//        private TasksController _TaskController;
//        private Mock<IHelpDeskTasksRepository> _helpDeskTaskRepository;
//        private IHelpDeskTaskManager _helpDeskTaskManager;
//        private Mock<ILogger> _logger;

//        [SetUp]
//        public void BeforeEach()
//            {
//            _helpDeskTaskRepository = new Mock<IHelpDeskTasksRepository>();
//            _logger = new Mock<ILogger>();
//            _helpDeskTaskManager = new HelpDeskTaskManager(_helpDeskTaskRepository.Object, _logger.Object);
//            _TaskController = new TasksController(_helpDeskTaskManager, _logger.Object);
//            }


//        [Test]
//        public void TestAddingNewTask_DoesntReturnNull_ReturnsNewTaskID()
//            {
//            // Arrange
//            _helpDeskTaskRepository.Setup(x => x.CreateTask(It.IsAny<HelpDesk_Tasks>()))
//                .Returns(PostTask_ResultFromPostReturnInt());
//            // Act
//            var postTaskTypeID = _TaskController.Post(PostTask());
//            // Assert
//            Assert.IsNotNull(postTaskTypeID, "Result is null");
//            postTaskTypeID.ShouldBeEquivalentTo(1);
//            }

//        [Test]
//        public void TestEditingTask_DoesntReturnNull_ReturnsSameTaskTypeID()
//            {
//            //Arrange
//            _helpDeskTaskRepository.Setup(
//                x => x.EditTask(It.IsAny<int>(), It.IsAny<HelpDesk_Tasks>()))
//                .Returns(PutTask_ResultFromPutReturnInt());
//            //Act
//            var putTaskID = _TaskController.Put(1, PutTask());
//            //Assert
//            Assert.IsNotNull(putTaskID, "Result is null");
//            putTaskID.ShouldBeEquivalentTo(1);
//            }

//        [Test]
//        public void TestDeleteTaskType_ReturnedTrue()
//            {
//            //Arrange
//            _helpDeskTaskRepository.Setup(x => x.DeleteTask(It.IsAny<int>())).Returns(true);
//            //Act
//            var isDeleted = _TaskController.Delete(1);
//            //Assert
//            Assert.IsTrue(isDeleted);
//            }

//        private List<HelpDesk_Tasks> GetTaskList()
//            {
//            var TaskValues = new List<HelpDesk_Tasks>
//            {
//                new HelpDesk_Tasks
//                {
//                    Id = 1,
//                    Title = "Sample Task 1",
//                    Description = "Sample Description 1",
//                    AssignedTo = 1,
//                    CreatedDateTime = new DateTime(2014, 9, 3),
//                    TicketID = 1,
//                    HelpDesk_TaskStatus = new HelpDesk_TaskStatus(){Status = "Open"},
//                    StatusID = 1,
//                    HelpDesk_Tickets = new HelpDesk_Tickets()
//                    {
//                        Id = 1,
//                        Title = "Ticket 1",
//                        RequestDateTime = DateTime.Now
//                    }                    
//            },
                
//            new HelpDesk_Tasks()
//            {
//                Id = 2,
//                Title = "Sample Ticket 1",
//                Description = "Sample Description 1",
//                AssignedTo = 1,
//                CreatedDateTime = new DateTime(2014, 12, 3),
//                TicketID = 1,
//                HelpDesk_TaskStatus =  new HelpDesk_TaskStatus(){Status = "Closed"},
//                StatusID = 2,
//                HelpDesk_Tickets = new HelpDesk_Tickets()
//                    {
//                        Id = 1,
//                        Title = "Ticket 1",
//                        RequestDateTime = DateTime.Now
//                    }
//}
//            };
//            return TaskValues;
//            }

//        private List<HelpDesk_Tasks_View_vm> GetTaskList_ResultForMappingToVM()
//            {
//            var TaskValues_Result = new List<HelpDesk_Tasks_View_vm>
//            {
//                new HelpDesk_Tasks_View_vm
//                {
//                    Id = 1,
//                    Title = "Sample Task 1",
//                    Description = "Sample Description 1",
//                    AssignedTo = 1,
//                    CreatedDateTime = new DateTime(2014, 9, 3),
//                    TicketID = 1,
//                    Status= "Open"
//                },
//                new HelpDesk_Tasks_View_vm
//            {
//                Id = 2,
//                Title = "Sample Ticket 1",
//                Description = "Sample Description 1",
//                AssignedTo = 1,
//                CreatedDateTime = new DateTime(2014, 12, 3),
//                TicketID = 1,
//                Status = "Closed"
//            }

//            };
//            return TaskValues_Result;
//            }

//        private HelpDesk_Tasks_vm PostTask()
//            {
//            return new HelpDesk_Tasks_vm
//            {
//                Id = 2,
//                Title = "Sample Ticket 1",
//                Description = "Sample Description 1",
//                AssignedTo = 1,
//                CreatedDateTime = DateTime.Now,
//                TicketID = 1,
//                StatusID = 2
//            };
//            }

//        private int PostTask_ResultFromPostReturnInt()
//            {
//            return 1;
//            }

//        private HelpDesk_Tasks_vm PutTask()
//            {
//            return new HelpDesk_Tasks_vm
//            {
//                Id = 1,
//            };
//            }

//        private int PutTask_ResultFromPutReturnInt()
//            {
//            return 1;
//            }
        }
    }
