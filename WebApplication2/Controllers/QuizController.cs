using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using System.Text.Json;

namespace LMS.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Quiz/Start/{id}
        [HttpGet]
        public async Task<IActionResult> Start(int id)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            // Calculer les limites de temps et scores requis
            var (timeLimit, passScore) = quiz.Level switch
            {
                "Facile" => (10, 60),
                "Moyen" => (20, 70),
                "Difficile" => (30, 80),
                _ => (10, 60)
            };

            ViewBag.TimeLimit = timeLimit;
            ViewBag.PassScore = passScore;

            return View(quiz);
        }

        // GET: /Quiz/Play/{id}
        [HttpGet]
        public async Task<IActionResult> Play(int id)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            var (timeLimit, passScore) = quiz.Level switch
            {
                "Facile" => (10, 60),
                "Moyen" => (20, 70),
                "Difficile" => (30, 80),
                _ => (10, 60)
            };

            ViewBag.TimeLimitMinutes = timeLimit;

            return View(quiz);
        }

        // POST: /Quiz/Submit/{id}
        [HttpPost]
        public async Task<IActionResult> Submit(int id, Dictionary<string, string> answers)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            int correctCount = 0;
            var resultDetails = new List<QuestionResultViewModel>();

            foreach (var question in quiz.Questions)
            {
                int selectedOptionId = 0;
                bool isCorrect = false;

                // Chercher l'option sélectionnée par l'utilisateur
                if (answers != null && answers.TryGetValue(question.Id.ToString(), out var selectedStr) && int.TryParse(selectedStr, out var selectedId))
                {
                    selectedOptionId = selectedId;
                    var selectedOption = question.Options.FirstOrDefault(o => o.Id == selectedId);
                    if (selectedOption != null && selectedOption.IsCorrect)
                    {
                        isCorrect = true;
                        correctCount++;
                    }
                }

                resultDetails.Add(new QuestionResultViewModel
                {
                    QuestionText = question.Text,
                    Options = question.Options.Select(o => new OptionViewModel
                    {
                        Id = o.Id,
                        Text = o.Text,
                        IsCorrect = o.IsCorrect
                    }).ToList(),
                    SelectedOptionId = selectedOptionId,
                    IsCorrect = isCorrect
                });
            }

            double percentage = ((double)correctCount / quiz.Questions.Count) * 100;
            double requiredPercentage = quiz.Level switch
            {
                "Facile" => 60,
                "Moyen" => 70,
                "Difficile" => 80,
                _ => 60
            };

            bool passed = percentage >= requiredPercentage;
            double gradeValue = 0;
            string mentionValue = "";

            if (quiz.IsExam)
            {
                gradeValue = ((double)correctCount / quiz.Questions.Count) * 20;
                gradeValue = Math.Round(gradeValue, 1);
                mentionValue = gradeValue switch
                {
                    >= 16 => "Très Bien",
                    >= 14 => "Bien",
                    >= 12 => "Assez Bien",
                    >= 10 => "Passable",
                    _ => "Insuffisant"
                };
                bool passedExam = gradeValue >= 10;

                // Save in session
                var examResultsJson = HttpContext.Session.GetString("ExamResults");
                var examResults = string.IsNullOrEmpty(examResultsJson)
                    ? new Dictionary<string, ExamResultSessionModel>()
                    : JsonSerializer.Deserialize<Dictionary<string, ExamResultSessionModel>>(examResultsJson);

                if (examResults != null)
                {
                    examResults[id.ToString()] = new ExamResultSessionModel
                    {
                        QuizId = id,
                        QuizTitle = quiz.Title,
                        Category = quiz.Category,
                        Grade = gradeValue,
                        Mention = mentionValue,
                        Passed = passedExam,
                        Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    };
                    HttpContext.Session.SetString("ExamResults", JsonSerializer.Serialize(examResults));
                }
            }
            else
            {
                // Enregistrer la complétion dans la session pour le Dashboard (uniquement pour les quiz)
                var completedListJson = HttpContext.Session.GetString("CompletedQuizzes");
                var completedList = string.IsNullOrEmpty(completedListJson)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(completedListJson);

                if (completedList != null && !completedList.Contains(id))
                {
                    completedList.Add(id);
                    HttpContext.Session.SetString("CompletedQuizzes", JsonSerializer.Serialize(completedList));
                    
                    var totalScore = HttpContext.Session.GetInt32("TotalScore") ?? 0;
                    var completedCount = HttpContext.Session.GetInt32("CompletedCount") ?? 0;

                    HttpContext.Session.SetInt32("TotalScore", totalScore + (int)Math.Round(percentage));
                    HttpContext.Session.SetInt32("CompletedCount", completedCount + 1);
                }
            }

            var result = new QuizResultViewModel
            {
                QuizTitle = quiz.Title,
                QuizCategory = quiz.Category,
                Score = correctCount,
                TotalQuestions = quiz.Questions.Count,
                Percentage = Math.Round(percentage, 1),
                RequiredPercentage = requiredPercentage,
                Passed = passed,
                IsExam = quiz.IsExam,
                Grade = gradeValue,
                Mention = mentionValue,
                Questions = resultDetails
            };

            TempData["QuizResult"] = JsonSerializer.Serialize(result);

            return RedirectToAction("Result", new { id = id });
        }

        // GET: /Quiz/Result/{id}
        [HttpGet]
        public IActionResult Result(int id)
        {
            if (TempData["QuizResult"] == null)
            {
                return RedirectToAction("Start", new { id = id });
            }

            var json = TempData["QuizResult"] as string;
            var model = JsonSerializer.Deserialize<QuizResultViewModel>(json);

            return View(model);
        }

        // GET: /Quiz/Exams
        [HttpGet]
        public async Task<IActionResult> Exams()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var exams = await _context.Quizzes
                .Where(q => q.IsExam)
                .ToListAsync();

            var examResultsJson = HttpContext.Session.GetString("ExamResults");
            var examResults = string.IsNullOrEmpty(examResultsJson)
                ? new Dictionary<string, ExamResultSessionModel>()
                : JsonSerializer.Deserialize<Dictionary<string, ExamResultSessionModel>>(examResultsJson);

            ViewBag.ExamResults = examResults;

            return View(exams);
        }

        // GET: /Quiz/Bulletin/{id}
        [HttpGet]
        public async Task<IActionResult> Bulletin(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var username = HttpContext.Session.GetString("Username");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var examResultsJson = HttpContext.Session.GetString("ExamResults");
            if (string.IsNullOrEmpty(examResultsJson))
            {
                return RedirectToAction("Exams");
            }

            var examResults = JsonSerializer.Deserialize<Dictionary<string, ExamResultSessionModel>>(examResultsJson);
            if (examResults == null || !examResults.TryGetValue(id.ToString(), out var result))
            {
                return RedirectToAction("Exams");
            }

            ViewBag.Username = username ?? "Apprenant";
            return View(result);
        }
    }

    // ViewModels pour la sérialisation des résultats
    public class QuizResultViewModel
    {
        public string QuizTitle { get; set; }
        public string QuizCategory { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public double Percentage { get; set; }
        public double RequiredPercentage { get; set; }
        public bool Passed { get; set; }
        public bool IsExam { get; set; }
        public double Grade { get; set; }
        public string Mention { get; set; }
        public List<QuestionResultViewModel> Questions { get; set; }
    }

    public class QuestionResultViewModel
    {
        public string QuestionText { get; set; }
        public List<OptionViewModel> Options { get; set; }
        public int SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class OptionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class ExamResultSessionModel
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public string Category { get; set; }
        public double Grade { get; set; }
        public string Mention { get; set; }
        public bool Passed { get; set; }
        public string Date { get; set; }
    }
}
