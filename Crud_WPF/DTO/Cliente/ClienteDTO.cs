using Crud_WPF.DTO.Validacaoes;
using Crud_WPF.Util;
using CsvHelper.Configuration.Attributes;
using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel;

namespace Crud_WPF.DTO.Cliente
{
    [Table("Clientes")]
    public sealed class ClienteDTO
    {
        #region Propriedades
        [Key]
        [Ignore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public char Sexo { get; set; }
        public string Cpf { get; set; }
        public DateTime Aniversario { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        [Browsable(false)]
        [Ignore]
        public DateTime DataInclusao { get; set; }
        [Browsable(false)]
        [Ignore]
        public DateTime DataAlteracao { get; set; }

        //Sucesso = 1,
        //JaExiste = 2,
        //NaoEncontrado = 3,
        //Erro = 4
        [Computed]
        [Browsable(false)]
        [Ignore]
        public int Retorno { get; set; }
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
