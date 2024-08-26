
namespace Paratranz.NET
{
    public class S2C_ProjectResponse : Data_Project
    {

    }

    public class C2S_ProjectRequest
    {
        public string? Name { get; set; }
        public Uri? Logo { get; set; }
        public string? Desc { get; set; }
        public string? Source { get; set; }
        public string? Dest { get; set; }
        public string? Game { get; set; }
        public int Privacy { get; set; }
        public int Download { get; set; }
        public int IssueMode { get; set; }
        public int ReviewMode { get; set; }
        public int JoinMode { get; set; }
    }

    public class Data_Project
    {
        #region Field Declaration

        public class FormatInfo
        {
            public string? yml { get; set; }
            public string? txt { get; set; }
        }

        public class ExtraInfo
        {
            public string? Link { get; set; }
            public bool Chars { get; set; }
            public bool IsMod { get; set; }
            public string? Credit { get; set; }
            public string[]? Titles { get; set; }
            public string? Version { get; set; }
            public string? Compatible { get; set; }
            public string? CreditLink { get; set; }
            public bool CustomTests { get; set; }
            public string? PublishLink { get; set; }
            public bool HasTranslation { get; set; }
            public bool DisableBatchSave { get; set; }
        }

        public class StatInfo
        {
            public int Id { get; set; }
            public DateTime? DeletedAt { get; set; }
            public DateTime? ModifiedAt { get; set; }
            public int Total { get; set; }
            public int Translated { get; set; }
            public int Disputed { get; set; }
            public int Checkd { get; set; }
            public int Reviewed { get; set; }
            public int Hidden { get; set; }
            public int Locked { get; set; }
            public int Words { get; set; }
            public int Members { get; set; }
            public float tp { get; set; }
            public float cp { get; set; }
            public float rp { get; set; }
        }

        #endregion // Field

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int uid { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Desc { get; set; }
        public string? Source { get; set; }
        public string? Dest { get; set; }
        public int Members { get; set; }
        public string? Game { get; set; }
        public string? License { get; set; }
        public float ActiveLevel { get; set; }
        public int Stage { get; set; }
        public int Privacy { get; set; }
        public int Download { get; set; }
        public int IssueMode { get; set; }
        public int ReviewMode { get; set; }
        public int JoinMode { get; set; }
        public ExtraInfo? Extra { get; set; }
        public StatInfo? Stats { get; set; }
        public string[]? RelatedGames { get; set; }
        public bool IsPrivate { get; set; }
        public string? GameName { get; set; }
        public FormatInfo? Formats { get; set; }
    }
}