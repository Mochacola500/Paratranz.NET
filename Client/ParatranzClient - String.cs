using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient //NOSONAR
    {
        public Task<ParatranzString?> UpdateStringAsync(int projectId, int stringId, ParatranzStringRequest body, CancellationToken token)
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

        public Task<ParatranzString?> GetStringAsync(int projectId, ParatranzStringRequest body, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                page,
                pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(query);

            return PostAsync<ParatranzStringRequest, ParatranzString>(url, body, token);
        }

        public Task<ParatranzPage<ParatranzString>?> GetStringPageAsync(int projectId, int file, int stage, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                file,
                stage,
                page,
                pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzString>>(url, token);
        }
    }
}