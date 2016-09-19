using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface INSDepartmentRepository
    {
        List<Department> GetAllDepartments();

        bool DeleteDepartmentById(int id);

        int CreateDepartment(Department location);

        int EditDepartmentByID(int id, Department location);
    }
}
