
namespace ParatranzAPI
{
    public record ParatranzStringPage
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int RowCount { get; init; }
        public ParatranzString[]? Result { get; init; }
    }

    public record ParatranzString
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string? Key { get; init; }
        public string? Original { get; init; }
        public string? Translation { get; init; }
        public int File { get; init; }
        public int Stage { get; init; }
        public int Project { get; init; }
        public int uid { get; init; }
        public string? Context { get; init; }
        public string? Extra { get; init; }
        public int Words { get; init; }
        public int Version { get; init; }
        public int FileId { get; init; }
    }

    public record ParatranzStringRequest
    {
        public string? Key { get; set; }
        public string? Original { get; set; }
        public string? Translation { get; set; }
        public int File { get; set; }
        public int Stage { get; set; }
        public string? Context { get; set; }
    }
}
