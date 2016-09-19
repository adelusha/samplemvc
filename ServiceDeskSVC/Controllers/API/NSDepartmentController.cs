using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class NSDepartmentController:ApiController
        {
        private readonly IDepartmentManager _nsDepartmentManager;
        private readonly ILogger _logger;
        public NSDepartmentController(IDepartmentManager nsDepartmentManager, ILogger logger)
            {
            _nsDepartmentManager = nsDepartmentManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department_vm> Get()
            {
            _logger.Info("Getting all Departments.");
            return _nsDepartmentManager.GetAllDepartments();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]Department_vm value)
            {
            _logger.Info("Adding a new Department.");
            return _nsDepartmentManager.CreateDepartment(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]Department_vm value)
            {
            _logger.Info("Editing the Department wiht id" + id);
            return _nsDepartmentManager.EditDepartmentById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the Department with id " + id);
            return _nsDepartmentManager.DeleteDepartmentById(id);
            }
        }
    }