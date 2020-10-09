using AutoMapper;
using Necruit.Domain.Entities;
using Necurit.Application.Data.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Necurit.Application.Data.Mapping
{
    public class JobMapper : Profile
    {
        public JobMapper()
        {
            CreateMap<CreateJobRequest, Job>();
        }
    }
}
