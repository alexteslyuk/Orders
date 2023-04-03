using AutoMapper;

namespace Orders.Logic.Mapper
{
    public class MapperInit
    {
        public static void Init(IMapperConfigurationExpression configuration)
        {
            var profiles = typeof(MapperInit).Assembly.GetTypes().Where(t => t.BaseType == typeof(Profile));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(profile);
            }
        }
    }
}
