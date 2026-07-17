using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);
        }

        public void Seed()
        {
            if (!Users.Any())
            {
                var users = new[]
                {
                    new User { Username = "admin", Email = "admin@lms.com", PasswordHash = "admin123", Role = "Admin" },
                    new User { Username = "student", Email = "student@lms.com", PasswordHash = "student123", Role = "Student" }
                };
                Users.AddRange(users);
                SaveChanges();
            }

            if (Quizzes.Count() != 48)
            {
                // Clear any old dummy quizzes to start fresh
                var oldQuizzes = Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).ToList();
                if (oldQuizzes.Any())
                {
                    Quizzes.RemoveRange(oldQuizzes);
                    SaveChanges();
                }

                // Seed using generator
                QuizDataGenerator.Seed(this);
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "Student";
    }

    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int QuestionCount { get; set; }
        public bool IsExam { get; set; } = false;
        public List<Question> Questions { get; set; } = new();
    }

    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Text { get; set; }
        public List<Option> Options { get; set; } = new();
        public Quiz Quiz { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
}
