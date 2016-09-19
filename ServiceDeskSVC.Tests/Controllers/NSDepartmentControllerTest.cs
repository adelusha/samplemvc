using System.Collections.Generic;
using FluentAssertions;
using ILogging;
using Moq;
using NUnit.Framework;
using ServiceDeskSVC.Controllers.API;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.Managers;

namespace ServiceDeskSVC.Tests.Controllers
    {
    [TestFixture]
    public class NSDepartmentControllerTest
        {
        //private NSDepartmentController _NSDepartmentController;
        //private Mock<INSDepartmentRepository> _NSDepartmentRepository;
        //private IDepartmentManager _NSDepartmentManager;
        //private Mock<ILogger> _logger;

        //[SetUp]
        //public void BeforeEach()
        //    {
        //    _NSDepartmentRepository = new Mock<INSDepartmentRepository>();
        //    _logger = new Mock<ILogger>();
        //    _NSDepartmentManager = new DepartmentManager(_NSDepartmentRepository.Object, _logger.Object);
        //    _NSDepartmentController = new NSDepartmentController(_NSDepartmentManager, _logger.Object);
        //    }

        //[Test]
        //public void TestEntities_ConfirmMapsIntoViewModel()
        //    {
        //    // Arrange
        //    _NSDepartmentRepository.Setup(x => x.GetAllDepartments()).Returns(GetNSDepartmentList());

        //    // Act
        //    var allNSDepartments = _NSDepartmentController.Get();
        //    var expectedResult = GetNSDepartmentList_ResultForMappingToVM();

        //    // Assert
        //    Assert.IsNotNull(allNSDepartments, "Result is null");
        //    allNSDepartments.ShouldBeEquivalentTo(expectedResult);
        //    }

        //[Test]
        //public void TestAddingNewNSDepartment_DoesntReturnNull_ReturnsNewNSDepartmentID()
        //    {
        //    // Arrange
        //    _NSDepartmentRepository.Setup(x => x.CreateDepartment(It.IsAny<Department>()))
        //        .Returns(PostNSDepartment_ResultFromPostReturnInt());

        //    // Act
        //    var postNSDepartmentID = _NSDepartmentController.Post(PostNSDepartment());

        //    // Assert
        //    Assert.IsNotNull(postNSDepartmentID, "Result is null");
        //    postNSDepartmentID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestEditingNSDepartment_DoesntReturnNull_ReturnsSameNSDepartmentID()
        //    {
        //    //Arrange
        //    _NSDepartmentRepository.Setup(
        //        x => x.EditDepartmentByID(It.IsAny<int>(), It.IsAny<Department>()))
        //        .Returns(PutNSDepartment_ResultFromPutReturnInt());

        //    //Act
        //    var putNSDepartmentID = _NSDepartmentController.Put(1, PutNSDepartment());

        //    //Assert
        //    Assert.IsNotNull(putNSDepartmentID, "Result is null");
        //    putNSDepartmentID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestDeleteNSDepartment_ReturnedTrue()
        //    {
        //    //Arrange
        //    _NSDepartmentRepository.Setup(x => x.DeleteDepartmentById(It.IsAny<int>())).Returns(true);

        //    //Act
        //    var isDeleted = _NSDepartmentController.Delete(1);

        //    //Assert
        //    Assert.IsTrue(isDeleted);
        //    }

        //private List<Department> GetNSDepartmentList()
        //    {
        //    var NSDepartmentValues = new List<Department>
        //    {
        //        new Department
        //        {
        //            Id = 1,
        //            DepartmentName = "IT"
         
        //        },
        //        new Department
        //        {
        //            Id = 2,
        //            DepartmentName = "Marketing"
        //        }
        //    };

        //    return NSDepartmentValues;
        //    }

        //private List<Department_vm> GetNSDepartmentList_ResultForMappingToVM()
        //    {
        //    var NSDepartmentValues_Result = new List<Department_vm>
        //    {
        //        new Department_vm
        //        {
        //            Id = 1,
        //            DepartmentName = "IT"

        //        },
        //        new Department_vm
        //        {
        //            Id = 2,
        //            DepartmentName = "Marketing"
        //        }
        //    };

        //    return NSDepartmentValues_Result;
        //    }

        //private Department_vm PostNSDepartment()
        //    {
        //    return new Department_vm
        //    {
        //        Id = 3,
        //        DepartmentName = "Accounting"
        //    };
        //    }

        //private int PostNSDepartment_ResultFromPostReturnInt()
        //    {
        //    return 1;
        //    }

        //private Department_vm PutNSDepartment()
        //    {
        //    return new Department_vm
        //    {
        //        Id = 1,
        //        DepartmentName = "IT Analysts"
        //    };
        //    }

        //private int PutNSDepartment_ResultFromPutReturnInt()
        //    {
        //    return 1;
        //    }
        }
    }
