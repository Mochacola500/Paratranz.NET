using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzScorePage?> GetScorePageAsync(int projectId, int uid, OperationType type, string start, string end, int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var type_str = type.ToString();
            var query = new
            {
                page = page,
                pageSize = pageSize,
                uid = uid,
                operation = type_str,
                start = start,
                end = end
            };
            var url = "projects"
                .AppendPathSegments(projectId, "scores")
                .SetQueryParams(query);

            return GetAsync<ParatranzScorePage>(url, token);
        }
    }

    public enum OperationType
    {
        translate,
        edit,
        review
    }

    public class ParatranzScorePage
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public string? createdAt { get; set; }
        public ParatranzScore[]? results { get; set; }
    }

    public class ParatranzScore
    {
        public int Id { get; set; }
        public string? createdAt { get; set; }
        public int project { get; set; }
        public int uid { get; set; }
        public float @base { get; set; }
        public float multiplier { get; set; }
        public float value { get; set; }
    }
}