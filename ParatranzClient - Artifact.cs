using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzArtifact?> GetArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts");

            return GetAsync<ParatranzArtifact>(url, token);
        }

        public Task<Stream?> DownloadArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts", "download");

            return DownloadAsync(url, token);
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
}