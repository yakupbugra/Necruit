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
            CreateMap<Job, JobListResponse>();
               // .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.User.Id))
               // .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.User.Name))
                //.ForMember(dst => dst.UserSurname, opt => opt.MapFrom(src => src.User.Surname));
        }
    }
}
