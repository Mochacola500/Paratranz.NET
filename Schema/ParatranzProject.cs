
namespace ParatranzAPI
{
    public class ParatranzProjectPage
    {
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }
        public ParatranzProject[]? Results { get; set; }
    }

    public class ParatranzProject
    {
        public class Format
        {
            public string? yml { get; set; }
            public string? txt { get; set; }
        }

        public class Extra
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

        public class Stat
        {
            public int Id { get; set; }
            public string? deletedAt { get; set; }
            public string? modifiedAt { get; set; }
            public int total { get; set; }
            public int translated { get; set; }
            public int disputed { get; set; }
            public int checkd { get; set; }
            public int reviewed { get; set; }
            public int hidden { get; set; }
            public int locked { get; set; }
            public int words { get; set; }
            public int members { get; set; }
            public float tp { get; set; }
            public float cp { get; set; }
            public float rp { get; set; }
        }

        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? updatedAt { get; set; }
        public int uid { get; set; }
        public string? name { get; set; }
        public string? logo { get; set; }
        public string? desc { get; set; }
        public string? source { get; set; }
        public string? dest { get; set; }
        public int members { get; set; }
        public string? game { get; set; }
        public string? license { get; set; }
        public float activeLevel { get; set; }
        public int stage { get; set; }
        public int privacy { get; set; }
        public int download { get; set; }
        public int issueMode { get; set; }
        public int reviewMode { get; set; }
        public int joinMode { get; set; }
        public Extra? extra { get; set; }
        public Stat? stats { get; set; }
        public string[]? relatedGames { get; set; }
        public bool isPrivate { get; set; }
        public string? gameName { get; set; }
        public Format? formats { get; set; }
    }

    public class ParatranzProjectRequest
    {
        public string? name { get; set; }
        public string? logo { get; set; }
        public string? desc { get; set; }
        public string? source { get; set; }
        public string? dest { get; set; }
        public string? game { get; set; }
        public int privacy { get; set; }
        public int download { get; set; }
        public int issueMode { get; set; }
        public int reviewMode { get; set; }
        public int joinMode { get; set; }
    }
}