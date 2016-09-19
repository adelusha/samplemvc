using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels;

namespace ServiceDeskSVC.Managers
{
    public interface IDepartmentManager
    {
        List<Department_vm> GetAllDepartments();

        bool DeleteDepartmentById(int id);

        int CreateDepartment(Department_vm location);

        int EditDepartmentById(int id, Department_vm location);        
    }
}
