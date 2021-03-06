using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Data.Classes
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool IsMembershipWithdrawn { get; set; }
        public DateTime JoinedUtcDate { get; set; }
        public virtual ICollection<UserRolesByUser> UserRolesByUsers { get; set; }
    }
}
