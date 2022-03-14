using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeetupWeb.Home.Models;
using MeetupWeb.CommonModels;
using System.IO;

namespace MeetupWeb.Home;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string path = Path.Combine(System.Environment.CurrentDirectory, @"Data\Liste.txt");

        if (System.IO.File.Exists(path))
        {
            HomeDto fruits = new HomeDto()
            {
                Lines = System.IO.File.ReadAllLines(path).ToList(),
                Titre = "Liste de fruits"
            };

            return View(fruits);
        }
        else
        {
            HomeDto fruits = new HomeDto()
            {
                Titre = $"Liste vide: " + path
            };

            return View(fruits);
        }
    }


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
