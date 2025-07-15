using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using SimplyFly.API.DTOs.Models.Auth;
using SimplyFly.MVC.DTO.Auth;
using SimplyFly.MVC.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SimplyFly.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        private string GetToken()
        {
            return User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value;
        }

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View();




        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(RequestLogin login)
        {
            if (!ModelState.IsValid) return View(login);

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:45081/api/auth/login", login);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid credentials";
                return View(login);
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthResponse>(content);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, result.Email),
                new Claim(ClaimTypes.Role, result.Role),
                new Claim("AccessToken", result.Token)
            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principal);
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest register)
        {
            if (!ModelState.IsValid) return View(register);

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:45081/api/auth/register", register);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Registration failed.";
                return View(register);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login");
        }



        // to manage users from here...

        [HttpGet]
        public async Task<IActionResult> UserDetails(int id)
        {
            var user = await GetAsync<UserUpdateViewModel>($"http://localhost:45081/api/user/{id}");
            return user is null ? NotFound() : View("UserDetails", user);
        }

        // to update user details..

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await GetAsync<UserUpdateViewModel>($"http://localhost:45081/api/user/{id}");
            return user == null ? NotFound() : View(user);
        }

        [HttpPost("Admin/Edit/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.UserId = id;

            var success = await PutAsync($"api/user/{id}", model);
            TempData[success ? "Success" : "Error"] =
                success ? "User updated successfully." : "Failed to update user.";

            return RedirectToAction(nameof(UserDetails));
        }


        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Users()
        {
            var token = GetToken();

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:45081/api/user");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Could not load users.";
                return View(new List<UserUpdateViewModel>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserUpdateViewModel>>(content);

            return View(users);
        }

        //to delete users

        //to delete a user

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Attach JWT from cookie/claims
            var token = User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            // Correct singular route
            var response = await client.DeleteAsync(
                $"http://localhost:45081/api/user/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "User deleted successfully.";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["Error"] = "User not found.";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                     response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                TempData["Error"] = "Not authorized to delete user.";
            }
            else
            {
                TempData["Error"] = "Cannot delete owner: remove or reassign their flights first.";
             
            }

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            return await DeleteUser(id) switch
            {
                RedirectToActionResult r => RedirectToAction(nameof(Owners), r.RouteValues),
                _ => RedirectToAction(nameof(Owners))
            };
        }



        //for managing owners...
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Owners()
        {
            var token = GetToken();
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:45081/api/user");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Could not load owners.";
                return View(new List<UserUpdateViewModel>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var allUsers = JsonConvert.DeserializeObject<List<UserUpdateViewModel>>(content);
            var owners = allUsers.Where(u => u.Role == "Owner").ToList();

            return View(owners);
        }




        //to manage flights..

        [HttpGet]
        public async Task<IActionResult> FlightDetails(int id)
        {
            var flight = await GetAsync<FlightViewModel>($"api/flight/{id}");
            return flight is null ? NotFound() : View("FlightDetails", flight);
        }

        //to update flight details..

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditFlight(int id)
        {
            var flight = await GetAsync<FlightViewModel>($"http://localhost:45081/api/flight/{id}");
            return flight == null ? NotFound() : View(flight);
        }

        [HttpPost("Admin/EditFlight/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditFlight(int id, FlightViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.FlightId = id;

            var client = _httpClientFactory.CreateClient();

            // Attach JWT from cookie/claims
            var token = User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            client.BaseAddress = new Uri("http://localhost:45081/");

            // Send PUT request to API
            var response = await client.PutAsJsonAsync($"api/flight/{id}", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Flight updated successfully.";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                TempData["Error"] = "Flight ID mismatch.";
                return View(model); // show validation errors
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["Error"] = "Flight not found.";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                     response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                TempData["Error"] = "Not authorized to update flight.";
            }
            else
            {
                TempData["Error"] = $"Failed to update flight. Status: {(int)response.StatusCode}";
            }

            return RedirectToAction("FlightDetails", new { id = id });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Flights()
        {
            var token = GetToken();
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:45081/api/flight");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Could not load flights.";
                return View(new List<FlightViewModel>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var flights = JsonConvert.DeserializeObject<List<FlightViewModel>>(content);
            return View(flights);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveFlight(int id)
        {
            var token = GetToken();
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PatchAsync($"http://localhost:45081/api/flight/approve/{id}", null);
            return RedirectToAction("Flights");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var token = User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Same naming rule: FlightController → /api/flight/{id}
            //                   FlightsController → /api/flights/{id}
            var response = await client.DeleteAsync(
                $"http://localhost:45081/api/flight/{id}");

            if (response.IsSuccessStatusCode)
                TempData["Success"] = "Flight deleted successfully.";
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                TempData["Error"] = "Flight not found.";
            else if (response.StatusCode is System.Net.HttpStatusCode.Unauthorized or System.Net.HttpStatusCode.Forbidden)
                TempData["Error"] = "Not authorized to delete flight.";
            else
                TempData["Error"] = $"Failed to delete flight. Status: {(int)response.StatusCode}";

            return RedirectToAction(nameof(Flights));
        }

        // Re‑use one HttpClient with bearer token already set
        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            client.BaseAddress = new Uri("http://localhost:45081/");   // adjust if needed
            return client;
        }

        private async Task<T?> GetAsync<T>(string url)
        {
            var resp = await CreateClient().GetAsync(url);
            if (!resp.IsSuccessStatusCode) return default;
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private async Task<bool> PutAsync<T>(string url, T body)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

            client.BaseAddress = new Uri("http://localhost:45081/");
            var response = await client.PutAsJsonAsync(url, body);
            return response.IsSuccessStatusCode;
        }

        private async Task<bool> PostAsync(string url, object? body)
        {
            var resp = await CreateClient().PostAsJsonAsync(url, body);
            return resp.IsSuccessStatusCode;
        }


    }
}