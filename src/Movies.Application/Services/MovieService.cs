using FluentValidation;
using Movies.Application.Models;
using Movies.Application.Repositories;

namespace Movies.Application.Services;

public class MovieService : IMovieService {
    private readonly IMovieRepository _movieRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IValidator<Movie> _movieValidator;
    private readonly IValidator<GetAllMoviesOptions> _getAllMoviesOptionsValidator;

    public MovieService(
        IMovieRepository movieRepository,
        IValidator<Movie> movieValidator,
        IRatingRepository ratingRepository,
        IValidator<GetAllMoviesOptions> getAllMoviesOptionsValidator
    ) {
        _movieRepository = movieRepository;
        _movieValidator = movieValidator;
        _ratingRepository = ratingRepository;
        _getAllMoviesOptionsValidator = getAllMoviesOptionsValidator;
    }

    public async Task<bool> CreateAsync(
        Movie movie,
        Guid? userId = default,
        CancellationToken token = default
    ) {
        await _movieValidator.ValidateAndThrowAsync(movie, cancellationToken: token);
        return await _movieRepository.CreateAsync(movie, userId, token);
    }

    public Task<bool> DeleteByIdAsync(
        Guid id,
        Guid? userId = default,
        CancellationToken token = default
    ) {
        return _movieRepository.DeleteByIdAsync(id, token);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(
        GetAllMoviesOptions options,
        CancellationToken token = default
    ) {
        await _getAllMoviesOptionsValidator.ValidateAndThrowAsync(options, token);

        return await _movieRepository.GetAllAsync(options, token);
    }

    public Task<Movie?> GetByIdAsync(
        Guid id,
        Guid? userId = default,
        CancellationToken token = default
    ) {
        return _movieRepository.GetByIdAsync(id, userId, token);
    }

    public Task<Movie?> GetBySlugAsync(
        string slug,
        Guid? userId = default,
        CancellationToken token = default
    ) {
        return _movieRepository.GetBySlugAsync(slug, userId, token);
    }

    public Task<int> GetCountAsync(
        string? title,
        int? yearOfRelease,
        CancellationToken token = default
    ) {
        return _movieRepository.GetCountAsync(title, yearOfRelease, token);
    }

    public async Task<Movie?> UpdateAsync(
        Movie movie,
        Guid? userId = default,
        CancellationToken token = default
    ) {
        await _movieValidator.ValidateAndThrowAsync(movie, cancellationToken: token);
        var movieExists = await _movieRepository.ExistsByIdAsync(movie.Id, token);
        if (!movieExists) {
            return null;
        }

        if (!userId.HasValue) {
            var rating = await _ratingRepository.GetRatingAsync(movie.Id, token);
            movie.Rating = rating;
            return movie;
        }

        var ratings = await _ratingRepository.GetRatingAsync(movie.Id, userId.Value, token);
        movie.Rating = ratings.Rating;
        movie.UserRating = ratings.UserRating;
        await _movieRepository.UpdateAsync(movie, token);
        return movie;
    }
}
