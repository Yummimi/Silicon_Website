using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using Silicon_Website_App.ViewModels;

namespace Silicon_Website_App.Controllers
{
    [Authorize]
    public class CoursesController(HttpClient httpClient) : Controller
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IActionResult> Index()
        {
            var viewModel = new CourseIndexViewModel();

            var response = await _httpClient.GetAsync("https://localhost:7084/api/courses");
            if(response.IsSuccessStatusCode)
            {
                var courses = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(await response.Content.ReadAsStringAsync());
                if(courses != null && courses.Any())
                {
                    viewModel.Courses = courses;
                }
            }


            return View(viewModel);
        }
    }
}
