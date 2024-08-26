
namespace Paratranz.NET
{
    public partial class ParatranzService
    {
        public Task<S2C_ProjectResponse?> CreateProjectAsync(C2S_ProjectRequest projectRequest, CancellationToken token)
        {
            string endPoint = "projects/";

            return Client.PostAsync<C2S_ProjectRequest, S2C_ProjectResponse>(endPoint, projectRequest, token);
        }

        public Task<bool> DeleteProjectAsync(int projectId, CancellationToken token)
        {
            var endPoint = "projects/" + projectId;

            return Client.DeleteAsync(endPoint, token);
        }

        public Task<S2C_ProjectResponse?> UpdateProjectAsync(int projectId, C2S_ProjectRequest projectRequest, CancellationToken token)
        {
            string endPoint = "projects/" + projectId;

            return Client.PutAsync<C2S_ProjectRequest, S2C_ProjectResponse>(endPoint, projectRequest, token);
        }

        public Task<S2C_ProjectResponse?> GetProjectAsync(int projectId, CancellationToken token)
        {
            string endPoint = "projects/" + projectId;

            return Client.GetAsync<S2C_ProjectResponse>(endPoint, token);
        }
    }
}
