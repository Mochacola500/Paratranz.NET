﻿using Flurl;
using System.Text.Json.Nodes;

namespace Paratranz.NET
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzFile?> GetFileAsync(int projectId, int fileId, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return GetAsync<ParatranzFile>(url, token);
        }

        public Task<ParatranzFile?> UpdateFileAsync(int projectId, int fileId, byte[] bytes, CancellationToken token = default)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);
            var file = Convert.ToBase64String(bytes);

            return PostAsync<string, ParatranzFile>(url, file, token);
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