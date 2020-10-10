using AutoMapper;

namespace Necruit.Application.Mapping
{
    public abstract class MapTo<T>
    {
        public void CreateMapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}