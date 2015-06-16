using DolPic.Service.Web.Common;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class MainController : CustomController
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            return RedirectToRoute(new
            {
                controller = "Pics",
                action = "Main"
            });
        }

    }
}
