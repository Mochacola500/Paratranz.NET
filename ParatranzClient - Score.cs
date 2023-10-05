using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzScorePage?> GetScorePageAsync(int projectId, int uid, OperationType type, DateTime? start, DateTime? end, int page = 1, int pageSize = 50, CancellationToken token = default)
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

            return GetAsync<ParatranzScorePage>(url, token);
        }
    }
}