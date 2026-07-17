using Microsoft.AspNetCore.Mvc;
using LMS.Data;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth");

            var user = _db.Users.Find(userId);
            var quizzes = _db.Quizzes.Where(q => !q.IsExam).ToList();

            var completedListJson = HttpContext.Session.GetString("CompletedQuizzes");
            var completedListCount = 0;
            if (!string.IsNullOrEmpty(completedListJson))
            {
                var completedList = System.Text.Json.JsonSerializer.Deserialize<List<int>>(completedListJson);
                completedListCount = completedList?.Count ?? 0;
            }

            var totalScore = HttpContext.Session.GetInt32("TotalScore") ?? 0;
            var completedCount = HttpContext.Session.GetInt32("CompletedCount") ?? 0;
            var averageScore = completedCount > 0 ? (totalScore / completedCount) : 0;

            ViewBag.Username = user?.Username;
            ViewBag.Quizzes = quizzes;
            ViewBag.TotalQuizzes = quizzes.Count;
            ViewBag.CompletedQuizzes = completedListCount;
            ViewBag.AverageScore = averageScore;
            ViewBag.Streak = completedListCount > 0 ? 1 : 0;

            return View();
        }
    }
}
