using System;
using System.Collections.Generic;

namespace MVCTrainningSample.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
