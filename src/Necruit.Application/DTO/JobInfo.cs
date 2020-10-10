using AutoMapper.Configuration.Conventions;
using Necruit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Necruit.Application.Mapping;

namespace Necruit.Application.Request
{
    public class JobInfo: MapFrom<Job>
    {

        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public UserInfo User { get; set; }
        public int RecruitmentCount { get; set; }
    }
}
