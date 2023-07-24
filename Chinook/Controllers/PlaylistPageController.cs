using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers;

public class PlaylistPageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
