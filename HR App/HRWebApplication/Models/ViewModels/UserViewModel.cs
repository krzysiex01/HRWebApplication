using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }

        public List<Company> Companies { get; set; }
    }
}
