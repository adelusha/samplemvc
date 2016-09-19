using System.Collections.Generic;
using FluentAssertions;
using ILogging;
using Moq;
using NUnit.Framework;
using ServiceDeskSVC.Controllers.API;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.Managers;

namespace ServiceDeskSVC.Tests.Controllers
    {
    [TestFixture]
    public class CompaniesControllerTest
        {
        private CompaniesController _CompaniesController;
        private Mock<IAssetManagerCompaniesRepository> _assetCompaniesRepository;
        private IAssetManagerCompaniesManager _assetCompaniesManager;
        private Mock<ILogger> _logger;

        [SetUp]
        public void BeforeEach()
            {
            _assetCompaniesRepository = new Mock<IAssetManagerCompaniesRepository>();
            _logger = new Mock<ILogger>();
            _assetCompaniesManager = new AssetManagerCompaniesManager(_assetCompaniesRepository.Object, _logger.Object);
            _CompaniesController = new CompaniesController(_assetCompaniesManager, _logger.Object);
            }

        [Test]
        public void TestEntities_ConfirmMapsIntoViewModel()
            {
            // Arrange
            _assetCompaniesRepository.Setup(x => x.GetAllCompanies()).Returns(GetCompaniesList);

            // Act
            IEnumerable<AssetManager_Companies_vm> allCompanies = _CompaniesController.Get();
            List<AssetManager_Companies_vm> expectedResult = GetCompaniesList_ResultForMappingToVM();

            // Assert
            Assert.IsNotNull(allCompanies, "Result is null");
            allCompanies.ShouldBeEquivalentTo(expectedResult);
            }

        [Test]
        public void TestAddingNewCompanies_DoesntReturnNull_ReturnsNewCompaniesID()
            {
            // Arrange
            _assetCompaniesRepository.Setup(x => x.CreateCompany(It.IsAny<AssetManager_Companies>()))
                .Returns(PostCompanies_ResultFromPostReturnInt());
            // Act
            int postTaskTypeID = _CompaniesController.Post(PostCompanies());
            // Assert
            Assert.IsNotNull(postTaskTypeID, "Result is null");
            postTaskTypeID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestEditingCompanies_DoesntReturnNull_ReturnsSameTaskTypeID()
            {
            //Arrange
            _assetCompaniesRepository.Setup(
                x => x.EditCompany(It.IsAny<int>(), It.IsAny<AssetManager_Companies>()))
                .Returns(PutCompanies_ResultFromPutReturnInt());
            //Act
            int putCompaniesID = _CompaniesController.Put(1, PutCompanies());
            //Assert
            Assert.IsNotNull(putCompaniesID, "Result is null");
            putCompaniesID.ShouldBeEquivalentTo(1);
            }

        [Test]
        public void TestDeleteCompanies_ReturnedTrue()
            {
            //Arrange
            _assetCompaniesRepository.Setup(x => x.DeleteCompany(It.IsAny<int>())).Returns(true);
            //Act
            bool isDeleted = _CompaniesController.Delete(1);
            //Assert
            Assert.IsTrue(isDeleted);
            }

        private List<AssetManager_Companies> GetCompaniesList()
        {
            var CompaniesValues = new List<AssetManager_Companies>
            {
                new AssetManager_Companies
                {
                    Id = 1,
                    City = "New York",
                    Name = "HP",
                    State = "NY",
                    Street = "14th Street",
                    Zip = "0453",
                    PhoneNumber = "+40-4353454345",
                    Website = "www.hp.com"
                },
                new AssetManager_Companies
                {
                    Id = 2,
                    City = "San Fracisco",
                    Name = "Facebook",
                    State = "California",
                    Street = "16th Street",
                    Zip = "0343",
                    PhoneNumber = "+43-4353454345",
                    Website = "www.facebook.com"
                }
            };
            return CompaniesValues;
        }

        private List<AssetManager_Companies_vm> GetCompaniesList_ResultForMappingToVM()
        {
            var CompaniesValues_Result = new List<AssetManager_Companies_vm>
            {
                new AssetManager_Companies_vm
                {
                    Id = 1,
                    City = "New York",
                    Name = "HP",
                    State = "NY",
                    Street = "14th Street",
                    Zip = "0453",
                    PhoneNumber = "+40-4353454345",
                    Website = "www.hp.com"
                },
                new AssetManager_Companies_vm
                {
                    Id = 2,
                    City = "San Fracisco",
                    Name = "Facebook",
                    State = "California",
                    Street = "16th Street",
                    Zip = "0343",
                    PhoneNumber = "+43-4353454345",
                    Website = "www.facebook.com"
                }
            };
            return CompaniesValues_Result;
        }

        private AssetManager_Companies_vm PostCompanies()
            {
            return new AssetManager_Companies_vm
            {
                Id = 3,
                City = "Seattle",
                Name = "Micorsoft",
                State = "Washigton",
                Street = "3rd Street",
                Website = "www.microsoft.com"
            };
            }

        private int PostCompanies_ResultFromPostReturnInt()
            {
            return 1;
            }

        private AssetManager_Companies_vm PutCompanies()
            {
            return new AssetManager_Companies_vm
            {
                Id = 2,
                City = "Los Angeles",
                Name = "Facebook",
                State = "California",
                Street = "3rd Street",
                Zip = "0343",
                PhoneNumber = "+43-4353454345",
                Website = "www.facebook.com"
            };
            }

        private int PutCompanies_ResultFromPutReturnInt()
            {
            return 1;
            }
        }
    }
