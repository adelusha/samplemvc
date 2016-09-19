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
    public class HardwareTypeControllerTest
        {
        private HardwareTypeController _HardwareTypeController;
        private Mock<IAssetManagerHardwareAssetTypeRepository> _assetHardwareTypeRepository;
        private IAssetManagerHardwareTypeManager _assetHardwareTypeManager;
        private Mock<ILogger> _logger;

        [SetUp]
        public void BeforeEach()
            {
            _assetHardwareTypeRepository = new Mock<IAssetManagerHardwareAssetTypeRepository>();
            _logger = new Mock<ILogger>();
            _assetHardwareTypeManager = new AssetManagerHardwareTypeManager(_assetHardwareTypeRepository.Object, _logger.Object);
            _HardwareTypeController = new HardwareTypeController(_assetHardwareTypeManager, _logger.Object);
            }

        [Test]
        public void TestEntities_ConfirmMapsIntoViewModel()
            {
            // Arrange
            _assetHardwareTypeRepository.Setup(x => x.GetAllHardwareAssetTypes()).Returns(GetHardwareTypeList);

            // Act
            var allHardwareType = _HardwareTypeController.Get();
            var expectedResult = GetHardwareTypeList_ResultForMappingToVM();

            // Assert
            Assert.IsNotNull(allHardwareType, "Result is null");
            allHardwareType.ShouldBeEquivalentTo(expectedResult);
            }

        [Test]
        public void TestAddingNewHardwareType_DoesntReturnNull_ReturnsNewHardwareTypeID()
            {
            // Arrange
            _assetHardwareTypeRepository.Setup(x => x.CreateHardwareAssetTypes(It.IsAny<AssetManager_Hardware_AssetType>()))
                .Returns(PostHardwareType_ResultFromPostReturnInt());
            // Act
            var postTaskTypeID = _HardwareTypeController.Post(PostHardwareType());
            // Assert
            Assert.IsNotNull(postTaskTypeID, "Result is null");
            postTaskTypeID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestEditingHardwareType_DoesntReturnNull_ReturnsSameTaskTypeID()
            {
            //Arrange
            _assetHardwareTypeRepository.Setup(
                x => x.EditHardwareAssetTypes(It.IsAny<int>(), It.IsAny<AssetManager_Hardware_AssetType>()))
                .Returns(PutHardwareType_ResultFromPutReturnInt());
            //Act
            var putHardwareTypeID = _HardwareTypeController.Put(1, PutHardwareType());
            //Assert
            Assert.IsNotNull(putHardwareTypeID, "Result is null");
            putHardwareTypeID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestDeleteHardwareType_ReturnedTrue()
            {
            //Arrange
            _assetHardwareTypeRepository.Setup(x => x.DeleteHardwareAssetTypes(It.IsAny<int>())).Returns(true);
            //Act
            var isDeleted = _HardwareTypeController.Delete(1);
            //Assert
            Assert.IsTrue(isDeleted);
            }

        private List<AssetManager_Hardware_AssetType> GetHardwareTypeList()
            {
            var HardwareTypeValues = new List<AssetManager_Hardware_AssetType>
            {
                new AssetManager_Hardware_AssetType
                {
                    Id = 1,
                    Name = "Windows 8",
                    DescriptionNotes = "All windows 8 licences",
                    EndOfLifeMo = 24,
                    CategoryCode = 2          
                },
                new AssetManager_Hardware_AssetType
                {
                    Id = 2,
                    Name = "Visual Studio 2013",
                    DescriptionNotes = "All Visual Studio 2013 licences",
                    EndOfLifeMo = 36,
                    CategoryCode = 1,
                }
            };
            return HardwareTypeValues;
            }

        private List<AssetManager_HardwareType_vm> GetHardwareTypeList_ResultForMappingToVM()
            {
            var HardwareTypeValues_Result = new List<AssetManager_HardwareType_vm>
            {
                new AssetManager_HardwareType_vm
                {
                    Id = 1,
                    Name = "Windows 8",
                    DescriptionNotes = "All windows 8 licences",
                    EndOfLifeMo = 24,
                    CategoryCode = 2
                },
                new AssetManager_HardwareType_vm
                {
                    Id = 2,
                    Name = "Visual Studio 2013",
                    DescriptionNotes = "All Visual Studio 2013 licences",
                    EndOfLifeMo = 36,
                    CategoryCode = 1
                }
            };
            return HardwareTypeValues_Result;
            }

        private AssetManager_HardwareType_vm PostHardwareType()
            {
            return new AssetManager_HardwareType_vm
            {
                Id = 3,
                Name = "SharePoint 2013",
                DescriptionNotes = "All SharePoint 2013 licences",
                EndOfLifeMo = 36,
                CategoryCode = 1
            };
            }

        private int PostHardwareType_ResultFromPostReturnInt()
            {
            return 1;
            }

        private AssetManager_HardwareType_vm PutHardwareType()
            {
            return new AssetManager_HardwareType_vm
            {
                Id = 2,
                Name = "Visual Studio 2013 Premium",
                DescriptionNotes = "All Visual Studio 2013 licences",
                EndOfLifeMo = 24,
                CategoryCode = 1
            };
            }

        private int PutHardwareType_ResultFromPutReturnInt()
            {
            return 1;
            }
        }
    }
