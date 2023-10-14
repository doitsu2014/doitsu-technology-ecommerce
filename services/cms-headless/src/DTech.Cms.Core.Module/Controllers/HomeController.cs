using Microsoft.AspNetCore.Mvc;

namespace DTech.Cms.Core.Module.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
