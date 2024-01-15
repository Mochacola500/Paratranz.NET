
namespace Paratranz.NET
{
    public record ParatranzMail
    {
        public int Id { get; init; }
        public DateTime? CreatedAt { get; init; }        
        public int From { get; init; }
        public ParatranzUser? FromUser { get; init; }
        public int To { get; init; }
        public ParatranzUser? ToUser { get; init; }
        public string? Content { get; init; }
        public string? HTML { get; init; }
        public int Status { get; init; }
    }
}
