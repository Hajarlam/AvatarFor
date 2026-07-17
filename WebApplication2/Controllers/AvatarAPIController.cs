using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace LMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvatarAPIController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AvatarAPIController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost("ask-question")]
        public async Task<IActionResult> AskQuestion([FromBody] AskQuestionRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Question))
                    return BadRequest(new { success = false, message = "Question vide" });

                var response = await CallOpenAIAsync(request.Question, request.CourseContext);

                return Ok(new { success = true, response = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        private async Task<string> CallOpenAIAsync(string question, string courseContext)
        {
            var openAiKey = _configuration["ApiKeys:OpenAI"];
            if (string.IsNullOrEmpty(openAiKey) || openAiKey == "YOUR_OPENAI_API_KEY")
            {
                throw new Exception("Clé API OpenAI non configurée dans appsettings.json.");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAiKey}");

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new object[]
                {
                    new { role = "system", content = $"Vous êtes un formateur IA expert. Contexte: {courseContext}. Répondez en français de façon claire et pédagogique." },
                    new { role = "user", content = question }
                },
                max_tokens = 500,
                temperature = 0.7
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erreur OpenAI: {response.StatusCode} - {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonDocument.Parse(responseContent);

            var answer = jsonResponse.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return answer ?? "Je n'ai pas pu générer une réponse.";
        }

        [HttpGet("get-anam-token")]
        public async Task<IActionResult> GetAnamToken()
        {
            try
            {
                var apiKey = _configuration["ApiKeys:Anam"];
                if (string.IsNullOrEmpty(apiKey))
                    return BadRequest(new { success = false, message = "Clé API Anam manquante" });

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    personaConfig = new
                    {
                        personaId = "dd7594a4-76ef-5e1f-9c9a-7afddd64b438",
                        systemPrompt = "Vous êtes Olivia, une formatrice IA experte. Répondez toujours en français de manière claire, chaleureuse et pédagogique. Répondez aux questions de l'apprenant en français uniquement."
                    }
                };

                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://api.anam.ai/v1/auth/session-token", jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, new { success = false, error = errorContent });
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(responseContent);
                var sessionToken = jsonDoc.RootElement.GetProperty("sessionToken").GetString();

                return Ok(new { success = true, sessionToken = sessionToken });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }

    public class AskQuestionRequest
    {
        public string Question { get; set; }
        public string CourseContext { get; set; }
        public int AvatarId { get; set; }
    }
}
