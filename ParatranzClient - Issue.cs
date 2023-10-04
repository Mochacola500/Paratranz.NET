using System.Net.Http.Headers;
using System.Net.Http.Json;
using Flurl;
using System.Text.Json.Nodes;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzIssue?> GetIssueAsync(int projectId, IssuesStatus status, CancellationToken token = default)
        {
            var url = "projects/"
                .AppendPathSegments(projectId, "issues")
                .SetQueryParams(new { status = (int)status });

            return m_Client.GetFromJsonAsync<ParatranzIssue>(url, token);
        }

        public async Task<ParatranzIssue.Discussion?> PostIssueAsync(int projectId, string title, string content, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "issues");
            var json = new JsonObject
            {
                ["title"] = title,
                ["content"] = content
            };

            var response = await m_Client.PostAsJsonAsync(url, json, token);
            return await response.Content.ReadFromJsonAsync<ParatranzIssue.Discussion>(options: null, token);
        }

        public void DeleteIssueAsync(int projectId, int issueId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegments(projectId, "issues", issueId);

            m_Client.DeleteAsync(url, token);
        }
    }

    public enum IssuesStatus
    {
        Discussion = 0,
        Closed = 1,
    }

    public class ParatranzIssue
    {
        public class Discussion
        {
            public int id { get; set; }
            public string? createdAt { get; set; }
            public string? updatedAt { get; set; }
            public int project { get; set; }
            public int uid { get; set; }
            public int parent { get; set; }
            public string? title { get; set; }
            public string? content { get; set; }
            public string? html { get; set; }
            public int status { get; set; }
            public int lastEdit { get; set; }
            public int[]? refer { get; set; }
            public int[]? subscribers { get; set; }
            public int childrenCount { get; set; }
            public string? repliedAt { get; set; }
        }

        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public int closedCount { get; set; }
        public int openCount { get; set; }
        public Discussion[]? results { get; set; }
    }
}