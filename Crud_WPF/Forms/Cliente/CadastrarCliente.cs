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
    public partial class CadastrarCliente : Form
    {
        public readonly ClienteGateway _clienteGateway = new ClienteGateway();
        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private async void btn_Salvar_Click(object sender, EventArgs e)
        {
            await IncluirCliente();
        }
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task IncluirCliente()
        {
            if (string.IsNullOrEmpty(Validacoes()))
            {
                try
                {
                    var cliente = new ClienteDTO()
                    {
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
                        DataInclusao = DateTime.Now,
                        DataAlteracao = DateTime.Now
                    };

                    var retorno = await _clienteGateway.Incluir(cliente);

                    switch (retorno.Retorno)
                    {
                        case (int)EnumRetorno.Enum.Sucesso:
                            MessageBox.Show($"Cliente {retorno.Nome} Incluido com sucesso!");
                            break;
                        case (int)EnumRetorno.Enum.JaExiste:
                            MessageBox.Show($"Já existe um cliente cadastrado com esse CPF: {retorno.Cpf}");
                            break;
                        default:
                            MessageBox.Show($"Erro ao incluir cliente");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cincluir Cliente " + ex);
                    throw;
                }
            }
            else
                MessageBox.Show(Validacoes());
        }
        private string Validacoes()
        {
            var cpf = txtCpf.Text.Replace(".", "").Replace("-", "").Replace(" ", "");

            if (string.IsNullOrEmpty(txtNome.Text))
                return "Preencha um nome";
            else if (string.IsNullOrEmpty(cpf))
                return "Preencha um CPF";

            return string.Empty;
        }

    }
}
