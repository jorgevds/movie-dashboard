using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Controllers;

[ApiController]
public class MoviesController : ControllerBase {
    private readonly IMovieService _movieService;

    // zero-to-hero-rest/rest-api-course-final-master/src/Movies.Api/bin/Debug/net7.0/Movies.Api.dll
    public MoviesController(IMovieService movieService) {
        _movieService = movieService;
    }

    [Authorize(AuthConstants.TrustedMemberPolicyName)]
    [HttpPost(ApiEndpoints.Movies.Create)]
    public async Task<IActionResult> Create(
        [FromBody] CreateMovieRequest request,
        CancellationToken token
    ) {
        var userId = HttpContext.GetUserId();
        var movie = request.MapToMovie();
        await _movieService.CreateAsync(movie, userId!.Value, token);
        return CreatedAtAction(
            nameof(Get),
            new {
                idOrSlug = movie.Id,
            },
            movie
        );
    }

    [HttpGet(ApiEndpoints.Movies.Get)]
    public async Task<IActionResult> Get(
        [FromRoute] string idOrSlug,
        [FromServices] LinkGenerator linkGenerator,
        CancellationToken token
    ) {
        var userId = HttpContext.GetUserId();

        var movie = Guid.TryParse(idOrSlug, out var id)
            ? await _movieService.GetByIdAsync(id, userId, token)
            : await _movieService.GetBySlugAsync(idOrSlug, userId, token);

        if (movie is null) {
            return NotFound();
        }

        var response = movie.MapToResponse();

        var movieObj = new {
            id = movie.Id,
        };
        response.Links.Add(
            new Link {
                Href = linkGenerator.GetPathByAction(
                    HttpContext,
                    nameof(Get),
                    values: new {
                        idOrSlug = movie.Id,
                    }
                ),
                Rel = "self",
                Type = "GET",
            }
        );
        response.Links.Add(
            new Link {
                Href = linkGenerator.GetPathByAction(HttpContext, nameof(Update), values: movieObj),
                Rel = "self",
                Type = "PUT",
            }
        );
        response.Links.Add(
            new Link {
                Href = linkGenerator.GetPathByAction(HttpContext, nameof(Delete), values: movieObj),
                Rel = "self",
                Type = "DELETE",
            }
        );

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll(
        [FromQuery] GetAllMoviesRequest request,
        CancellationToken token
    ) {
        Console.WriteLine("Getting all movies...");
        Guid? userId = HttpContext.GetUserId();
        var options = request.MapToOptions().WithUserId(userId);
        var movies = await _movieService.GetAllAsync(options, token);
        var count = await _movieService.GetCountAsync(options.Title, options.YearOfRelease, token);

        var moviesResponse = movies.MapToResponse(request.Page, request.PageSize, count);
        return Ok(moviesResponse);
    }

    [Authorize(AuthConstants.TrustedMemberPolicyName)]
    [HttpPut(ApiEndpoints.Movies.Update)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateMovieRequest request,
        CancellationToken token
    ) {
        var userId = HttpContext.GetUserId();

        var movie = request.MapToMovie(id);
        var updated = await _movieService.UpdateAsync(movie, userId, token);

        if (updated is null) {
            return NotFound();
        }

        var response = movie.MapToResponse();
        return Ok(response);
    }

    [Authorize(AuthConstants.AdminUserPolicyName)]
    [HttpDelete(ApiEndpoints.Movies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token) {
        var userId = HttpContext.GetUserId();

        var deleted = await _movieService.DeleteByIdAsync(id, userId, token);
        if (deleted) {
            return Ok();
        }

        return NotFound();
    }
}
