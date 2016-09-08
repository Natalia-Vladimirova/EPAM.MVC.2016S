using System.Linq;
using System.Web.Mvc;
using Task2.Infrastructure;
using Task2.Models;

namespace Task2.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
            // 2 version of app - using custom invoker
            // ActionInvoker = new CustomActionInvoker();
        }

        // 1 version of app - using local attribute
        [Local]
        public ActionResult Index()
        {
            return View(UserRepository.Users);
        }

        // 1 version of app - using local attribute
        [Local]
        public ActionResult Delete(int id)
        {
            UserRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

        // 1 version of app - using local attribute
        [Local]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = UserRepository.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // 1 version of app - using local attribute
        [Local]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(User user)
        {
            UserRepository.EditUser(user);
            return RedirectToAction("Index");
        }
    }
}