using System.Web.Mvc;
using Test = Sitecore.Feature.MultivariateTest.Models.MultivariateTest;

namespace Sitecore.Feature.MultivariateTest.Controllers
{
    public class MultivariateTestController : Controller
    {
        public ActionResult Index()
        {
            var test = new Test
            {
                Title = "Hallo Wilfred"
            };

            return View(test);
        }
    }
}