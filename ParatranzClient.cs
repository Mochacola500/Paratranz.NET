using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        readonly HttpClient m_Client;

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

        public ParatranzClient(string apiToken)
        {
            m_Client = new HttpClient();
            m_Client.BaseAddress = new Uri("https://paratranz.cn/api/");
            m_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiToken);
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

        protected async Task<Stream?> DownloadAsync(Url relativeUrl, CancellationToken token)
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

        public void Dispose()
        {
            m_Client.Dispose();
        }
    }
}