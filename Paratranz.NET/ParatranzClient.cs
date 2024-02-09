using System.Text.Json.Nodes;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using Flurl;

namespace Paratranz.NET
{
    public class ParatranzClient : IDisposable
    {
        #region Implement

        readonly HttpClient m_Client;
        bool m_Disposed;

        public TimeSpan TimeOut
        {
            get => m_Client.Timeout;
            set => m_Client.Timeout = value;
        }

        public long MaxResponseContentBufferSize
        {
            get => m_Client.MaxResponseContentBufferSize;
            set => m_Client.MaxResponseContentBufferSize = value;
        }

        public ParatranzClient(string apiToken) : this(apiToken, null)
        {

        }

        public ParatranzClient(string apiToken, string? ssl)
        {
            var handler = new HttpClientHandler();
            if (ssl != null)
            {
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.SslProtocols = SslProtocols.Tls12;
                handler.ClientCertificates.Add(new X509Certificate(ssl));
            }

            m_Client = new HttpClient(handler);
            m_Client.BaseAddress = new Uri("https://paratranz.cn/api/");
            m_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiToken);
        }

        ~ParatranzClient()
        {
            Dispose(false);
        }

        public void CancelPendingRequests()
        {
            m_Client.CancelPendingRequests();
        }

        protected async Task<TReturn?> GetAsync<TReturn>(Url relativeUrl, CancellationToken token)
        {
            var res = await m_Client.GetAsync(relativeUrl, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TReturn>(options: null, token);
        }

        public async Task<TReturn?> PostAsync<TReturn>(Url relativeUrl, HttpContent? content, CancellationToken token)
        {
            var res = await m_Client.PostAsync(relativeUrl, content, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TReturn>(options: null, token);
        }

        protected async Task<TReturn?> PostAsync<TBody, TReturn>(Url relativeUrl, TBody? body, CancellationToken token)
        {
            var res = await m_Client.PostAsJsonAsync(relativeUrl, body, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TReturn>(options: null, token);
        }

        protected async Task<TReturn?> PutAsync<TBody, TReturn>(Url relativeUrl, TBody body, CancellationToken token)
        {
            var res = await m_Client.PutAsJsonAsync(relativeUrl, body, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TReturn>(options: null, token);
        }

        protected async Task<Stream> DownloadAsync(Url relativeUrl, CancellationToken token)
        {
            var res = await m_Client.GetAsync(relativeUrl, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsStreamAsync(token);
        }

        protected async Task<bool> DeleteAsync(Url relativeUrl, CancellationToken token)
        {
            var res = await m_Client.DeleteAsync(relativeUrl, token);
            res.EnsureSuccessStatusCode();

            return res.StatusCode == HttpStatusCode.OK;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !m_Disposed)
            {
                m_Disposed = true;
                m_Client.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion // Implement

        #region Artifact

        public Task<ParatranzArtifact?> GetArtifactAsync(int projectId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts");

            return GetAsync<ParatranzArtifact>(url, token);
        }

        public Task<ParatranzBuildInfo?> BuildArtifactAsync(int projectId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts");

            return PostAsync<object, ParatranzBuildInfo>(url, new object(), token);
        }

        public Task<Stream> DownloadArtifactAsync(int projectId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "artifacts", "download");

            return DownloadAsync(url, token);
        }

        #endregion // Artifact

        #region File

        public Task<ParatranzFile?> GetFileAsync(int projectId, int fileId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return GetAsync<ParatranzFile>(url, token);
        }

        public Task<ParatranzFile?> AddFileAsync(int projectId, string fileName, byte[] bytes, string path, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(bytes), "file", fileName },
                { new StringContent(path), "path" }
            };

            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile?> UpdateFileAsync(int projectId, int fileId, string fileName, byte[] bytes, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(bytes), "file", fileName }
            };
            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile?> AddFileAsync(int projectId, string file, string path, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var bytes = File.ReadAllBytes(file);
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(bytes), "file", Path.GetFileName(file) },
                { new StringContent(path), "path" }
            };

            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile?> UpdateFileAsync(int projectId, int fileId, string file, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);
            var bytes = File.ReadAllBytes(file);
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(bytes), "file", Path.GetFileName(file) }
            };
            return PostAsync<ParatranzFile>(url, content, token);
        }

        public Task<ParatranzFile[]?> GetFilesAsync(int projectId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files");

            return GetAsync<ParatranzFile[]>(url, token);
        }

        public Task<ParatranzFileInfo?> GetFilePageAsync(int projectId, string file, string path, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files");
            var json = new JsonObject
            {
                ["file"] = file,
                ["path"] = path,
            };

            return PostAsync<JsonObject, ParatranzFileInfo>(url, json, token);
        }

        public Task<bool> DeleteFileAsync(int projectId, int fileId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId);

            return DeleteAsync(url, token);
        }

        public Task<Stream> DownloadFileAsync(int projectId, int fileId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "files", fileId, "translation");

            return DownloadAsync(url, token);
        }

        #endregion // File

        #region History

        public Task<ParatranzPage<ParatranzHistory>?> GetUserHistoryAsync(int project, TranslateHistory type, int uid, int tid, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                project,
                uid,
                tid,
                type = type.ToString(),
                page,
                pageSize
            };
            var url = "history".SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzHistory>>(url, token);
        }

        public Task<ParatranzHistory?> GeFiletHistoryAsync(int projectId, int file, FileHistory type, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                file,
                type = type.ToString(),
                page,
                pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "files", "revisions")
                .SetQueryParams(query);

            return GetAsync<ParatranzHistory>(url, token);
        }

        #endregion // History

        #region Issue

        public Task<ParatranzPage<ParatranzIssue>?> GetIssuePageAsync(int projectId, IssuesStatus status, CancellationToken token)
        {
            var query = new
            {
                status,
            };
            var url = "projects"
                .AppendPathSegments(projectId, "issues")
                .SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzIssue>>(url, token);
        }

        public Task<ParatranzIssue?> CreateIssueAsync(int projectId, string title, string content, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "issues");
            var json = new JsonObject
            {
                ["title"] = title,
                ["content"] = content
            };

            return PostAsync<JsonObject, ParatranzIssue>(url, json, token);
        }

        public Task<ParatranzIssue?> UpdateIssueAsync(int projectId, string issueId, string title, string content, IssuesStatus status, CancellationToken token)
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

        public Task<bool> DeleteIssueAsync(int projectId, int issueId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "issues", issueId);

            return DeleteAsync(url, token);
        }

        #endregion // Issue

        #region Mail

        public Task<ParatranzPage<ParatranzMail>?> GetMailPageAsync(int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                page,
                pageSize
            };
            var url = "mails".SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzMail>>(url, token);
        }

        public Task<ParatranzMail[]?> GetMailsAsync(int userId, CancellationToken token)
        {
            var url = "mails".AppendPathSegments("conversations", userId);

            return GetAsync<ParatranzMail[]>(url, token);
        }

        #endregion // Mail

        #region Project

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

        #endregion // Project

        #region Users

        public Task<ParatranzUser?> GetUserAsync(int userId, CancellationToken token)
        {
            var url = "users".AppendPathSegments(userId);

            return GetAsync<ParatranzUser>(url, token);
        }

        public Task<ParatranzUser?> UpdateUserAsync(int userId, string nickname, string bio, string avatar, CancellationToken token)
        {
            var url = "users".AppendPathSegments(userId);
            var json = new JsonObject
            {
                ["nickname"] = nickname,
                ["bio"] = bio,
                ["avatar"] = avatar,
            };

            return PutAsync<JsonObject, ParatranzUser>(url, json, token);
        }

        #endregion // Users

        #region String

        public Task<ParatranzString?> UpdateStringAsync(int projectId, int stringId, ParatranzStringRequest body, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            return PutAsync<ParatranzStringRequest, ParatranzString>(url, body, token);
        }

        public Task<bool> DeleteStringAsync(int projectId, int stringId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            return DeleteAsync(url, token);
        }

        public Task<ParatranzString?> GetStringAsync(int projectId, int stringId, CancellationToken token)
        {
            var url = "projects".AppendPathSegments(projectId, "strings", stringId);

            return GetAsync<ParatranzString>(url, token);
        }

        public Task<ParatranzString?> GetStringAsync(int projectId, ParatranzStringRequest body, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                page,
                pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(query);

            return PostAsync<ParatranzStringRequest, ParatranzString>(url, body, token);
        }

        public Task<ParatranzPage<ParatranzString>?> GetStringPageAsync(int projectId, int file, int stage, int page, int pageSize, CancellationToken token)
        {
            var query = new
            {
                file,
                stage,
                page,
                pageSize
            };
            var url = "projects"
                .AppendPathSegments(projectId, "strings")
                .SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzString>>(url, token);
        }

        #endregion // String

        #region Score

        public Task<ParatranzPage<ParatranzScore>?> GetScorePageAsync(int projectId, int uid, ScoreType type, DateTime? start, DateTime? end, int page, int pageSize, CancellationToken token)
        {
            var type_str = type.ToString();
            var query = new
            {
                page,
                pageSize,
                uid,
                operation = type_str,
                start,
                end
            };
            var url = "projects"
                .AppendPathSegments(projectId, "scores")
                .SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzScore>>(url, token);
        }

        #endregion // Score
    }
}