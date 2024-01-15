using Flurl;
using System.Text.Json.Nodes;

namespace Paratranz.NET
{
    public partial class ParatranzClient
    {
        public Task<ParatranzFile?> GetFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return GetAsync<ParatranzFile>(url, token);
        }

        public Task<ParatranzFile?> AddFileAsync(int projectId, string fileName, byte[] bytes, string path, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var content = new MultipartFormDataContent()
            {
                { new ByteArrayContent(bytes), "file", fileName },
                { new StringContent(path), "path" }
            };

            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile?> UpdateFileAsync(int projectId, int fileId, string fileName, byte[] bytes, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);
            var content = new MultipartFormDataContent()
            {
                { new ByteArrayContent(bytes), "file", fileName }
            };
            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile?> AddFileAsync(int projectId, string file, string path, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var bytes = File.ReadAllBytes(file);
            var content = new MultipartFormDataContent()
            {
                { new ByteArrayContent(bytes), "file", Path.GetFileName(file) },
                { new StringContent(path), "path" }
            };

            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile?> UpdateFileAsync(int projectId, int fileId, string file, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);
            var bytes = File.ReadAllBytes(file);
            var content = new MultipartFormDataContent()
            {
                { new ByteArrayContent(bytes), "file", Path.GetFileName(file) }
            };
            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile[]?> GetFilesAsync(int projectId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files");

            return GetAsync<ParatranzFile[]>(url, token);
        }

        public Task<ParatranzFileInfo?> GetFilePageAsync(int projectId, string file, string path, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var json = new JsonObject
            {
                ["file"] = file,
                ["path"] = path,
            };

            return PostAsync<JsonObject, ParatranzFileInfo>(url, json, token);
        }

        public Task<bool> DeleteFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return DeleteAsync(url, token);
        }

        public Task<Stream> DownloadFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId, "translation");

            return DownloadAsync(url, token);
        }
    }
}