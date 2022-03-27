using Xunit;
using Domain.Entities;
using TwitterSharp.Response.RTweet;
using TwitterSharp.Response.RUser;
using TwitterSharp.Response.RMedia;
using Moq;

public sealed class TweetTests
{

    [Fact]
    public void ShouldSerialize()
    {
        // Given
        var author = "author";
        var message = "message";
        var tweet = new SocketTweet(author, message, null);
        // When
        var result = tweet.ToString();
        // Then
        Assert.Equal("{\"Author\":\"author\",\"Message\":\"message\",\"Medias\":null,\"HasMedia\":false}", result);
    }

    [Fact]
    public void ShouldReturnFalseOnEmptyMedias()
    {
        // Given
        var author = "author";
        var message = "message";
        // When
        var tweet = new SocketTweet(author, message, null);
        // Then
        Assert.Equal(author, tweet.Author);
        Assert.Equal(message, tweet.Message);
        Assert.Null(tweet.Medias);
        Assert.False(tweet.HasMedia);
    }
}
