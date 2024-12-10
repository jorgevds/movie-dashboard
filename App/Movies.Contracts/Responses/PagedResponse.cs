namespace Movies.Contracts.Responses;

public class PagedResponse<T> {
    public required IEnumerable<T> Items { get; init; } = Enumerable.Empty<T>();
    public required int Page { get; init; } = 1;
    public required int PageSize { get; init; } = 1;
    public required int Total { get; init; } = 1;
    public bool HasNextPage => Total >= (Page * PageSize);
}
