
namespace Paratranz.NET
{
    public record ParatranzString
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string? Key { get; init; }
        public string? Original { get; init; }
        public string? Translation { get; init; }
        public int Stage { get; init; }
        public int Project { get; init; }
        public string? Context { get; init; }
        public int Words { get; init; }
        public int Version { get; init; }
        public int FileId { get; init; }

        public ParatranzStringRequest CreateRequest(int file)
        {
            return new ParatranzStringRequest
            {
                Key = Key,
                Original = Original,
                Translation = Translation,
                File = file,
                Stage = Stage,
                Context = Context,
            };
        }
    }

    public record ParatranzStringRequest
    {
        public string? Key { get; init; }
        public string? Original { get; init; }
        public string? Translation { get; init; }
        public int File { get; init; }
        public int Stage { get; init; }
        public string? Context { get; init; }
    }
}
