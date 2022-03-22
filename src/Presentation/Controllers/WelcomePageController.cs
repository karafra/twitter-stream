using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Twitter;
using Presentation.Pages;

namespace Presentation.Controllers;

/// <summary>
/// Test controller
/// </summary>
[ApiController]
[Route("mvc")]
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
    return View();
  }

}