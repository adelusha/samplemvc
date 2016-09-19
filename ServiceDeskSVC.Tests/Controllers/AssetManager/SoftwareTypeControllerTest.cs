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
    public class SoftwareTypeControllerTest
        {
        private SoftwareTypeController _SoftwareTypeController;
        private Mock<IAssetManagerSoftwareAssetTypeRepository> _assetSoftwareTypeRepository;
        private IAssetManagerSoftwareTypeManager _assetSoftwareTypeManager;
        private Mock<ILogger> _logger;

        [SetUp]
        public void BeforeEach()
            {
            _assetSoftwareTypeRepository = new Mock<IAssetManagerSoftwareAssetTypeRepository>();
            _logger = new Mock<ILogger>();
            _assetSoftwareTypeManager = new AssetManagerSoftwareTypeManager(_assetSoftwareTypeRepository.Object, _logger.Object);
            _SoftwareTypeController = new SoftwareTypeController(_assetSoftwareTypeManager, _logger.Object);
            }

        [Test]
        public void TestEntities_ConfirmMapsIntoViewModel()
            {
            // Arrange
            _assetSoftwareTypeRepository.Setup(x => x.GetAllSoftwareAssetTypes()).Returns(GetSoftwareTypeList);

            // Act
            var allSoftwareType = _SoftwareTypeController.Get();
            var expectedResult = GetSoftwareTypeList_ResultForMappingToVM();

            // Assert
            Assert.IsNotNull(allSoftwareType, "Result is null");
            allSoftwareType.ShouldBeEquivalentTo(expectedResult);
            }

        [Test]
        public void TestAddingNewSoftwareType_DoesntReturnNull_ReturnsNewSoftwareTypeID()
            {
            // Arrange
            _assetSoftwareTypeRepository.Setup(x => x.CreateSoftwareAssetTypes(It.IsAny<AssetManager_Software_AssetType>()))
                .Returns(PostSoftwareType_ResultFromPostReturnInt());
            // Act
            var postTaskTypeID = _SoftwareTypeController.Post(PostSoftwareType());
            // Assert
            Assert.IsNotNull(postTaskTypeID, "Result is null");
            postTaskTypeID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestEditingSoftwareType_DoesntReturnNull_ReturnsSameTaskTypeID()
            {
            //Arrange
            _assetSoftwareTypeRepository.Setup(
                x => x.EditSoftwareAssetTypes(It.IsAny<int>(), It.IsAny<AssetManager_Software_AssetType>()))
                .Returns(PutSoftwareType_ResultFromPutReturnInt());
            //Act
            var putSoftwareTypeID = _SoftwareTypeController.Put(1, PutSoftwareType());
            //Assert
            Assert.IsNotNull(putSoftwareTypeID, "Result is null");
            putSoftwareTypeID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestDeleteSoftwareType_ReturnedTrue()
            {
            //Arrange
            _assetSoftwareTypeRepository.Setup(x => x.DeleteSoftwareAssetTypes(It.IsAny<int>())).Returns(true);
            //Act
            var isDeleted = _SoftwareTypeController.Delete(1);
            //Assert
            Assert.IsTrue(isDeleted);
            }

        private List<AssetManager_Software_AssetType> GetSoftwareTypeList()
            {
            var SoftwareTypeValues = new List<AssetManager_Software_AssetType>
            {
                new AssetManager_Software_AssetType
                {
                    Id = 1,
                    Name = "Printers",
                    DescriptionNotes = "All printer deivces",
                    EndOfLifeMo = 24,
                    CategoryCode = 2         
                },
                new AssetManager_Software_AssetType
                {
                    Id = 2,
                    Name = "Laptops",
                    DescriptionNotes = "All laptop devices",
                    EndOfLifeMo = 36,
                    CategoryCode = 1,
                }
            };
            return SoftwareTypeValues;
            }

        private List<AssetManager_SoftwareType_vm> GetSoftwareTypeList_ResultForMappingToVM()
            {
            var SoftwareTypeValues_Result = new List<AssetManager_SoftwareType_vm>
            {
                new AssetManager_SoftwareType_vm
                {
                    Id = 1,
                    Name = "Printers",
                    DescriptionNotes = "All printer deivces",
                    EndOfLifeMo = 24,
                    CategoryCode = 2
                },
                new AssetManager_SoftwareType_vm
                {
                    Id = 2,
                    Name = "Laptops",
                    DescriptionNotes = "All laptop devices",
                    EndOfLifeMo = 36,
                    CategoryCode = 1
                }
            };
            return SoftwareTypeValues_Result;
            }

        private AssetManager_SoftwareType_vm PostSoftwareType()
            {
            return new AssetManager_SoftwareType_vm
            {
                Id = 3,
                Name = "Phones",
                DescriptionNotes = "All phones",
                EndOfLifeMo = 36,
                CategoryCode = 1
            };
            }

        private int PostSoftwareType_ResultFromPostReturnInt()
            {
            return 1;
            }

        private AssetManager_SoftwareType_vm PutSoftwareType()
            {
            return new AssetManager_SoftwareType_vm
            {
                Id = 2,
                Name = "Laptops and Notebooks",
                DescriptionNotes = "All laptop devices",
                EndOfLifeMo = 24,
                CategoryCode = 1
            };
            }

        private int PutSoftwareType_ResultFromPutReturnInt()
            {
            return 1;
            }
        }
    }
