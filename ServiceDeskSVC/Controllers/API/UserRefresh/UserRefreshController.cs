using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.UserRefresh;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.UserRefresh;

namespace ServiceDeskSVC.Controllers.API.UserRefresh
{

    /// <summary>
    /// Refreshes the User Table from the Active Directory
    /// </summary>
    public class UserRefreshController : ApiController
    {

        private readonly IUserRefreshManager _userRefreshManager;
        private readonly ILogger _logger;
        public UserRefreshController(IUserRefreshManager userRefreshManager, ILogger logger)
        {
            _userRefreshManager = userRefreshManager;
            _logger = logger;
        }

        // GET: api/UserRefresh
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserRefreshReturn Get()
        {
            return _userRefreshManager.RunRefreshForAllUsers();
        }

        //// GET: api/UserRefresh/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/UserRefresh
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/UserRefresh/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/UserRefresh/5
        //public void Delete(int id)
        //{
        //}
    }
}
