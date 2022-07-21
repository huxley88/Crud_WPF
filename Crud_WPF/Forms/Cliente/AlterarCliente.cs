using Crud_WPF.DTO.Cliente;
using Crud_WPF.Gateway.Classes;
using Crud_WPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_WPF
{
    public partial class AlterarCliente : Form
    {
        public readonly ClienteGateway _clienteGateway = new ClienteGateway();
        public ClienteDTO clienteAlteracao;

        public AlterarCliente()
        {
            InitializeComponent();
        }

        private async void btn_Salvar_Click(object sender, EventArgs e)
        {
            await AlteracaoCliente(clienteAlteracao);
        }
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public async Task AlteracaoCliente(ClienteDTO cliente) 
        {
            var clienteAlterar = new ClienteDTO()
            {
                Id = cliente.Id,
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text,
                Sexo = cbx_sexo.SelectedItem != null ? Convert.ToChar(cbx_sexo.SelectedItem) : '\0',
                Cpf = txtCpf.Text,
                Aniversario = txtAniversario.Text != null ? Convert.ToDateTime(txtAniversario.Text) : DateTime.Now,
                Pais = txtPais.Text,
                Cep = txtCep.Text,
                Cidade = txtCidade.Text,
                Bairro = txtBairro.Text,
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                DataInclusao = cliente.DataInclusao,
                DataAlteracao = DateTime.Now
            };

            var retorno = await _clienteGateway.Alterar(clienteAlterar);

            switch (retorno.Retorno)
            {
                case (int)EnumRetorno.Enum.Sucesso:
                    MessageBox.Show($"Cliente {retorno.Nome} alterado com sucesso!");
                    break;
                case (int)EnumRetorno.Enum.NaoEncontrado:
                    MessageBox.Show($"Cliente {retorno.Nome} não encontrado!");
                    break;
                default:
                    MessageBox.Show($"Erro ao incluir alterar");
                    break;
            }

            this.Close();
        }
    }
}
