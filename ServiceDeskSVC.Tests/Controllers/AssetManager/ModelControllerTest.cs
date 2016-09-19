using System;
using System.Collections.Generic;
using FluentAssertions;
using ILogging;
using Moq;
using NUnit.Framework;
using ServiceDeskSVC.Controllers.API;
using ServiceDeskSVC.Controllers.API.AssetManager;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.AssetManager;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.Managers;
using ServiceDeskSVC.Managers.Managers.AssetManager;

namespace ServiceDeskSVC.Tests.Controllers
    {
    [TestFixture]
    public class ModelsControllerTest
        {
        private ModelsController _ModelsController;
        private Mock<IAssetManagerModelsRepository> _assetModelsRepository;
        private IAssetManagerModelsManager _assetModelsManager;
        private Mock<ILogger> _logger;

        [SetUp]
        public void BeforeEach()
            {
            _assetModelsRepository = new Mock<IAssetManagerModelsRepository>();
            _logger = new Mock<ILogger>();
            _assetModelsManager = new AssetManagerModelsManager(_assetModelsRepository.Object, _logger.Object);
            _ModelsController = new ModelsController(_assetModelsManager, _logger.Object);
            }

        [Test]
        public void TestEntities_ConfirmMapsIntoViewModel()
            {
            // Arrange
            _assetModelsRepository.Setup(x => x.GetAllModels()).Returns(GetModelsList);

            // Act
            var allModels = _ModelsController.Get();
            var expectedResult = GetModelsList_ResultForMappingToVM();

            // Assert
            Assert.IsNotNull(allModels, "Result is null");
            allModels.ShouldBeEquivalentTo(expectedResult);
            }

        [Test]
        public void TestAddingNewModels_DoesntReturnNull_ReturnsNewModelsID()
            {
            // Arrange
            _assetModelsRepository.Setup(x => x.CreateModel(It.IsAny<AssetManager_Models>()))
                .Returns(PostModels_ResultFromPostReturnInt());
            // Act
            var postTaskTypeID = _ModelsController.Post(PostModels());
            // Assert
            Assert.IsNotNull(postTaskTypeID, "Result is null");
            postTaskTypeID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestEditingModels_DoesntReturnNull_ReturnsSameTaskTypeID()
            {
            //Arrange
            _assetModelsRepository.Setup(
                x => x.EditModel(It.IsAny<int>(), It.IsAny<AssetManager_Models>()))
                .Returns(PutModels_ResultFromPutReturnInt());
            //Act
            var putModelsID = _ModelsController.Put(1, PutModels());
            //Assert
            Assert.IsNotNull(putModelsID, "Result is null");
            putModelsID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestDeleteModels_ReturnedTrue()
            {
            //Arrange
            _assetModelsRepository.Setup(x => x.DeleteModels(It.IsAny<int>())).Returns(true);
            //Act
            var isDeleted = _ModelsController.Delete(1);
            //Assert
            Assert.IsTrue(isDeleted);
            }

        private List<AssetManager_Models> GetModelsList()
            {
            var ModelsValues = new List<AssetManager_Models>
            {
                new AssetManager_Models
                {
                    Id = 1,
                    ModelName = "Model1",
                    CompanyId = 1,
                    DescriptionNotes = "description model1",
                    ManufacturerWebsite = "www.google.com",
                    SupportWebsite = "www.google.com" 
                },
                new AssetManager_Models
                {
                    Id = 2,
                    ModelName = "Model2",
                    CompanyId = 1,
                    DescriptionNotes = "description model2",
                    ManufacturerWebsite = "www.google.com",
                    SupportWebsite = "www.google.com"
                }
            };
            return ModelsValues;
            }

        private List<AssetManager_Models_vm> GetModelsList_ResultForMappingToVM()
            {
            var ModelsValues_Result = new List<AssetManager_Models_vm>
            {
                new AssetManager_Models_vm
                {
                    Id = 1,
                    ModelName = "Model1",
                    CompanyId = 1,
                    DescriptionNotes = "description model1",
                    ManufacturerWebsite = "www.google.com",
                    SupportWebsite = "www.google.com"
                },
                new AssetManager_Models_vm
                {
                    Id = 2,
                    ModelName = "Model2",
                    CompanyId = 1,
                    DescriptionNotes = "description model2",
                    ManufacturerWebsite = "www.google.com",
                    SupportWebsite = "www.google.com"
                }
            };
            return ModelsValues_Result;
            }

        private AssetManager_Models_vm PostModels()
            {
            return new AssetManager_Models_vm
            {
                Id = 3,
                ModelName = "Model3",
                CompanyId = 1,
                DescriptionNotes = "description model3",
                ManufacturerWebsite = "www.google.com",
                SupportWebsite = "www.google.com"
            };
            }

        private int PostModels_ResultFromPostReturnInt()
            {
            return 1;
            }

        private AssetManager_Models_vm PutModels()
            {
            return new AssetManager_Models_vm
            {
                Id = 1,
                ModelName = "Model1 Changed",
                CompanyId = 1,
                DescriptionNotes = "description model1 changed",
                ManufacturerWebsite = "www.google.com",
                SupportWebsite = "www.google.com"
            };
            }

        private int PutModels_ResultFromPutReturnInt()
            {
            return 1;
            }
        }
    }
