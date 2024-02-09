
namespace Paratranz.NET
{
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
        public int tid { get; init; }
        public IssuesStatus Status { get; init; }
    }
}