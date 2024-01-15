using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient //NOSONAR
    {
        public Task<ParatranzProject?> CreateProjectAsync(int projectId, ParatranzProjectRequest request, CancellationToken token)
        {
            var url = "projects/".AppendPathSegment(projectId);

            return PutAsync<ParatranzProjectRequest, ParatranzProject>(url, request, token);
        }

        public Task<bool> DeleteProjectAsync(int projectId, CancellationToken token)
        {
            var url = "projects/".AppendPathSegment(projectId);

            return DeleteAsync(url, token);
        }

        public Task<ParatranzProject?> GetProjectAsync(int projectId, CancellationToken token)
        {
            var url = "projects/".AppendPathSegment(projectId);

            return GetAsync<ParatranzProject>(url, token);
        }

        public Task<ParatranzProject?> GetProjectAsync(ParatranzProjectRequest request, CancellationToken token)
        {
            return PostAsync<ParatranzProjectRequest, ParatranzProject>("projects", request, token);
        }

        public Task<ParatranzPage<ParatranzProject>?> GetProjectPageAsync(int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                page,
                pageSize,
            };
            var url = "projects".SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzProject>>(url, token);
        }
    }
}