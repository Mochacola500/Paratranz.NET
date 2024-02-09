
namespace Paratranz.NET
{
    public class ParatranzPage<TSchema>
    {
        public int Page {  get; init; }
        public int PageSize {  get; init; }
        public int RowCount {  get; init; }
        public int PageCount {  get; init; }
        public TSchema[]? Results { get; init; }
    }
}