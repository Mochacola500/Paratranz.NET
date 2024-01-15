
namespace Paratranz.NET
{
    public class ParatranzPage<TItem>
    {
        public int Page {  get; init; }
        public int PageSize {  get; init; }
        public int RowCount {  get; init; }
        public int PageCount {  get; init; }
        public TItem[]? Results { get; init; }
    }
}