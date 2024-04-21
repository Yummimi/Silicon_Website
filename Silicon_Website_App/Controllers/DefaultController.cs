using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_Website_App.ViewModels;
using System.Text;

namespace Silicon_Website_App.Controllers
{
    public class DefaultController(HttpClient httpClient) : Controller
    {
        private readonly HttpClient _httpClient = httpClient;

        public IActionResult Home()
        {
            return View();
        }

        public async Task<IActionResult> Subscribe(SubscribeViewModel model)
        {
            if(ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7084/api/subscribe", content);
                if(response.IsSuccessStatusCode)
                {
                    TempData["StatusMessage"] = "You are now subscribed";
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["StatusMessage"] = "You are already subscribed";
                }
            }

            else
            {
                TempData["StatusMessage"] = "Invalid email address";
            }

            return RedirectToAction("Home", "Default", "subscribe-section");
        }
    }
}
