using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers
{
    public interface IAssetManagerCompaniesManager
        {
        List<AssetManager_Companies_vm> GetAllCompanies();

        bool DeleteCompanyById(int id);

        int CreateCompany(AssetManager_Companies_vm company);

        int EditCompanyById(int id, AssetManager_Companies_vm company);

        }
}
