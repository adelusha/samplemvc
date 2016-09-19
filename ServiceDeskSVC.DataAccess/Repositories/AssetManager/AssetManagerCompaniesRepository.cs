using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;


namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class AssetManagerCompaniesRepository:IAssetManagerCompaniesRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public AssetManagerCompaniesRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<AssetManager_Companies> GetAllCompanies()
            {
            List<AssetManager_Companies> allCompanies = _context.AssetManager_Companies.ToList();
            return allCompanies;
            }

        public bool DeleteCompany(int id)
            {
            bool result = false;
            try
                {
                AssetManager_Companies company = _context.AssetManager_Companies.FirstOrDefault(x => x.Id == id);
                _context.AssetManager_Companies.Remove(company);
                _context.SaveChanges();
                result = true;
                _logger.Info("Company with id " + id + " was deleted.");
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateCompany(AssetManager_Companies company)
            {
            _context.AssetManager_Companies.Add(company);
            _context.SaveChanges();
            return company.Id;
            }

        public int EditCompany(int id, AssetManager_Companies company)
            {
            AssetManager_Companies oldCompany = _context.AssetManager_Companies.FirstOrDefault(x => x.Id == id);
            try
                {
                if(oldCompany != null)
                    {
                    oldCompany.City = company.City;
                    oldCompany.Name = company.Name;
                    oldCompany.PhoneNumber = company.PhoneNumber;
                    oldCompany.State = company.State;
                    oldCompany.Street = company.Street;
                    oldCompany.Website = company.Website;
                    oldCompany.Zip = company.Zip;
                    }
                _context.SaveChanges();
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return oldCompany.Id;
            }
        }
    }
