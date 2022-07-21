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

namespace Crud_WPF.Forms
{
    public partial class ListarCliente : Form
    {
        public readonly ClienteGateway _clienteGateway = new ClienteGateway();

        public ListarCliente()
        {
            InitializeComponent();
        }

        private async void ListarCliente_Load(object sender, EventArgs e)
        {
            await ListarClientes();
        }
        private async void grd_listarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == grd_listarClientes.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == grd_listarClientes.Columns["Excluir"].Index)
            {
                DataGridViewRow row = grd_listarClientes.Rows[e.RowIndex];
                var cliente = (ClienteDTO)row.DataBoundItem;

                await Exclusao(cliente);
            }

            if (e.ColumnIndex == grd_listarClientes.Columns["Alterar"].Index)
            {
                DataGridViewRow row = grd_listarClientes.Rows[e.RowIndex];
                var cliente = (ClienteDTO)row.DataBoundItem;

                await Altercao(cliente);
            }
        }
        private async Task Exclusao(ClienteDTO cliente)
        {
            var retorno = await _clienteGateway.Remover(cliente);

            switch (retorno.Retorno)
            {
                case (int)EnumRetorno.Enum.Sucesso:
                    MessageBox.Show($"Cliente {retorno.Nome} Excluido com sucesso!");
                    break;
                case (int)EnumRetorno.Enum.NaoEncontrado:
                    MessageBox.Show($"Cliente não encontrado!");
                    break;
                default:
                    MessageBox.Show($"Erro ao excluir cliente");
                    break;
            }

            await ListarClientes();
        }
        private async Task Altercao(ClienteDTO cliente)
        {
            AlterarCliente form = new AlterarCliente();

            form.clienteAlteracao = cliente;

            form.txtNome.Text = cliente.Nome;
            form.txtTelefone.Text = cliente.Telefone;
            form.cbx_sexo.SelectedIndex = cliente.Sexo == 'M' ? 0 : 1;
            form.txtCpf.Text = cliente.Cpf;
            form.txtAniversario.Text = cliente.Aniversario != null ? cliente.Aniversario.ToString("dd/MM/yyyy") : string.Empty;
            form.txtPais.Text = cliente.Pais;
            form.txtCep.Text = cliente.Cep;
            form.txtCidade.Text = cliente.Cidade;
            form.txtBairro.Text = cliente.Bairro;
            form.txtRua.Text = cliente.Rua;
            form.txtNumero.Text = cliente.Numero;

            form.ShowDialog();
           
            await ListarClientes();
        }
        private async Task ListarClientes()
        {
            var clientes = await _clienteGateway.ObterTodos(new ClienteFiltroDTO());

            if (clientes.Any())
                grd_listarClientes.DataSource = clientes;
            else
                MessageBox.Show("Nenhum cliente encontrado!");
        }
    }
}
