using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using System.Diagnostics;
using WebAppProCodeGuide.Samples.FeatureFlagsDemo.Models;

namespace WebAppProCodeGuide.Samples.FeatureFlagsDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManagerSnapshot _featureManager;

        public HomeController(ILogger<HomeController> logger, IFeatureManagerSnapshot featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public async Task<IActionResult> Index()
        {
            if (await _featureManager.IsEnabledAsync(nameof(FeatureFlags.MobileReview)))
            {
                ViewData["WelcomeMessage"] = "Welcome - Mobile Review Application";
            }
            else
            {
                ViewData["WelcomeMessage"] = "Welcome";
            }
            return View();
        }

        // Remaining Code has been removed for readability.
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}