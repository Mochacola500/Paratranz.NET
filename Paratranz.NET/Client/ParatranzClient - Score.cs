using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient //NOSONAR
    {
        public Task<ParatranzPage<ParatranzScore>?> GetScorePageAsync(int projectId, int uid, ScoreType type, DateTime? start, DateTime? end, int page, int pageSize, CancellationToken token)
        {
            var type_str = type.ToString();
            var query = new
            {
                page,
                pageSize,
                uid,
                operation = type_str,
                start,
                end
            };
            var url = "projects"
                .AppendPathSegments(projectId, "scores")
                .SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzScore>>(url, token);
        }
    }
}