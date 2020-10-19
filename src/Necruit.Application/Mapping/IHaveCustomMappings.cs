using AutoMapper;

namespace Necruit.Application.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMapping(Profile profile);
    }
}