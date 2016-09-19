using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.DataAccess.UserRefresh;

namespace ServiceDeskSVC.DataAccess.Repositories.UserRefresh
{
    public class UserRefreshRepository : IUserRefreshRepository
    {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public UserRefreshRepository(ServiceDeskContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool RunRefreshForAllUsers(List<ServiceDesk_Users> users)
        {
            DataTable dtUsers = new DataTable();
            dtUsers.Columns.Add("SID", typeof (string));
            dtUsers.Columns.Add("UserName", typeof(string));
            dtUsers.Columns.Add("FirstName", typeof(string));
            dtUsers.Columns.Add("LastName", typeof(string));
            dtUsers.Columns.Add("EMail", typeof(string));
            dtUsers.Columns.Add("LocationId", typeof(int));
            dtUsers.Columns.Add("DepartmentId", typeof(int));
            foreach (var ut in users)
            {
                dtUsers.Rows.Add(ut.SID, ut.UserName, ut.FirstName, ut.LastName, ut.EMail, ut.LocationId, ut.DepartmentId);
            }


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceDeskContext"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.RefreshUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit)).Direction = ParameterDirection.Output;
                SqlParameter sqlparam = new SqlParameter("@UsersInput", dtUsers)
                {
                    TypeName = "dbo.UserUpdateTable"
                };
                cmd.Parameters.Add(sqlparam);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    _logger.Error("Refresh failed while updating USERS, error:" + ex.StackTrace);
                }

                var isSuccess = Convert.ToBoolean(cmd.Parameters["@Success"].Value);

                return isSuccess;
            }
        }

        public bool RunRefreshForAllDepartments(List<Department> departments)
        {

            DataTable dtDepartments = new DataTable();
            dtDepartments.Columns.Add("DepartmentName", typeof(string));
            foreach (var dt in departments)
            {
                dtDepartments.Rows.Add(dt.DepartmentName);
            }


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceDeskContext"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdateDepartments", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit)).Direction = ParameterDirection.Output;
                SqlParameter sqlparam = new SqlParameter("@DepartmentsInput", dtDepartments)
                {
                    TypeName = "dbo.DepartmentUpdateTable"
                };
                cmd.Parameters.Add(sqlparam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    _logger.Error("Refresh failed while updating DEPARTMENTS, error:" + ex.StackTrace);
                }

                var isSuccess = Convert.ToBoolean(cmd.Parameters["@Success"].Value);

                return isSuccess;
            }
        }

        public bool RunRefreshForAllLocations(List<NSLocation> locations)
        {
            DataTable dtLocations = new DataTable();
            dtLocations.Columns.Add("LocationCity", typeof(string));
            dtLocations.Columns.Add("LocationState", typeof(string));
            dtLocations.Columns.Add("LocationZip", typeof(int));
            foreach (var dt in locations)
            {
                dtLocations.Rows.Add(dt.LocationCity, dt.LocationState, dt.LocationZip);
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceDeskContext"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdateLocations", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit)).Direction = ParameterDirection.Output;
                SqlParameter sqlparam = new SqlParameter("@LocationsInput", dtLocations)
                {
                    TypeName = "dbo.LocationUpdateTable"
                };
                cmd.Parameters.Add(sqlparam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    _logger.Error("Refresh failed while updating LOCATIONS, error:" + ex.StackTrace);
                }
                var isSuccess = Convert.ToBoolean(cmd.Parameters["@Success"].Value);

                return isSuccess;
            }
        }
    }
}
