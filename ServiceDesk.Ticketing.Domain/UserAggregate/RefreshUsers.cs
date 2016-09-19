using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace ServiceDesk.Ticketing.Domain.UserAggregate
{
    public class RefreshUsers: IRefreshUsers
    {
        public void RefreshUsersFromAD(IUserRepository userRepository)
        {
            List<User> localUsers = userRepository.GetAllUsers();
            List<UserRefreshModel> adUsers = GetAllUsersFromAD();
            foreach (var adUser in adUsers)
            {
                var userToUpdate = localUsers.Find(u => u.State.SID == adUser.SID);
                if (userToUpdate != null)
                {
                    userToUpdate.State.DisplayName = adUser.DisplayName;
                    userToUpdate.State.Department = adUser.Department;
                    userToUpdate.State.Email = adUser.Email;
                    userToUpdate.State.Location = adUser.Location;
                    userToUpdate.State.LoginName = adUser.LoginName;
                    userRepository.Update(userToUpdate);
                }
                else
                {
                    var user = new User(adUser.SID, adUser.LoginName, adUser.DisplayName, adUser.Department, adUser.Location, adUser.Email);
                    userRepository.Add(user);
                }
            }
        }

        public List<UserRefreshModel> GetAllUsersFromAD()
        {
            var model = new List<UserRefreshModel>();
            using (var context = new PrincipalContext(ContextType.Domain, "safety.northernsafety.com"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        var singleUser = new UserRefreshModel();

                        var de = result.GetUnderlyingObject() as DirectoryEntry;
                        if (de != null && de.Properties["givenName"].Value != null && de.Properties["physicalDeliveryOfficeName"].Value != null && de.Properties["department"].Value != null)
                        {
                            var firstName = de.Properties["givenName"].Value.ToString();
                            var lastName = de.Properties["sn"].Value != null ? de.Properties["sn"].Value.ToString() : "";
                            singleUser.DisplayName = firstName + " " + lastName;
                            singleUser.Email = de.Properties["mail"].Value != null ? de.Properties["mail"].Value.ToString() : "";
                            singleUser.LoginName = de.Properties["sAMAccountName"].Value != null ? de.Properties["sAMAccountName"].Value.ToString() : "";
                            singleUser.Location = de.Properties["physicalDeliveryOfficeName"].Value.ToString();
                            singleUser.Department = de.Properties["department"].Value.ToString();
                            var sidBytes = (byte[])de.Properties["objectSid"].Value;
                            var sid = new SecurityIdentifier(sidBytes, 0);
                            singleUser.SID = sid.ToString();

                            model.Add(singleUser);
                        }
                    }
                }
            }

            return model;
        }
    }
}
