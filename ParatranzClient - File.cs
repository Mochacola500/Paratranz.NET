using Flurl;
using System.Text.Json.Nodes;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzFile?> GetFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return GetAsync<ParatranzFile>(url, token);
        }

        public Task<ParatranzFile?> GetFileAsync(int projectId, int fileId, string file, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return PostAsync<string, ParatranzFile>(url, file, token);
        }

        public Task<ParatranzFile?> GetFileAsync(int projectId, int fileId, string file, string path, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId, "translation");
            var json = new JsonObject
            {
                ["file"] = file,
                ["path"] = path,
            };

            return PostAsync<JsonObject, ParatranzFile>(url, json, token);
        }

        public Task<ParatranzFile[]?> GetFilesAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files");

            return GetAsync<ParatranzFile[]>(url, token);
        }

        public Task<ParatranzFilePage?> GetFilePageAsync(int projectId, string file, string path, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var json = new JsonObject
            {
                ["file"] = file,
                ["path"] = path,
            };

            return PostAsync<JsonObject, ParatranzFilePage>(url, json, token);
        }

        public void DeleteFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            DeleteAsync(url, token);
        }

        public Task<Stream?> DownloadFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId, "translation");

            return DownloadAsync(url, token);
        }
    }

    public class ParatranzFilePage
    {
        public ParatranzFile? file { get; set; }
        public ParatranzFileRevision? revision { get; set; }
    }

    public class ParatranzFile
    {
        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? updatedAt { get; set; }
        public string? name { get; set; }
        public int project { get; set; }
        public string? format { get; set; }
        public int total { get; set; }
        public int translated { get; set; }
        public int disputed { get; set; }
        public int @checked { get; set; }
        public int reviewed { get; set; }
        public int hidden { get; set; }
        public int locked { get; set; }
        public int words { get; set; }
    }

    public class ParatranzFileRevision
    {
        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? name { get; set; }
        public string? filename { get; set; }
        public string? type { get; set; }
        public int file { get; set; }
        public int uid { get; set; }
        public int project { get; set; }
        public int insert { get; set; }
        public int update { get; set; }
        public int remove { get; set; }
        public string? hash { get; set; }
        public bool force { get; set; }
        public bool incremental { get; set; }
    }
}