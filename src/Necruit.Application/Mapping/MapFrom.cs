using AutoMapper;

namespace Necruit.Application.Mapping
{
    public abstract class MapFrom<T>
    {
        public void CreateMapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}