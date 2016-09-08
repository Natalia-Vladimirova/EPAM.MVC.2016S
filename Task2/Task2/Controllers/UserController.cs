using System.Threading.Tasks;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    // 1 version of app - using attributes
    [RoutePrefix("{Type:regex(User|Customer)}")]
    [Route("{action=Index}")]
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View("UserList", UserRepository.Users);
        }

        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> AddUserPost(User user)
        {
            await Task.Factory.StartNew(() => 
            {
                UserRepository.AddUser(user);
            });
            return RedirectToAction("User-List");
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult UserList()
        {
            return View("UserList", UserRepository.Users);
        }

        [HttpPost]
        [ActionName("User-List")]
        public ActionResult UserListPost()
        {
            return Json(UserRepository.Users, JsonRequestBehavior.AllowGet);
        }
    }
}