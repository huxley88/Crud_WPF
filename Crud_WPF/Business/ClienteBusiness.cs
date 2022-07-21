using ClosedXML.Excel;
using Crud_WPF.Business.Interfaces;
using Crud_WPF.DTO.Cliente;
using Crud_WPF.RabbitMQConsumer;
using Crud_WPF.RabbitMQSender;
using Crud_WPF.Repository.Interfaces;
using Crud_WPF.Util;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsExcel = Microsoft.Office.Interop.Excel;

namespace Crud_WPF.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private static string _diretorioAtual = Directory.GetCurrentDirectory();
        private readonly IClienteRepository _clienteRepository;
        private readonly IRabbitMQSender _rabbitMQSender;
        private readonly IRabbitMQConsumer _rabbitMQConsumer;

        public ClienteBusiness(IClienteRepository clienteRepository, IRabbitMQSender rabbitMQSender, IRabbitMQConsumer rabbitMQConsumer)
        {
            _rabbitMQSender = rabbitMQSender;
            _rabbitMQConsumer = rabbitMQConsumer;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteDTO>> ObterTodos(ClienteFiltroDTO filtros)
        {
            return await _clienteRepository.ObterTodos(filtros);
        }
        public async Task<ClienteDTO> ObterPorId(int id)
        {
            return await _clienteRepository.ObterPorId(id);
        }
        public async Task<ClienteDTO> ObterPorCpf(string cpf)
        {
            return await _clienteRepository.ObterPorCpf(cpf);
        }
        public async Task<ClienteDTO> Incluir(ClienteDTO clienteDTO)
        {
            try
            {
                var clienteExiste = await ObterPorCpf(clienteDTO.Cpf);
                if (clienteExiste != null)
                {
                    clienteExiste.Retorno = (int)EnumRetorno.Enum.JaExiste;
                    return clienteExiste;
                }

                clienteDTO.DataInclusao = DateTime.Now;
                clienteDTO.DataAlteracao = DateTime.Now;

                var clienteTratado = await TratarCliente(clienteDTO);

                return await _clienteRepository.IncluirDTOAsync(clienteTratado);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        public async Task<List<ClienteDTO>> GerarExcel(List<ClienteDTO> clientesDTO)
        {
            return await CriarExcel(clientesDTO);
        }
        public async Task<bool> ImportarClientes(string arquivo)
        {
            try
            {
                var listaCliente = await LerCSV<ClienteDTO>(arquivo);

                foreach (var item in listaCliente.Where(w => w.DataInclusao.ToString("dd/MM/yyyy") == "01/01/0001" &&
                                                             w.DataInclusao.ToString("dd/MM/yyyy") == "01/01/0001"))
                {
                    item.DataInclusao = DateTime.Now;
                    item.DataAlteracao = DateTime.Now;
                }

                _rabbitMQSender.EnviarClienteFila(listaCliente, "clientesQueue");

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> ConsumirClientes()
        {
            try
            {
                await _rabbitMQConsumer.ConsumirClienteFila();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            try
            {
                var clienteExiste = await ObterPorId(clienteDTO.Id);
                if (clienteExiste != null)
                {
                    clienteDTO.DataAlteracao = DateTime.Now;
                    var clienteTratado = await TratarCliente(clienteDTO);

                    return await _clienteRepository.AlterarDTOAsync(clienteTratado);
                }
                else
                {
                    ClienteDTO clienteNaoEncontrado = new ClienteDTO() { Retorno = (int)EnumRetorno.Enum.NaoEncontrado };
                    return clienteNaoEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        public async Task<ClienteDTO> Remover(ClienteDTO clienteDTO)
        {
            try
            {
                var clienteExiste = await ObterPorId(clienteDTO.Id);
                if (clienteExiste != null)
                    return await _clienteRepository.RemoverDTOAsync(clienteDTO);
                else
                {
                    ClienteDTO clienteNaoEncontrado = new ClienteDTO() { Retorno = (int)EnumRetorno.Enum.NaoEncontrado };
                    return clienteNaoEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        public async Task<ClienteDTO> TratarCliente(ClienteDTO cliente)
        {
            try
            {
                cliente.Cpf = cliente.Cpf.Replace(".", "").Replace("-", "");
                cliente.Telefone = cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "");
                cliente.Cep = cliente.Cpf.Replace("-", "");
                return cliente;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        private async Task<List<TRetorno>> LerCSV<TRetorno>(string caminho) where TRetorno : class
        {
            try
            {
                byte[] dadosAsBytes = Convert.FromBase64String(caminho);
                string resultado = ASCIIEncoding.ASCII.GetString(dadosAsBytes);

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ";",
                    Encoding = Encoding.UTF8,
                };

                using (var reader = new StreamReader(resultado))
                using (var csv = new CsvReader(reader, config))
                    return csv.GetRecords<TRetorno>().ToList();

            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        private async Task<List<ClienteDTO>> CriarExcel(List<ClienteDTO> clientes)
        {
            try
            {


                var workbook = new XLWorkbook();
                workbook.AddWorksheet("Clientes");
                var ws = workbook.Worksheet("Clientes");

                ws.Cell("A" + 1).Value = "ID";
                ws.Cell("B" + 1).Value = "NOME";
                ws.Cell("C" + 1).Value = "TELEFONE";
                ws.Cell("D" + 1).Value = "SEXO";
                ws.Cell("E" + 1).Value = "CPF";
                ws.Cell("F" + 1).Value = "ANIVERSARIO";
                ws.Cell("G" + 1).Value = "PAIS";
                ws.Cell("H" + 1).Value = "CEP";
                ws.Cell("I" + 1).Value = "CIDADE";
                ws.Cell("J" + 1).Value = "BAIRRO";
                ws.Cell("K" + 1).Value = "RUA";
                ws.Cell("L" + 1).Value = "NUMERO";
                ws.Cell("M" + 1).Value = "DATA ALTERACAO";

                int row = 2;
                foreach (var c in clientes)
                {
                    ws.Cell("A" + row.ToString()).Value = c.Id;
                    ws.Cell("B" + row.ToString()).Value = c.Nome;
                    ws.Cell("C" + row.ToString()).Value = c.Telefone;
                    ws.Cell("D" + row.ToString()).Value = c.Sexo;
                    ws.Cell("E" + row.ToString()).Value = c.Cpf;
                    ws.Cell("F" + row.ToString()).Value = c.Aniversario;
                    ws.Cell("G" + row.ToString()).Value = c.Pais;
                    ws.Cell("H" + row.ToString()).Value = c.Cep;
                    ws.Cell("I" + row.ToString()).Value = c.Cidade;
                    ws.Cell("J" + row.ToString()).Value = c.Bairro;
                    ws.Cell("K" + row.ToString()).Value = c.Rua;
                    ws.Cell("L" + row.ToString()).Value = c.Numero;
                    ws.Cell("M" + row.ToString()).Value = c.DataAlteracao;
                    row++;

                }

                workbook.SaveAs($"{_diretorioAtual}\\Clientes.xlsx");

                FileInfo file = new FileInfo($"{_diretorioAtual}\\Clientes.xlsx");

                if (file.Exists)
                {
                    var p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo($"{_diretorioAtual}\\Clientes.xlsx")
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

    }

}
