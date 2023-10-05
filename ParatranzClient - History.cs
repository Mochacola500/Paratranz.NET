using System.Net.Http.Json;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzHistoryPage?> GetUserHistoryAsync(int project, TranslateHistoryType type, int uid, int tid, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var type_str = type.ToString();
            var query = new
            {
                project = project,
                uid = uid,
                tid = tid,
                type = type_str,
                page = page,
                pageSize = pageSize
            };
            var url = "history".SetQueryParams(query);

            return GetAsync<ParatranzHistoryPage>(url, token);
        }

        public Task<ParatranzHistory?> GeFiletHistoryAsync(int projectId, int file, FileHistoryType type, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var type_str = type.ToString();
            var query = new
            {
                file = file,
                type = type_str,
                page = page,
                pageSize = pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "files", "revisions")
                .SetQueryParams(query);

            return GetAsync<ParatranzHistory>(url, token);
        }
    }
}