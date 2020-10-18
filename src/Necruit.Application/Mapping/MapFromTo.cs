using AutoMapper;

namespace Necruit.Application.Mapping
{
    public abstract class MapFromTo<T>
    {
        public void CreateMapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
            profile.CreateMap(GetType(), typeof(T));
        }
    }
}