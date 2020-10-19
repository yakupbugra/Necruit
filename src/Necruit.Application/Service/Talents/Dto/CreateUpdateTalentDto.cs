using Necruit.Application.Mapping;
using Necruit.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Necruit.Application.Service.Talents.Dto
{
    public class CreateUpdateTalentDto:MapTo<Talent>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string MobilePhone { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        [MaxLength(50)]
        public string Skype { get; set; }

        [MaxLength(100)]
        public string Linkedin { get; set; }

        public int? ExpectedSalary { get; set; }

        [MaxLength(100)]
        public string Cv { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public bool IsInPool { get; set; }
        public int UserId { get; set; }
    }
}