using System.Data;
using System.Text;
using System.Threading.Tasks;
using Crud_WPF.Interfaces;
using Crud_WPF.Repository.Interfaces;
using Crud_WPF.DTO.Cliente;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Crud_WPF.Util;

namespace Crud_WPF.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly StringBuilder _sql;
        private readonly StringBuilder _sqlParametros;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteRepository(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;

            _sql = new StringBuilder();
            _sql.Append(@"
                SELECT  C.*
                FROM    CLIENTES C WITH (NOLOCK)
            ");

            _sqlParametros = new StringBuilder();
            _sqlParametros.Append(@"
                WHERE 1 = 1
            ");
        }

        public async Task<List<ClienteDTO>> ObterTodos(ClienteFiltroDTO filtros)
        {
            DynamicParameters parameters = new DynamicParameters();


            if (!string.IsNullOrEmpty(filtros.Nome))
            {
                parameters.Add("@Nome", filtros.Nome, DbType.String);
                _sqlParametros.AppendLine(@" AND C.Nome LIKE CONCAT('%', @Nome, '%') ");
            }

            if (!string.IsNullOrEmpty(filtros.Cpf))
            {
                parameters.Add("@Cpf", filtros.Cpf, DbType.String);
                _sqlParametros.AppendLine(@" AND  C.Cpf LIKE CONCAT('%', @Cpf, '%') ");
            }

            if (filtros.Sexo != '\0')
            {
                parameters.Add("@Sexo", filtros.Sexo, DbType.String);
                _sqlParametros.AppendLine(@" AND C.Sexo = @Sexo");
            }

            if (filtros.Aniversario.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                parameters.Add("@Aniversario", filtros.Aniversario.ToString("yyyy-MM-dd"), DbType.String);
                _sqlParametros.AppendLine(@" AND C.Aniversario = @Aniversario");
            }

            _sql.Append(_sqlParametros.ToString());
            var resposta = await _unitOfWork.Connection.QueryAsync<ClienteDTO>(_sql.ToString(), parameters);
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            clientes.AddRange(resposta);
            return clientes;
        }
        public async Task<ClienteDTO> ObterPorId(int id)
        {
            if (id <= 0)
                return null;

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);
            _sqlParametros.AppendLine(@" AND C.Id = @Id ");
            _sql.AppendLine(_sqlParametros.ToString());

            var resposta = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ClienteDTO>(_sql.ToString(), parameters);

            return resposta;
        }
        public async Task<ClienteDTO> ObterPorCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return null;

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Cpf", cpf, DbType.String);
            _sqlParametros.AppendLine(@" AND C.Cpf = @cpf ");

            _sql.AppendLine(_sqlParametros.ToString());

            var resposta = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ClienteDTO>(_sql.ToString(), parameters);
            return resposta;
        }
        public async Task<ClienteDTO> IncluirDTOAsync(ClienteDTO cliente)
        {
            try
            {
                var retorno = await _unitOfWork.Connection.InsertAsync(cliente, _unitOfWork.Transaction);
                cliente.Retorno = (int)EnumRetorno.Enum.Sucesso;
                return cliente;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(message: "Erro ao incluir cliente" + ex);
            }
        }
        public async Task ImportarClientes(List<ClienteDTO> clientes)
        {
            try
            {
                foreach (var cliente in clientes)
                {
                    var retorno = await _unitOfWork.Connection.InsertAsync(cliente, _unitOfWork.Transaction);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(message: "Erro ao incluir cliente" + ex);
            }
        }
        public async Task<ClienteDTO> AlterarDTOAsync(ClienteDTO cliente)
        {
            try
            {
                await _unitOfWork.Connection.UpdateAsync(cliente, _unitOfWork.Transaction);
                cliente.Retorno = (int)EnumRetorno.Enum.Sucesso;
                return cliente;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(message: "Erro ao atualizar cliente" + ex);
            }
        }
        public async Task<ClienteDTO> RemoverDTOAsync(ClienteDTO cliente)
        {
            try
            {
                await _unitOfWork.Connection.DeleteAsync(cliente, _unitOfWork.Transaction);
                cliente.Retorno = (int)EnumRetorno.Enum.Sucesso;
                return cliente;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(message: "Erro ao excluir cliente" + ex);
            }
        }
    }
}
