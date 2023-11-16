using Flurl;

namespace Paratranz.NET
{
    public record ParatranzUser
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public DateTime? LastVisit { get; init; }
        public string? UserName { get; init; }
        public string? NickName { get; init; }
        public string? Bio { get; init; }
        public Uri? Avatar { get; init; }
        public Uri? Email { get; init; }
        public int Github { get; init; }
        public int Role { get; init; }
        public int Credit { get; init; }
        public int Translated { get; init; }
        public int Reviewed { get; init; }
        public int Commented { get; init; }
        public int Edited { get; init; }
        public float Points { get; init; }
        public DateTime? DeletedAt { get; init; }
        public int AbusesCount { get; init; }
        public bool IsOnline { get; init; }

        public Uri BuildGithubLink()
        {
            return "github.com".AppendPathSegment(Github).ToUri();
        }
    }
}