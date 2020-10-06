using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class Talent : Entity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Location { get; set; }
        public string Skype { get; set; }
        public String Linkedin { get; set; }
        public int ExpectedSalary { get; set; }
        public string Cv { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
   
        public bool IsInPool { get; set; }

    }
}
