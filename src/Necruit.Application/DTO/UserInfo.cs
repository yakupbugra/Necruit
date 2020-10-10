using Necruit.Domain.Entities;
using Necruit.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Application.Request
{
    public class UserInfo : MapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
