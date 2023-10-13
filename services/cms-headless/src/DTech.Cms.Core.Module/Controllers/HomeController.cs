using Microsoft.AspNetCore.Mvc;

namespace DTech.Cms.Core.Module.Controllers
{
    [Area("DTech")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
