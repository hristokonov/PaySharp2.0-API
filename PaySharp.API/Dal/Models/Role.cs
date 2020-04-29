using System.Collections.Generic;

namespace PaySharp.API.Dal.Models
{
    public class Role
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
