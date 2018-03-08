using System.Web.Mvc;

namespace Sitecore.Feature.MultivariateTest.Controllers
{
    using Test = Models.MultivariateTest;

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