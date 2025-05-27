using FluentAssertions;
using Movies.Contracts.Requests;

namespace Movies.Tests.Unit;

public class CreateMovieRequestTests {
    [Fact]
    public void CreateMovieRequest_ShouldInstantiate_WhenValidProperties() {
        // Arrange
        var movieRequest = new CreateMovieRequest {
            Title = "Movie that doesn't exist",
            YearOfRelease = 2001,
            Genres = Enumerable.Empty<string>(),
        };

        // Assert
        movieRequest.Title.Should().Be("Movie that doesn't exist");
        movieRequest.YearOfRelease.Should().Be(2001);
        movieRequest.Genres.Should().BeEmpty();
    }
}
