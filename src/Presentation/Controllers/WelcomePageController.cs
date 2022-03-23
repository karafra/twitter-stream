using Microsoft.AspNetCore.Mvc;
using Infrastructure.Twitter;
using Presentation.Pages;

namespace Presentation.Controllers;

/// <summary>
/// Test controller
/// </summary>
[ApiController]
[Route("")]
public sealed class WelcomePageController : Controller
{
  private readonly TwitterClient _twitterClient;

  public WelcomePageController(TwitterClient twitterClient)
  {
    _twitterClient = twitterClient;
  }

  [HttpGet]
  public IActionResult _WelcomePage()
  {
    WelcomePageModel model = new WelcomePageModel();
    model.Title = "Title";
    return View(model);
  }

}