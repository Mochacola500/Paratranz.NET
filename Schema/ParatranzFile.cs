
namespace Paratranz.NET
{
    public record ParatranzFileInfo
    {
        public ParatranzFile? File { get; init; }
        public ParatranzFileRevision? Revision { get; init; }
    }

    public record ParatranzFile
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string? Name { get; init; }
        public int Project { get; init; }
        public string? Format { get; init; }
        public int Total { get; init; }
        public int Translated { get; init; }
        public int Disputed { get; init; }
        public int Checked { get; init; }
        public int Reviewed { get; init; }
        public int Hidden { get; init; }
        public int Locked { get; init; }
        public int Words { get; init; }
    }

    public record ParatranzFileRevision
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public string? Name { get; init; }
        public string? FileName { get; init; }
        public string? Type { get; init; }
        public int File { get; init; }
        public int uid { get; init; }
        public int Project { get; init; }
        public int Insert { get; init; }
        public int Update { get; init; }
        public int Remove { get; init; }
        public string? Hash { get; init; }
        public bool Force { get; init; }
        public bool Incremental { get; init; }
    }
}