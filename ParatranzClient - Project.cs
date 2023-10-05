using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzProject?> CreateProjectAsync(int projectId, ParatranzProjectRequest request, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegment(projectId);

            return PutAsync<ParatranzProjectRequest, ParatranzProject>(url, request, token);
        }

        public Task<bool> DeleteProjectAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegment(projectId);

            return DeleteAsync(url, token);
        }

        public Task<ParatranzProject?> GetProjectAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects/".AppendPathSegment(projectId);

            return GetAsync<ParatranzProject>(url, token);
        }

        public Task<ParatranzProject?> GetProjectAsync(ParatranzProjectRequest request, CancellationToken token = default)
        {
            return PostAsync<ParatranzProjectRequest, ParatranzProject>("projects", request, token);
        }

        public Task<ParatranzProjectPage?> GetProjectPageAsync(int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var query = new
            {
                page = page,
                pageSize = pageSize,
            };
            var url = "projects".SetQueryParams(query);

            return GetAsync<ParatranzProjectPage>(url, token);
        }
    }

    public class ParatranzProjectPage
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public ParatranzProject[]? results { get; set; }
    }

    public class ParatranzProject
    {
        public class Format
        {
            public string? yml { get; set; }
            public string? txt { get; set; }
        }

        public class Extra
        {
            public string? link { get; set; }
            public bool chars { get; set; }
            public bool isMod { get; set; }
            public string? credit { get; set; }
            public string[]? titles { get; set; }
            public string? version { get; set; }
            public string? compatible { get; set; }
            public string? creditLink { get; set; }
            public bool customTests { get; set; }
            public string? publishLink { get; set; }
            public bool hasTranslation { get; set; }
            public bool disableBatchSave { get; set; }
        }

        public class Stat
        {
            public int id { get; set; }
            public string? deletedAt { get; set; }
            public string? modifiedAt { get; set; }
            public int total { get; set; }
            public int translated { get; set; }
            public int disputed { get; set; }
            public int checkd { get; set; }
            public int reviewed { get; set; }
            public int hidden { get; set; }
            public int locked { get; set; }
            public int words { get; set; }
            public int members { get; set; }
            public float tp { get; set; }
            public float cp { get; set; }
            public float rp { get; set; }
        }

        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? updatedAt { get; set; }
        public int uid { get; set; }
        public string? name { get; set; }
        public string? logo { get; set; }
        public string? desc { get; set; }
        public string? source { get; set; }
        public string? dest { get; set; }
        public int members { get; set; }
        public string? game { get; set; }
        public string? license { get; set; }
        public float activeLevel { get; set; }
        public int stage { get; set; }
        public int privacy { get; set; }
        public int download { get; set; }
        public int issueMode { get; set; }
        public int reviewMode { get; set; }
        public int joinMode { get; set; }
        public Extra? extra { get; set; }
        public Stat? stats { get; set; }
        public string[]? relatedGames { get; set; }
        public bool isPrivate { get; set; }
        public string? gameName { get; set; }
        public Format? formats { get; set; }
    }

    public class ParatranzProjectRequest
    {
        public string? name { get; set; }
        public string? logo { get; set; }
        public string? desc { get; set; }
        public string? source { get; set; }
        public string? dest { get; set; }
        public string? game { get; set; }
        public int privacy { get; set; }
        public int download { get; set; }
        public int issueMode { get; set; }
        public int reviewMode { get; set; }
        public int joinMode { get; set; }
    }
}