using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzString?> AddStringAsync(int projectId, int stringId, ParatranzStringRequest body, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            return PutAsync<ParatranzStringRequest, ParatranzString>(url, body, token);
        }

        public Task<bool> DeleteStringAsync(int projectId, int stringId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            return DeleteAsync(url, token);
        }

        public Task<ParatranzString?> GetStringAsync(int projectId, int stringId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            return GetAsync<ParatranzString>(url, token);
        }

        public Task<ParatranzString?> GetStringAsync(int projectId, ParatranzStringRequest body, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var query = new
            {
                page = page,
                pageSize = pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(query);

            return PostAsync<ParatranzStringRequest, ParatranzString>(url, body, token);
        }

        public Task<ParatranzStringPage?> GetStringPageAsync(int projectId, int file, int stage, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var query = new
            {
                file = file,
                stage = stage,
                page = page,
                pageSize = pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(query);

            return GetAsync<ParatranzStringPage>(url, token);
        }
    }
}