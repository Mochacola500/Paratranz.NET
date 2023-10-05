
namespace ParatranzAPI
{
    public enum IssuesStatus
    {
        Discussion = 0,
        Closed = 1,
    }

    public record ParatranzIssuePage
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int RowCount { get; init; }
        public int PageCount { get; init; }
        public int OpenCount { get; init; }
        public int ClosedCount { get; init; }
        public ParatranzIssue[]? Results { get; init; }
    }

    public record ParatranzIssue
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public int Project { get; init; }
        public int uid { get; init; }
        public string? Parent { get; init; }
        public string? Title { get; init; }
        public IssuesStatus Status { get; init; }
        public int? LastEdit { get; init; }
        public int ChildrenCount { get; init; }
        public DateTime? RepliedAt { get; init; }
        public ParatranzUser? User { get; init; }
        public ParatranzSubscriber[]? Subscribers { get; init; }
    }

    public record ParatranzSubscriber
    {
        public int Id { get; init; }
        public DateTime? CreateAt { get; init; }
        public int uid { get; init; }
        //public string? Type { get; init; }
        public int tid { get; init; }
        public IssuesStatus Status { get; init; }
    }
}