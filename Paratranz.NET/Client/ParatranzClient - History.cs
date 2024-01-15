using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient //NOSONAR
    {
        public Task<ParatranzPage<ParatranzHistory>?> GetUserHistoryAsync(int project, TranslateHistoryType type, int uid, int tid, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                project,
                uid,
                tid,
                type = type.ToString(),
                page,
                pageSize
            };
            var url = "history".SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzHistory>>(url, token);
        }

        public Task<ParatranzHistory?> GeFiletHistoryAsync(int projectId, int file, FileHistoryType type, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                file,
                type = type.ToString(),
                page,
                pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "files", "revisions")
                .SetQueryParams(query);

            return GetAsync<ParatranzHistory>(url, token);
        }
    }
}