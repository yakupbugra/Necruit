using Necruit.Application.Mapping;
using Necruit.Domain.Entities;

namespace Necruit.Application.Service.Jobs.Dto
{
    public class JobUserDto : MapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}