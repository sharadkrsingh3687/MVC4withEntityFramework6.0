using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Principal;
namespace MVCTrainningSample.DAL.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] roles { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] roles { get; set; }
    }
}