using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Paratranz.NET
{
    public class ParatranzClient : IDisposable
    {
        readonly JsonSerializerOptions WebJsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        readonly Uri ParatranzUri = new Uri("https://paratranz.cn/api/");
        readonly HttpClient Client;
        bool Disposed;

        public ParatranzClient(string apiToken)
            : this(apiToken, new HttpClientHandler())
        {

        }

        public ParatranzClient(string apiToken, HttpClientHandler httpClientHandler)
            : this(apiToken, httpClientHandler, true)
        {

        }

        public ParatranzClient(string apiToken, HttpClientHandler httpClientHandler, bool disposeHandler)
        {
            Client = new HttpClient(httpClientHandler, disposeHandler);
            Client.BaseAddress = ParatranzUri;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiToken);
        }

        #region IDisposable Implement

        ~ParatranzClient()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !Disposed)
            {
                Disposed = true;
                Client.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion // IDisposable Implement

        public async Task<TResponse?> GetAsync<TResponse>(string relativeUri, CancellationToken token)
        {
            var res = await Client.GetAsync(relativeUri, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TResponse>(WebJsonSerializerOptions, token);
        }

        public async Task<TResponse?> PostAsync<TBody, TResponse>(string relativeUri, TBody? body, CancellationToken token)
        {
            var res = await Client.PostAsJsonAsync(relativeUri, body, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TResponse>(WebJsonSerializerOptions, token);
        }

        public async Task<TResponse?> PutAsync<TBody, TResponse>(string relativeUri, TBody body, CancellationToken token)
        {
            var res = await Client.PutAsJsonAsync(relativeUri, body, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<TResponse>(WebJsonSerializerOptions, token);
        }

        public async Task<Stream> DownloadAsync(string relativeUri, CancellationToken token)
        {
            var res = await Client.GetAsync(relativeUri, HttpCompletionOption.ResponseHeadersRead, token);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsStreamAsync(token);
        }

        public async Task<bool> DeleteAsync(string relativeUri, CancellationToken token)
        {
            var res = await Client.DeleteAsync(relativeUri, token);
            res.EnsureSuccessStatusCode();

            return res.StatusCode == HttpStatusCode.OK;
        }
    }
}