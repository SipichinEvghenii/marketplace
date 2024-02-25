using System.Diagnostics;
using Marketplace.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Логика для страницы Index
        return View();
    }

    public IActionResult Cart()
    {
        // Логика для страницы Cart
        return View();
    }

    public IActionResult Checkout()
    {
        // Логика для страницы Checkout
        return View();
    }

    public IActionResult Contact()
    {
        // Логика для страницы Contact
        return View();
    }

    public IActionResult PageNotFound()
    {
        // Логика для страницы NotFound
        return View();
    }

    public IActionResult Privacy()
    {
        // Логика для страницы Privacy
        return View();
    }

    public IActionResult Shop()
    {
        // Логика для страницы Shop
        return View();
    }

    public IActionResult ShopDetail()
    {
        // Логика для страницы ShopDetail
        return View();
    }

    public IActionResult Testimonial()
    {
        // Логика для страницы Testimonial
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}