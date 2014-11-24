using System;
using System.Collections.Generic;

namespace MVCTrainningSample.Models
{
    public partial class User
    {
        public User()
        {
            this.Roles = new List<Role>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
