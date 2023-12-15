using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzPage<ParatranzScore>?> GetScorePageAsync(int projectId, int uid, ScoreType type, DateTime? start, DateTime? end, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var type_str = type.ToString();
            var query = new
            {
                page = page,
                pageSize = pageSize,
                uid = uid,
                operation = type_str,
                start = start,
                end = end
            };
            var url = "projects"
                .AppendPathSegments(projectId, "scores")
                .SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzScore>>(url, token);
        }
    }
}