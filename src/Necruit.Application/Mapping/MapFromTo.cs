using AutoMapper;

namespace Necruit.Application.Mapping
{
    public abstract class MapFromTo<T,K>
    {
        public void CreateMapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
            profile.CreateMap(GetType(), typeof(K));
        }
    }
}