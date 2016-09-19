using System;
using System.Collections.Generic;
using FluentAssertions;
using ILogging;
using Moq;
using NUnit.Framework;
using ServiceDeskSVC.Controllers.API;
using ServiceDeskSVC.Controllers.API.AssetManager;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.Managers;

namespace ServiceDeskSVC.Tests.Controllers
    {
    [TestFixture]
    public class SoftwareControllerTest
        {
        //private SoftwareController _SoftwareController;
        //private Mock<IAssetManagerSoftwareRepository> _assetSoftwareRepository;
        //private IAssetManagerSoftwareManager _assetSoftwareManager;
        //private Mock<ILogger> _logger;

        //[SetUp]
        //public void BeforeEach()
        //    {
        //    _assetSoftwareRepository = new Mock<IAssetManagerSoftwareRepository>();
        //    _logger = new Mock<ILogger>();
        //    _assetSoftwareManager = new AssetManagerSoftwareManager(_assetSoftwareRepository.Object, _logger.Object);
        //    _SoftwareController = new SoftwareController(_assetSoftwareManager, _logger.Object);
        //    }

        //[Test]
        //public void TestEntities_ConfirmMapsIntoViewModel()
        //    {
        //    // Arrange
        //    _assetSoftwareRepository.Setup(x => x.GetAllSoftwareAssets()).Returns(GetSoftwareList);

        //    // Act
        //    var allSoftware = _SoftwareController.Get();
        //    var expectedResult = GetSoftwareList_ResultForMappingToVM();

        //    // Assert
        //    Assert.IsNotNull(allSoftware, "Result is null");
        //    allSoftware.ShouldBeEquivalentTo(expectedResult);
        //    }

        //[Test]
        //public void TestAddingNewSoftware_DoesntReturnNull_ReturnsNewSoftwareID()
        //    {
        //    // Arrange
        //    _assetSoftwareRepository.Setup(x => x.CreateSoftwareAsset(It.IsAny<AssetManager_Software>()))
        //        .Returns(PostSoftware_ResultFromPostReturnInt());
        //    // Act
        //    var postTaskTypeID = _SoftwareController.Post(PostSoftware());
        //    // Assert
        //    Assert.IsNotNull(postTaskTypeID, "Result is null");
        //    postTaskTypeID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestEditingSoftware_DoesntReturnNull_ReturnsSameTaskTypeID()
        //    {
        //    //Arrange
        //    _assetSoftwareRepository.Setup(
        //        x => x.EditSoftwareAsset(It.IsAny<int>(), It.IsAny<AssetManager_Software>()))
        //        .Returns(PutSoftware_ResultFromPutReturnInt());
        //    //Act
        //    var putSoftwareID = _SoftwareController.Put(1, PutSoftware());
        //    //Assert
        //    Assert.IsNotNull(putSoftwareID, "Result is null");
        //    putSoftwareID.ShouldBeEquivalentTo(1);
        //    }

        //[Test]
        //public void TestDeleteSoftware_ReturnedTrue()
        //    {
        //    //Arrange
        //    _assetSoftwareRepository.Setup(x => x.DeleteSoftwareAsset(It.IsAny<int>())).Returns(true);
        //    //Act
        //    var isDeleted = _SoftwareController.Delete(1);
        //    //Assert
        //    Assert.IsTrue(isDeleted);
        //    }

        //private List<AssetManager_Software> GetSoftwareList()
        //    {
        //    var SoftwareValues = new List<AssetManager_Software>
        //    {
        //        new AssetManager_Software
        //        {
        //            SoftwareAssetNumber = 1,
        //            CreatedById = 1,
        //            Name = "Visual Studio 2013",
        //            AccountingReqNumber = "1232",
        //            AssociatedCompanyId = 1,
        //            DateOfPurchase = new DateTime(2015, 3, 3),  
        //            LicenseCount = 12,
        //            Notes = "Licenses for Visual Studio 2013",
        //            LicensingInfo = "License no 1",
        //            SoftwareTypeId = 1,
        //            EndOfSupportDate = new DateTime(2015, 11, 5), 
        //            ProductOwnerId = 1,
        //            ProductUsersId = 2,                    
        //            CreatedDate = new DateTime(2015, 3, 3)           
        //        },
        //        new AssetManager_Software
        //        {
        //            SoftwareAssetNumber = 2,
        //            CreatedById = 1,
        //            Name = "SharePoint Enterprise 2013",
        //            AccountingReqNumber = "343432",
        //            AssociatedCompanyId = 1,
        //            DateOfPurchase = new DateTime(2015, 3, 3),  
        //            LicenseCount = 12,
        //            Notes = "Licenses for SharePoint Enterprise 2013",
        //            LicensingInfo = "License no 3",
        //            SoftwareTypeId = 1,
        //            EndOfSupportDate = new DateTime(2016, 11, 5),  
        //            ProductOwnerId = 1,
        //            ProductUsersId = 2,          
        //            CreatedDate = new DateTime(2015, 4, 4)
        //        }
        //    };
        //    return SoftwareValues;
        //    }

        //private List<AssetManager_Software_vm> GetSoftwareList_ResultForMappingToVM()
        //    {
        //    var SoftwareValues_Result = new List<AssetManager_Software_vm>
        //    {
        //        new AssetManager_Software_vm
        //        {
        //            SoftwareAssetNumber = 1,
        //            CreatedById = 1,
        //            Name = "Visual Studio 2013",
        //            AccountingReqNumber = "1232",
        //            AssociatedCompanyId = 1,
        //            DateOfPurchase = new DateTime(2015, 3, 3),  
        //            LicenseCount = 12,
        //            Notes = "Licenses for Visual Studio 2013",
        //            LicensingInfo = "License no 1",
        //            SoftwareTypeId = 1,
        //            EndOfSupportDate = new DateTime(2015, 11, 5), 
        //            ProductOwnerId = 1,
        //            ProductUsersId = 2,                    
        //            CreatedDate = new DateTime(2015, 3, 3)   
        //        },
        //        new AssetManager_Software_vm
        //        {
        //            SoftwareAssetNumber = 2,
        //            CreatedById = 1,
        //            Name = "SharePoint Enterprise 2013",
        //            AccountingReqNumber = "343432",
        //            AssociatedCompanyId = 1,
        //            DateOfPurchase = new DateTime(2015, 3, 3),  
        //            LicenseCount = 12,
        //            Notes = "Licenses for SharePoint Enterprise 2013",
        //            LicensingInfo = "License no 3",
        //            SoftwareTypeId = 1,
        //            EndOfSupportDate = new DateTime(2016, 11, 5),
        //            ProductOwnerId = 1,
        //            ProductUsersId = 2,          
        //            CreatedDate = new DateTime(2015, 4, 4)
        //        }
        //    };
        //    return SoftwareValues_Result;
        //    }

        //private AssetManager_Software_vm PostSoftware()
        //    {
        //    return new AssetManager_Software_vm
        //    {
        //        SoftwareAssetNumber = 2,
        //        CreatedById = 1,
        //        Name = "Windows 8",
        //        AccountingReqNumber = "34243",
        //        AssociatedCompanyId = 1,
        //        DateOfPurchase = new DateTime(2015, 4, 3),
        //        LicenseCount = 12,
        //        Notes = "Licenses for Windows 8",
        //        LicensingInfo = "License no 2",
        //        SoftwareTypeId = 1,
        //        EndOfSupportDate = new DateTime(2017, 11, 5),
        //        ProductOwnerId = 1,
        //        ProductUsersId = 2,
        //        CreatedDate = new DateTime(2015, 4, 4)
        //    };
        //    }

        //private int PostSoftware_ResultFromPostReturnInt()
        //    {
        //    return 1;
        //    }

        //private AssetManager_Software_vm PutSoftware()
        //    {
        //    return new AssetManager_Software_vm
        //    {
        //        SoftwareAssetNumber = 1,
        //        Name = "Visual Studio Premium 2013",
        //        AccountingReqNumber = "1232",
        //        AssociatedCompanyId = 1,
        //        DateOfPurchase = new DateTime(2015, 3, 3),
        //        LicenseCount = 12,
        //        Notes = "Licenses for Visual Studio Premium 2013",
        //        LicensingInfo = "License no 1",
        //        SoftwareTypeId = 1,
        //        EndOfSupportDate =  new DateTime(2015, 11, 5),
        //        ProductOwnerId = 1,
        //        ProductUsersId = 2,
        //        ModifiedById = 1,
        //        ModifiedDate = new DateTime(2015, 4, 10)
        //    };
        //    }

        //private int PutSoftware_ResultFromPutReturnInt()
        //    {
        //    return 1;
        //    }
        }
    }
