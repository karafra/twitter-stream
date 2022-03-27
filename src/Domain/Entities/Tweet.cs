using tweet = TwitterSharp.Response.RTweet;
using TwitterSharp.Response.RMedia;
using System.Text.Json;

namespace Domain.Entities;

/// <summary>
/// Tweet object for client.
/// </summary>
public class SocketTweet
{
    /// <summary>
    /// Author username.
    /// </summary>
    public string Author { get; }

    /// <summary>
    /// Message in tweet.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Array of medias in the tweet.
    /// </summary>
    public Media[]? Medias { get; }

    /// <summary>
    /// True if tweet contains media.
    /// </summary>
    public bool HasMedia => 
        Medias is not null 
        ? 
        Medias.Length > 0 
        : 
        false;

    public SocketTweet(string author, string message, Media[]? medias)
    {
        Message = message;
        Author = author;
        Medias = medias;
    }

    /// <summary>
    /// Creates object for sending tweets to socket.
    /// </summary>
    /// <param name="tweet">tweet to be sent to socket</param> 
    public SocketTweet(tweet.Tweet tweet)
    {
        Message = tweet.Text;
        Author = tweet.Author.Username;
        Medias = tweet.Attachments.Media;

    }

    /// <summary>
    /// Returns JSON representation of object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
