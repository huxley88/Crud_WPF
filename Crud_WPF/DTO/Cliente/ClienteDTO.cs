using Crud_WPF.DTO.Validacaoes;
using System;

namespace Crud_WPF.DTO.Cliente
{
    public class ClienteDTO
    {
        #region Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime Aniversario { get; set; }
        #endregion

        #region Validações

        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "Nome não pode ser vazio");
            AssertionConcern.ValidarCPF(Cpf, "CPF Inválido!");
        }

        #endregion
    }
}
