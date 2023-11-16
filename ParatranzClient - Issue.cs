using Flurl;
using System.Text.Json.Nodes;

namespace Paratranz.NET
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzIssuePage?> GetIssuePageAsync(int projectId, IssuesStatus status, CancellationToken token = default)
        {
            var query = new
            {
                status = status,
            };
            var url = "projects"
                .AppendPathSegments(projectId, "issues")
                .SetQueryParams(query);

            return GetAsync<ParatranzIssuePage>(url, token);
        }

        public Task<ParatranzIssue?> CreateIssueAsync(int projectId, string title, string content, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "issues");
            var json = new JsonObject
            {
                ["title"] = title,
                ["content"] = content
            };

            return PostAsync<JsonObject, ParatranzIssue>(url, json, token);
        }

        public Task<ParatranzIssue?> UpdateIssueAsync(int projectId, string issueId, string title, string content, IssuesStatus status, CancellationToken token = default)
        {
            var status_int = (int)status;
            var url = "projects".AppendPathSegments(projectId, "issues", issueId);
            var json = new JsonObject
            {
                ["title"] = title,
                ["content"] = content,
                ["status"] = status_int
            };

            return PutAsync<JsonObject, ParatranzIssue>(url, json, token);
        }

        public Task<bool> DeleteIssueAsync(int projectId, int issueId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "issues", issueId);

            return DeleteAsync(url, token);
        }
    }
}