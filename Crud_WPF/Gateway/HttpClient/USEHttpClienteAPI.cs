using Crud_WPF.DTO.Generico;
using Crud_WPF.Util;
using DS.USE.Gateway.HttpClientBase.Classes.RetornosRequisicoesAPI;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Crud_WPF.Gateway.HttpClientBase
{
    public class USEHttpClienteAPI
    {
        private static Lazy<USEHttpClienteAPI> _Lazy = new Lazy<USEHttpClienteAPI>(() => new USEHttpClienteAPI());
        private readonly HttpClient _HttpClient;

        public static USEHttpClienteAPI Current { get => _Lazy.Value; }

        private USEHttpClienteAPI()
        {
            if (String.IsNullOrEmpty(ConfiguracoesServico.CaminhoServico) || String.IsNullOrWhiteSpace(ConfiguracoesServico.CaminhoServico))
                throw new Exception("Caminho do serviço não informado.");

            _HttpClient = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 5, 0, 0),
                BaseAddress = new Uri($"{ConfiguracoesServico.CaminhoServico}")
            };
        }

        private HttpRequestMessage RetornarInstanciaPorTipoRequisicao<URequisicao>(String enderecoAPI, URequisicao requisicao, HttpMethod tipoRequisicaoHttp) where URequisicao : class
        {
            StringContent contentString = null;

            if (requisicao != null)
            {
                var jsonContent = JsonConvert.SerializeObject(requisicao, Formatting.Indented);
                contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }
            else
            {
                contentString = null;
            }

            return new HttpRequestMessage
            {
                Method = tipoRequisicaoHttp,
                RequestUri = new Uri($"{ConfiguracoesServico.CaminhoServico}{enderecoAPI}"),
                Content = contentString,
            };
        }

        public async Task<RetornoRequisicaoAPIDTO<TRetorno>> EfetuarRequisicaoGetAPI<TRetorno>(String enderecoAPI) where TRetorno : class
        {
            RetornoRequisicaoAPIDTO<TRetorno> retornoRequisicaoAPIDTO = new RetornoRequisicaoAPIDTO<TRetorno>();

            try
            {
                using (var response = await _HttpClient.GetAsync(enderecoAPI))
                {
                    //ValidarTokenExpiradoLancarException(response);
                    string mensagemErrorAPI;
                    if (!response.IsSuccessStatusCode)
                    {
                        var mensagemErro = await response.Content.ReadAsStringAsync();
                        throw new Exception(mensagemErro);
                    }

                    if (response.Content == null)
                        throw new Exception($"Não foram efetuadas respostas na chamada do endereço {enderecoAPI}.");

                    var retornoAPI = await response.Content.ReadAsStringAsync();
                    retornoRequisicaoAPIDTO.retornoRequisicoAPI = JsonConvert.DeserializeObject<TRetorno>(retornoAPI);

                    var retornoDTO = new RespostaDTO();
                    try
                    {
                        retornoDTO = JsonConvert.DeserializeObject<RespostaDTO>(retornoAPI);
                    }
                    catch (Exception ex)
                    {
                        retornoDTO.Mensagem = ex.Message;
                    }


                    if (retornoRequisicaoAPIDTO.retornoRequisicoAPI == null)
                        mensagemErrorAPI = retornoAPI;
                    else
                        mensagemErrorAPI = retornoDTO.Mensagem;

                    retornoRequisicaoAPIDTO.retornoRequisicaoSucesso = true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return await EfetuarRequisicaoGetAPI<TRetorno>(enderecoAPI);
            }
            catch (Exception ex)
            {
                retornoRequisicaoAPIDTO.retornoRequisicaoSucesso = false;
                retornoRequisicaoAPIDTO.MensagemErro = ex.Message;
            }

            return retornoRequisicaoAPIDTO;
        }

        public async Task<RetornoRequisicaoAPIDTO<TRetorno>> EfetuarRequisicaoAPI<URequisicao, TRetorno>(String enderecoAPI, URequisicao requisicao, HttpMethod tipoRequisicaoHttp)
            where URequisicao : class
            where TRetorno : class
        {
            RetornoRequisicaoAPIDTO<TRetorno> retornoRequisicaoAPIDTO = new RetornoRequisicaoAPIDTO<TRetorno>();

            try
            {
                HttpRequestMessage request = RetornarInstanciaPorTipoRequisicao(enderecoAPI, requisicao, tipoRequisicaoHttp);

                using (var response = await _HttpClient.SendAsync(request))
                {
                   // ValidarTokenExpiradoLancarException(response);
                    var retornoAPI = await response.Content.ReadAsStringAsync();
                    string mensagemErrorAPI;
                    try
                    {
                        retornoRequisicaoAPIDTO.retornoRequisicoAPI = JsonConvert.DeserializeObject<TRetorno>(retornoAPI);


                        RespostaDTO retornoDTO;
                        try
                        {
                            retornoDTO = JsonConvert.DeserializeObject<RespostaDTO>(retornoAPI);
                        }
                        catch (Exception)
                        {
                            retornoDTO = null;
                        }

                        if (retornoRequisicaoAPIDTO.retornoRequisicoAPI == null)
                            mensagemErrorAPI = retornoAPI;
                        else if (retornoDTO != null)
                            mensagemErrorAPI = retornoDTO.Mensagem;
                    }
                    catch (Exception)
                    {
                                throw new Exception($"Erro ao efetuar a chamada da api. ({response.ReasonPhrase}) \nDescrição: {retornoAPI}");
                    }

                    retornoRequisicaoAPIDTO.retornoRequisicaoSucesso = true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return await EfetuarRequisicaoAPI<URequisicao, TRetorno>(enderecoAPI, requisicao, tipoRequisicaoHttp);
            }
            catch (Exception ex)
            {
                retornoRequisicaoAPIDTO.retornoRequisicaoSucesso = false;
                retornoRequisicaoAPIDTO.MensagemErro = ex.Message;
            }

            return retornoRequisicaoAPIDTO;
        }

    }
}
