using System.Net.Http.Headers;
using System.Net.Http.Json;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzStringList?> GetStringListAsync(int projectId, int file, int stage, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var url = "projects/"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(new { file = file, stage = stage, page = page, pageSize = pageSize });

            return m_Client.GetFromJsonAsync<ParatranzStringList>(url, token);
        }

        public async Task<ParatranzString?> PostStringAsync(int projectId, ParatranzStringRequest request, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var url = "projects/"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(new {page = page, pageSize = pageSize});

            var response = await m_Client.PostAsJsonAsync(url, request, token);

            return await response.Content.ReadFromJsonAsync<ParatranzString>(options: null, token);
        }

        public Task<ParatranzString?> GetStringAsync(int projectId, int stringId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "strings", stringId);

            return m_Client.GetFromJsonAsync<ParatranzString>(url, token);
        }

        public async Task<ParatranzString?> PutStringAsync(int projectId, int stringId, ParatranzStringRequest request, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "strings", stringId);
            var response = await m_Client.PutAsJsonAsync(url, request, token);

            return await response.Content.ReadFromJsonAsync<ParatranzString>(options:null, token);
        }

        public void DeleteStringAsync(int projectId, int stringId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "strings", stringId);

            m_Client.DeleteAsync(url, token);
        }
    }

    public class ParatranzStringList
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