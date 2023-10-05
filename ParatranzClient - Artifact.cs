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

        public Task<ParatranzBuildInfo?> BuildArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts");

            return PostAsync<object, ParatranzBuildInfo>(url, null, token);
        }

        public Task<Stream> DownloadArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts", "download");

            return DownloadAsync(url, token);
        }
    }
}