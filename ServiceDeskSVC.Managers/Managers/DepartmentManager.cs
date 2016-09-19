using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class DepartmentManager:IDepartmentManager
        {
        private readonly INSDepartmentRepository _nsDepartmentRepository;
        private readonly ILogger _logger;

        public DepartmentManager(INSDepartmentRepository nsDepartmentRepository, ILogger logger)
            {
            _nsDepartmentRepository = nsDepartmentRepository;
            _logger = logger;
            }

        public List<Department_vm> GetAllDepartments()
            {
            var allDepartments = _nsDepartmentRepository.GetAllDepartments();
            if(allDepartments == null || allDepartments.Count == 0)
                {
                _logger.Warn("There are no ticket types.");
                }

            return allDepartments.Select(mapEntityToViewModelDepartment).ToList();
            }

        public bool DeleteDepartmentById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _nsDepartmentRepository.DeleteDepartmentById(id);
            }

        public int CreateDepartment(Department_vm Department)
            {
            return _nsDepartmentRepository.CreateDepartment(mapViewModelToEntityDepartment(Department));
            }

        public int EditDepartmentById(int id, Department_vm Department)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _nsDepartmentRepository.EditDepartmentByID(id, mapViewModelToEntityDepartment(Department));
            }

        private Department_vm mapEntityToViewModelDepartment(Department EFDepartment)
            {
            return new Department_vm
            {
                Id = EFDepartment.Id,
                DepartmentName = EFDepartment.DepartmentName
            };
            }

        private Department mapViewModelToEntityDepartment(Department_vm VMDepartment)
            {
            return new Department
            {
                Id = VMDepartment.Id,
                DepartmentName = VMDepartment.DepartmentName             
            };
            }
        }
    }
