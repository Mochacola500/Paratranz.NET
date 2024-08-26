
namespace Paratranz.NET
{
    public class S2C_PageResponse<TSchema>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int PageCount { get; set; }
        public TSchema?[]? Results { get; set; }
    }
}