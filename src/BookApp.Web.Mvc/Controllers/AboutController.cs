using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BookApp.Controllers;

namespace BookApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BookAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
