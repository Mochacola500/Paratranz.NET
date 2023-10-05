
namespace ParatranzAPI
{
    public enum TranslateHistoryType
    {
        text,
        import,
        comment
    }

    public enum FileHistoryType
    {
        create,
        update,
        import
    }

    public record ParatranzHistoryPage
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int RowCount { get; init; }
        public int PageCount { get; init; }
        public ParatranzHistory[]? Results { get; init; }
    }

    public record ParatranzHistory
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public string? Field { get; init; }
        public int uid { get; init; }
        public int tid { get; init; }
        public string? From { get; init; }
        public string? To { get; init; }
        public ParatranzTranslation? Target { get; init; }
        public OperationType? Operation { get; init; }
        public ParatranzUser? User { get; init; }
        public ParatranzString? Related { get; init; }
    }

    public record ParatranzTranslation
    {
        public string? Key { get; init; }
        public int Stage { get; init; }
        public int Words { get; init; }
        public string? Original { get; init; }
        public string? Tanslation { get; init; }
    }
}