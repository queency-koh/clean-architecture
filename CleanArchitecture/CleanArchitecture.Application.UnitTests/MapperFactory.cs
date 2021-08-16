using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.UnitTests
{
    public static class MapperFactory
    {
        public static IMapper Create()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return configurationProvider.CreateMapper();
        }
    }
}
