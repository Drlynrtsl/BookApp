using System.Threading.Tasks;
using BookApp.Models.TokenAuth;
using BookApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace BookApp.Web.Tests.Controllers
{
    public class HomeController_Tests: BookAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}