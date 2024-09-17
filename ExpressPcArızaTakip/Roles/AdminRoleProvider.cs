using ExpressPcArızaTakip.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Security;

namespace ExpressPcArızaTakip.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var context = new expresspcEntities())
            {
                var roles = context.User
                                   .Where(u => u.UserName == username)
                                   .Select(u => u.Role.Roles)
                                   .FirstOrDefault();

                return roles != null ? roles.Split(',') : new string[] { };
            }
        }
    

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var context = new expresspcEntities())
            {
                var roles = context.User
                                   .Where(u => u.UserName == username)
                                   .Select(u => u.Role.Roles)
                                   .FirstOrDefault();

                return roles != null && roles.Split(',').Contains(roleName);
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}