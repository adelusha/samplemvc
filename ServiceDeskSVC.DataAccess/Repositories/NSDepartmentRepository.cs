using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class NSDepartmentRepository:INSDepartmentRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public NSDepartmentRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<Department> GetAllDepartments()
            {
            List<Department> allDepartments = _context.Departments.ToList();
            return allDepartments;
            }

        public bool DeleteDepartmentById(int id)
            {
            bool result = false;
            try
                {
                Department oldDepartment = _context.Departments.FirstOrDefault(x => x.Id == id);
                _context.Departments.Remove(oldDepartment);
                _context.SaveChanges();
                result = true;
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateDepartment(Department Department)
            {
            _context.Departments.Add(Department);
            _context.SaveChanges();
            return Department.Id;
            }

        public int EditDepartmentByID(int id, Department Department)
            {
            try
                {
                Department oldDepartment = _context.Departments.FirstOrDefault(x => x.Id == Department.Id);
                if(oldDepartment != null)
                    {
                    oldDepartment.DepartmentName = Department.DepartmentName;
                    }
                _context.SaveChanges();
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return Department.Id;
            }
        }
    }
