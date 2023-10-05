
namespace ParatranzAPI
{
    public record ParatranzArtifact
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public int Project { get; init; }
        public int Total { get; init; }
        public int Translated { get; init; }
        public int Disputed { get; init; }
        public int Reviewed { get; init; }
        public int Hidden { get; init; }
        public int Duration { get; init; }
    }

    public record ParatranzBuildInfo
    {
        public int Project { get; init; }
        //public string Type { get; init; }
        public int uid { get; init; }
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        //public DateTime? StartedAt { get; init; }
        //public DateTime? FinishedAt { get; init; }
        //public DateTime? ScheduledAt { get; init; }
    }
}