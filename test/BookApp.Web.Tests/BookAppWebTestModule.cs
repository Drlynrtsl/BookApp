using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookApp.EntityFrameworkCore;
using BookApp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BookApp.Web.Tests
{
    [DependsOn(
        typeof(BookAppWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BookAppWebTestModule : AbpModule
    {
        public BookAppWebTestModule(BookAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookAppWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BookAppWebMvcModule).Assembly);
        }
    }
}