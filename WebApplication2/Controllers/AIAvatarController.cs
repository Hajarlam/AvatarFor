using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class AIAvatarController : Controller
    {
        public IActionResult Chat()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth");

            return View();
        }
    }
}
