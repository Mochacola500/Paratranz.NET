using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient // NOSONAR
    {
        public Task<ParatranzArtifact?> GetArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts");

            return GetAsync<ParatranzArtifact>(url, token);
        }

        public Task<ParatranzBuildInfo?> BuildArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts");

            return PostAsync<object, ParatranzBuildInfo>(url, new { }, token);
        }

        public Task<Stream> DownloadArtifactAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts", "download");

            return DownloadAsync(url, token);
        }
    }
}