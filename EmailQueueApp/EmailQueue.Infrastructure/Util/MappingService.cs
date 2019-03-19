using System.Collections.Generic;
using AutoMapper;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Infrastructure.Util
{
    public class MappingService : IMappingService
    {
        private readonly IMapper mapper;

        public MappingService()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper();
        }

        public TDestination ConvertTo<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> ConvertCollectionTo<TDestination>(object source)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }

        public void Dispose()
        {
        }
    }
}
