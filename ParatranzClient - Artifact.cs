using System.Net.Http.Headers;
using System.Net.Http.Json;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzArtifact?> GetArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "artifacts");

            return m_Client.GetFromJsonAsync<ParatranzArtifact>(url, token);
        }

        public async Task<ParatranzArtifactInfo?> PostArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "artifacts");

            var response = await m_Client.PostAsJsonAsync(url, token);
            return await response.Content.ReadFromJsonAsync<ParatranzArtifactInfo>(options: null, token);
        }

        public async Task<Stream?> DownloadArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "artifacts", "download");

            var response = await m_Client.GetAsync(url, token);
            return await response.Content.ReadAsStreamAsync(token);
        }
    }

    public class ParatranzArtifact
    {
        public int id { get; set; }
        public string? createdAt { get; set; }
        public int project { get; set; }
        public int total { get; set; }
        public int translated { get; set; }
        public int disputed { get; set; }
        public int reviewed { get; set; }
        public int hidden { get; set; }
        public int duration { get; set; }
    }

    public class ParatranzArtifactInfo
    {
        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? startedAt { get; set; }
        public string? finishedAt { get; set; }
        public string? scheduledAt { get; set; }
        public int project { get; set; }
        public int uid { get; set; }
        public string? type { get; set; }
        public int status { get; set; }
    }
}