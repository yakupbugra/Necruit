using AutoMapper.Configuration.Conventions;
using Necruit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Necurit.Application.Data.Request
{
    public class JobListResponse
    {

        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int MyProperty { get; set; }
        public int RecruitmentCount { get; set; }
    }
}
