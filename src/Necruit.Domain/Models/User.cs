using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class User : Entity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string Location { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Interview> Interviews { get; set; }
        public List<Talent> Talents { get; set; }
    }
}
