using Microsoft.AspNetCore.Mvc;
using TwitterSharp.Client;
using Presentation.Pages;

namespace Presentation.Controllers;

/// <summary>
/// Main controller
/// </summary>
[ApiController]
[Route("")]
public sealed class WelcomePageController : Controller
{
  /// <summary>
  /// Endpoint for showing main page
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public IActionResult _WelcomePage()
  {
    WelcomePageModel model = new WelcomePageModel();
    model.Title = "Title";
    return View(model);
  }

}
