using System.Net.Http.Json;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzHistory?> GetHistoryAsync(int projectId, int termId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "terms", termId, "history");

            return m_Client.GetFromJsonAsync<ParatranzHistory>(url, token);
        }

        public Task<ParatranzHistory?> GetHistoryAsync(int projectId, int file, HistoryType type, int page = 1, int pageSize = 50, CancellationToken token = default)
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

        public Task<ParatranzHistoryPage?> GetHistoryPageAsync(int project, int uid, int tid, HistoryType type, int page = 1, int pageSize = 50, CancellationToken token = default)
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
    }

    public enum HistoryType
    {
        text,
        import,
        comment,
    }

    public class ParatranzHistoryPage
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public ParatranzHistory[]? results { get; set; }
    }

    public class ParatranzHistory
    {
        public class Target
        {
            public string? key { get; set; }
            public int stage { get; set; }
            public string? original { get; set; }
            public string? tanslation { get; set; }
        }

        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? field { get; set; }
        public int uid { get; set; }
        public int tid { get; set; }
        public string? from { get; set; }
        public string? to { get; set; }
        public Target? target { get; set; }
        public string? operation { get; set; }
    }
}