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

        public void DeleteStringAsync(int projectId, int stringId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            DeleteAsync(url, token);
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

    public class ParatranzStringPage
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public ParatranzString[]? result { get; set; }
    }

    public class ParatranzString
    {
        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? updatedAt { get; set; }
        public string? key { get; set; }
        public string? original { get; set; }
        public string? translation { get; set; }
        public int file { get; set; }
        public int stage { get; set; }
        public int project { get; set; }
        public int uid { get; set; }
        public string? context { get; set; }
        public int words { get; set; }
    }

    public class ParatranzStringRequest
    {
        public string? key { get; set; }
        public string? original { get; set; }
        public string? translation { get; set; }
        public int file { get; set; }
        public int stage { get; set; }
        public string? context { get; set; }
    }
}