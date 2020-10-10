using AutoMapper.Configuration;

namespace Necruit.Application.Mapping
{
    public interface IHaveCustomMappings
    {
        public void CreateMapping(IConfiguration configuration);
    }
}