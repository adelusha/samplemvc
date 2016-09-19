using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface IAssetManagerCompaniesRepository
    {
        List<AssetManager_Companies> GetAllCompanies();

        bool DeleteCompany(int id);

        int CreateCompany(AssetManager_Companies company);

        int EditCompany(int id, AssetManager_Companies company);
        }
    }
