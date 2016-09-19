using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace CommonUtilities
{
    public static class NSActiveDirectory
    {
        /// <summary>
        /// Gets the get principal context.
        /// </summary>
        private static PrincipalContext GetPrincipalContext
        {
            get
            {
                const string adDomainName = CommonConstants.ActiveDirectoryDomainName;
                //var credentials = SecureStoreProxy.GetCredentialsFromSecureStoreService(NSConstants.SecureStoreAccountForAD, CredentialType.Domain);
                //string adUserAccount = credentials.UserName;
                //string adUserAccountPassword = credentials.Password;
                var principalContext = new PrincipalContext(ContextType.Domain, adDomainName);
                return principalContext;
            }
        }

        /// <summary>
        /// The get all groups.
        /// </summary>
        public static List<Principal> GetAllGroups()
        {
            var groupNames = new List<Principal>();
            PrincipalContext principalContext = GetPrincipalContext;
            var findAllGroups = new GroupPrincipal(principalContext, "*");
            var ps = new PrincipalSearcher(findAllGroups);
            foreach (Principal group in ps.FindAll())
            {
                groupNames.Add(group);
            }

            return groupNames;
        }

        /// <summary>
        /// The get all groups from ou.
        /// </summary>
        public static List<Principal> GetAllGroupsFromOU(string OUName)
        {
            var groupNames = new List<Principal>();
            PrincipalContext principalContext = GetPrincipalContext;
            var findAllGroups = new GroupPrincipal(principalContext);
            var ps = new PrincipalSearcher(findAllGroups);
            string orgUnit = "OU=" + OUName;
            foreach (Principal group in ps.FindAll())
            {
                if (group.DistinguishedName.ToLowerInvariant().Contains(orgUnit.ToLowerInvariant()))
                {
                    groupNames.Add(group);
                }
            }

            return groupNames;
        }

        /// <summary>
        /// The get user.
        /// </summary>
        public static UserPrincipal GetUser(string samAccountName)
        {
            PrincipalContext principalContext = GetPrincipalContext;
            return UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, samAccountName);
        }

        /// <summary>
        /// The get user.
        /// </summary>
        public static UserPrincipal GetUser(string identity, IdentityType identityType)
        {
            PrincipalContext principalContext = GetPrincipalContext;
            return UserPrincipal.FindByIdentity(principalContext, identityType, identity);
        }

        /// <summary>
        /// The get group.
        /// </summary>
        public static GroupPrincipal GetGroup(string groupName)
        {
            PrincipalContext principalContext = GetPrincipalContext;
            return GroupPrincipal.FindByIdentity(principalContext, IdentityType.Name, groupName);
        }

        /// <summary>
        /// The get group.
        /// </summary>
        public static GroupPrincipal GetGroup(PrincipalContext pContext)
        {
            var groupByGroupPrincipal = new GroupPrincipal(pContext, "*");
            return groupByGroupPrincipal;
        }

        /// <summary>
        /// The is user member of group.
        /// </summary>
        public static bool IsUserMemberOfGroup(GroupPrincipal groupPrincipal, string samAccountName)
        {
            UserPrincipal userPrincipal = GetUser(samAccountName);
            if (userPrincipal == null)
            {
                return false;
            }

            return userPrincipal.IsMemberOf(groupPrincipal);
        }

        /// <summary>
        /// The is user member of group.
        /// </summary>
        public static bool IsUserMemberOfGroup(GroupPrincipal groupPrincipal, string identity, IdentityType identityType)
        {
            UserPrincipal userPrincipal = GetUser(identity, identityType);
            if (userPrincipal == null)
            {
                return false;
            }

            return userPrincipal.IsMemberOf(groupPrincipal);
        }

        /// <summary>
        /// The is user member of group.
        /// </summary>
        public static bool IsUserMemberOfGroup(GroupPrincipal groupPrincipal, UserPrincipal userPrincipal)
        {
            return userPrincipal.IsMemberOf(groupPrincipal);
        }

        /// <summary>
        /// The get all users in group.
        /// </summary>
        public static IEnumerable<UserPrincipal> GetAllUsersInGroup(GroupPrincipal groupPrincipal, bool recurse)
        {
            var userPrincipals = new List<UserPrincipal>();
            PrincipalSearchResult<Principal> members = groupPrincipal.GetMembers(recurse);
            foreach (Principal principal in members)
            {
                var userPrincipal = principal as UserPrincipal;
                if (userPrincipal == null)
                {
                    continue;
                }

                userPrincipals.Add(userPrincipal);
            }

            return userPrincipals;
        }

        public static String GetProperty(this Principal principal, String property)
        {
            DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
            if (directoryEntry != null && directoryEntry.Properties.Contains(property))
                return directoryEntry.Properties[property].Value.ToString();
            else
                return String.Empty;
        }

        public static String GetLocation(this Principal principal)
        {
            //"l" is the property name for Location
            return principal.GetProperty("l");
        }

        public static String GetDepartment(this Principal princical)
        {
            return princical.GetProperty("department");
        }

    }


}
