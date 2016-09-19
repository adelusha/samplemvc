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
    public class NSLocationControllerTest
        {
        //private NSLocationController _NSLocationController;
        //private Mock<INSLocationRepository> _NSLocationRepository;
        //private INSLocationManager _NSLocationManager;
        //private Mock<ILogger> _logger;

        //[SetUp]
        //public void BeforeEach()
        //    {
        //    _NSLocationRepository = new Mock<INSLocationRepository>();
        //    _logger = new Mock<ILogger>();
        //    _NSLocationManager = new NSLocationManager(_NSLocationRepository.Object, _logger.Object);
        //    _NSLocationController = new NSLocationController(_NSLocationManager, _logger.Object);
        //    }

        //[Test]
        //public void TestEntities_ConfirmMapsIntoViewModel()
        //    {
        //    // Arrange
        //    _NSLocationRepository.Setup(x => x.GetAllLocations()).Returns(GetNSLocationList());

        //    // Act
        //    var allNSLocations = _NSLocationController.Get();
        //    var expectedResult = GetNSLocationList_ResultForMappingToVM();

        //    // Assert
        //    Assert.IsNotNull(allNSLocations, "Result is null");
        //    allNSLocations.ShouldBeEquivalentTo(expectedResult);
        //    }

        //[Test]
        //public void TestAddingNewNSLocation_DoesntReturnNull_ReturnsNewNSLocationID()
        //    {
        //    // Arrange
        //    _NSLocationRepository.Setup(x => x.CreateLocation(It.IsAny<NSLocation>()))
        //        .Returns(PostNSLocation_ResultFromPostReturnInt());

        //    // Act
        //    var postNSLocationID = _NSLocationController.Post(PostNSLocation());

        //    // Assert
        //    Assert.IsNotNull(postNSLocationID, "Result is null");
        //    postNSLocationID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestEditingNSLocation_DoesntReturnNull_ReturnsSameNSLocationID()
        //    {
        //    //Arrange
        //    _NSLocationRepository.Setup(
        //        x => x.EditLocationByID(It.IsAny<int>(), It.IsAny<NSLocation>()))
        //        .Returns(PutNSLocation_ResultFromPutReturnInt());

        //    //Act
        //    var putNSLocationID = _NSLocationController.Put(1, PutNSLocation());

        //    //Assert
        //    Assert.IsNotNull(putNSLocationID, "Result is null");
        //    putNSLocationID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestDeleteNSLocation_ReturnedTrue()
        //    {
        //    //Arrange
        //    _NSLocationRepository.Setup(x => x.DeleteLocationById(It.IsAny<int>())).Returns(true);

        //    //Act
        //    var isDeleted = _NSLocationController.Delete(1);

        //    //Assert
        //    Assert.IsTrue(isDeleted);
        //    }

        //private List<NSLocation> GetNSLocationList()
        //    {
        //    var NSLocationValues = new List<NSLocation>
        //    {
        //        new NSLocation
        //        {
        //            Id = 1,
        //            LocationCity = "Frankfort",
        //            LocationState = "NY",
        //            LocationZip = 13340
         
        //        },
        //        new NSLocation
        //        {
        //            Id = 2,
        //            LocationCity = "Uttica",
        //            LocationState = "NY",
        //            LocationZip = 13502
        //        }
        //    };

        //    return NSLocationValues;
        //    }

        //private List<NSLocation_vm> GetNSLocationList_ResultForMappingToVM()
        //    {
        //    var NSLocationValues_Result = new List<NSLocation_vm>
        //    {
        //        new NSLocation_vm
        //        {
        //            Id = 1,
        //            LocationCity = "Frankfort",
        //            LocationState = "NY",
        //            LocationZip = 13340
        //        },
        //        new NSLocation_vm
        //        {
        //            Id = 2,
        //            LocationCity = "Uttica",
        //            LocationState = "NY",
        //            LocationZip = 13502
        //        }
        //    };

        //    return NSLocationValues_Result;
        //    }

        //private NSLocation_vm PostNSLocation()
        //    {
        //    return new NSLocation_vm
        //    {
        //        Id = 3,
        //        LocationCity = "Tulsa",
        //        LocationState = "OK",
        //        LocationZip = 74101
        //    };
        //    }

        //private int PostNSLocation_ResultFromPostReturnInt()
        //    {
        //    return 1;
        //    }

        //private NSLocation_vm PutNSLocation()
        //    {
        //    return new NSLocation_vm
        //    {
        //        Id = 1,
        //        LocationCity = "Uttica",
        //        LocationState = "New York",
        //        LocationZip = 13505
        //    };
        //    }

        //private int PutNSLocation_ResultFromPutReturnInt()
        //    {
        //    return 1;
        //    }
        }
    }
