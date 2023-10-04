using System.Net.Http.Headers;
using System.Net.Http.Json;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzScore?> GetScoreAsync(int projectId, int uid, OperationType type, string start, string end, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var url = "projects/"
                .AppendPathSegments(projectId, "scores")
                .SetQueryParams(new { page = page, pageSize = pageSize, uid = uid, operation = type.ToString(), start = start, end = end  });

            return m_Client.GetFromJsonAsync<ParatranzScore>(url, token);
        }
    }

    public enum OperationType
    {
        translate,
        edit,
        review
    }

    public class ParatranzScore
    {
        public class Info
        {
            public int Id { get; set; }
            public string?createdAt { get; set; }
            public int project { get; set; }
            public int uid { get; set; }
            public float @base { get; set; }
            public float multiplier { get; set; }
            public float value { get; set; }
        }

        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public string? createdAt { get; set; }
        public Info[]? results { get; set; }
    }
}