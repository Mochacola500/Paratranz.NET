
namespace Paratranz.NET
{
    public enum OperationType
    {
        Translate,
        Edit,
        Review
    }

    public record ParatranzScorePage
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int RowCount { get; init; }
        public int PageCount { get; init; }
        public ParatranzScore[]? results { get; init; }
    }

    public record ParatranzScore
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public int uid { get; init; }
        public int Project { get; init; }
        public int tid { get; init; }
        public float Base { get; init; }
        public float Multiplier { get; init; }
        public float Value { get; init; }
        public ParatranzUser? User { get; init; }
    }
}
