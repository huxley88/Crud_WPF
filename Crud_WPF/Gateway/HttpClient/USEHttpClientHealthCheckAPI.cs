using Crud_WPF.Util;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Crud_WPF.Gateway.HttpClientBase
{
    public class USEHttpClientHealthCheckAPI
    {
        private static Lazy<USEHttpClientHealthCheckAPI> _Lazy = new Lazy<USEHttpClientHealthCheckAPI>(() => new USEHttpClientHealthCheckAPI());
        private readonly HttpClient _HttpClient;
        private const string RETORNO_HEALTH_CHECK = "on-line";

        public async Task EfetuarRequisicaoGetAPI(string enderecoAPI)
        {
            try
            {
                using (var response = await _HttpClient.GetAsync(enderecoAPI).ConfigureAwait(false))
                {
                    var retornoHealthCheck = await response.Content.ReadAsStringAsync();

                    if (!string.Equals(retornoHealthCheck, RETORNO_HEALTH_CHECK, StringComparison.CurrentCultureIgnoreCase))
                        throw new Exception("Sistema off-line.");

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (UnauthorizedAccessException)
            {
                await EfetuarRequisicaoGetAPI(enderecoAPI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
