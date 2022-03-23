namespace Presentation.Pages;

internal class WelcomePageModel
{
  public string Title { get; set; }

  public WelcomePageModel(string title)
  {
    Title = title;
  }

  public WelcomePageModel() : this("Title")
  { }
}
