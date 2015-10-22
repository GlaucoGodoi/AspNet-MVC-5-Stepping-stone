using System.Web.Mvc;

namespace DryRun.Controllers
{
    [RoutePrefix("simple")]
    public class SimpleController : Controller
    {
        #region Public Methods

        // GET: Simple
        [Route("simple/index/{fruitName}")]
        public ActionResult Index(string fruitName)
        {
            ViewBag.Id = fruitName;
            return View();
        }

        #endregion Public Methods
    }

}