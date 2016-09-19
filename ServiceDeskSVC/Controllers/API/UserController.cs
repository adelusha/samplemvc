using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    /// <summary>
    /// 
    /// </summary>
    public class UserController:ApiController
        {
        private readonly INSUserManager _nsUserManager;
        private readonly ILogger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nsUserManager"></param>
        /// <param name="logger"></param>
        public UserController(INSUserManager nsUserManager, ILogger logger)
            {
            _nsUserManager = nsUserManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NSUser_vm> GetUsersBySearch(string term, int numResults=15)
            {
            _logger.Info("Getting all users for search term: " + term);
            return _nsUserManager.GetUserBySearch(term, numResults);
            }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NSUser_vm> GetAllUsers()
        {
            _logger.Info("Getting all users");
            return _nsUserManager.GetAllUsers();
        }

        /// <summary>
        /// Get user by SID.
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public NSUser_vm GetUserBySID(string sid)
        {
            _logger.Info("Get user by SID");
            return _nsUserManager.GetUserBySID(sid);
        }

        /// <summary>
        /// Get user by login name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public NSUser_vm GetUserByUserName(string userName)
        {
            _logger.Info("Get user by userName");
            return _nsUserManager.GetUserByUserName(userName);
        }
        }
    }