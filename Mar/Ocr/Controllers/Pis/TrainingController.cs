using Microsoft.AspNetCore.Mvc;

namespace Ocr.Controllers.Pis;

public class TrainingController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TrainingsEntry()
    {
        return View();
    }


}
