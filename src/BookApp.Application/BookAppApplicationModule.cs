using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookApp.Authorization;

namespace BookApp
{
    [DependsOn(
        typeof(BookAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BookAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BookAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BookAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
