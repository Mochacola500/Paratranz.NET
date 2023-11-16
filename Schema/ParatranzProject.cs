
namespace Paratranz.NET
{
    public record ParatranzProjectPage
    {
        public int Page { get; init; }
        public int PageCount { get; init; }
        public int RowCount { get; init; }
        public ParatranzProject[]? Results { get; init; }
    }

    public record ParatranzProject
    {
        public record FormatInfo
        {
            public string? yml { get; init; }
            public string? txt { get; init; }
        }

        public record ExtraInfo
        {
            public string? Link { get; init; }
            public bool Chars { get; init; }
            public bool IsMod { get; init; }
            public string? Credit { get; init; }
            public string[]? Titles { get; init; }
            public string? Version { get; init; }
            public string? Compatible { get; init; }
            public string? CreditLink { get; init; }
            public bool CustomTests { get; init; }
            public string? PublishLink { get; init; }
            public bool HasTranslation { get; init; }
            public bool DisableBatchSave { get; init; }
        }

        public record StatInfo
        {
            public int Id { get; init; }
            public DateTime? DeletedAt { get; init; }
            public DateTime? ModifiedAt { get; init; }
            public int Total { get; init; }
            public int Translated { get; init; }
            public int Disputed { get; init; }
            public int Checkd { get; init; }
            public int Reviewed { get; init; }
            public int Hidden { get; init; }
            public int Locked { get; init; }
            public int Words { get; init; }
            public int Members { get; init; }
            public float tp { get; init; }
            public float cp { get; init; }
            public float rp { get; init; }
        }

        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public int uid { get; init; }
        public string? Name { get; init; }
        public string? Logo { get; init; }
        public string? Desc { get; init; }
        public string? Source { get; init; }
        public string? Dest { get; init; }
        public int Members { get; init; }
        public string? Game { get; init; }
        public string? License { get; init; }
        public float ActiveLevel { get; init; }
        public int Stage { get; init; }
        public int Privacy { get; init; }
        public int Download { get; init; }
        public int IssueMode { get; init; }
        public int ReviewMode { get; init; }
        public int JoinMode { get; init; }
        public ExtraInfo? Extra { get; init; }
        public StatInfo? Stats { get; init; }
        public string[]? RelatedGames { get; init; }
        public bool IsPrivate { get; init; }
        public string? GameName { get; init; }
        public FormatInfo? Formats { get; init; }
    }

    public record ParatranzProjectRequest
    {
        public string? Name { get; init; }
        public string? Logo { get; init; }
        public string? Desc { get; init; }
        public string? Source { get; init; }
        public string? Dest { get; init; }
        public string? Game { get; init; }
        public int Privacy { get; init; }
        public int Download { get; init; }
        public int IssueMode { get; init; }
        public int ReviewMode { get; init; }
        public int JoinMode { get; init; }
    }
}