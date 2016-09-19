using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class AssetManagerCompaniesManager:IAssetManagerCompaniesManager
        {
        private readonly IAssetManagerCompaniesRepository _assetManagerCompaniesRepository;
        private readonly ILogger _logger;
        public AssetManagerCompaniesManager(IAssetManagerCompaniesRepository assetManagerCompaniesRepository, ILogger logger)
            {
            _assetManagerCompaniesRepository = assetManagerCompaniesRepository;
            _logger = logger;
            }

        public AssetManager_Companies_vm mapEntityToViewcompany(AssetManager_Companies EFcompany)
            {
            _logger.Debug("Mapping Entity to company View company.");
            var vmC = new AssetManager_Companies_vm
                {
                    Id = EFcompany.Id,
                    City = EFcompany.City,
                    Name = EFcompany.Name,
                    PhoneNumber = EFcompany.PhoneNumber,
                    State = EFcompany.State,
                    Street = EFcompany.Street,
                    Website = EFcompany.Website,
                    Zip = EFcompany.Zip
                };

            return vmC;
            }

        private AssetManager_Companies mapViewcompanyToEntitycompany(AssetManager_Companies_vm VMcompany)
            {
            var Companies = new AssetManager_Companies
                {
                    Id = VMcompany.Id,
                    City = VMcompany.City,
                    Name = VMcompany.Name,
                    PhoneNumber = VMcompany.PhoneNumber,
                    State = VMcompany.State,
                    Street = VMcompany.Street,
                    Website = VMcompany.Website,
                    Zip = VMcompany.Zip
                };

            return Companies;
            }

        public List<AssetManager_Companies_vm> GetAllCompanies()
            {
            var allCompanies = _assetManagerCompaniesRepository.GetAllCompanies();
            return allCompanies.Select(mapEntityToViewcompany).ToList();
            }

        public bool DeleteCompanyById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _assetManagerCompaniesRepository.DeleteCompany(id);
            }

        public int CreateCompany(AssetManager_Companies_vm company)
            {
            return _assetManagerCompaniesRepository.CreateCompany(mapViewcompanyToEntitycompany(company));
            }

        public int EditCompanyById(int id, AssetManager_Companies_vm company)
            {
            return _assetManagerCompaniesRepository.EditCompany(id, mapViewcompanyToEntitycompany(company));
            }
        }
    }
