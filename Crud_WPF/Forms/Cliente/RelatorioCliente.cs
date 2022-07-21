using Crud_WPF.DTO.Cliente;
using Crud_WPF.Gateway.Classes;
using Crud_WPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_WPF.Forms
{
    public partial class RelatorioCliente : Form
    {
        public readonly ClienteGateway _clienteGateway = new ClienteGateway();
        private static List<ClienteDTO> clientesView = new List<ClienteDTO>();

        public RelatorioCliente()
        {
            InitializeComponent();
        }

        private async void ListarCliente_Load(object sender, EventArgs e)
        {
            await ListarClientes();
        }
        private async Task ListarClientes()
        {
            clientesView = await _clienteGateway.ObterTodos(new ClienteFiltroDTO());

            if (clientesView.Any())
                grd_RelatorioClientes.DataSource = clientesView;
            else
                MessageBox.Show("Nenhum cliente encontrado!");
        }
        private async void filtroNome_TextChanged(object sender, EventArgs e)
        {
            await Filtrar();
        }
        private async void filtroCpf_TextChanged(object sender, EventArgs e)
        {
            await Filtrar();
        }
        private async void cbx_filtroSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
           await Filtrar();
        }
        private async Task Filtrar()
        {
            ClienteFiltroDTO clienteFiltro = new ClienteFiltroDTO();

            if (cbx_filtroSexo.SelectedItem != null)
            {
                clienteFiltro.Sexo = Convert.ToChar(cbx_filtroSexo.SelectedItem);
            }

            if (!string.IsNullOrEmpty(filtroCpf.Text))
            {
                var cpf = filtroCpf.Text.Replace(".", "").Replace("-", "").Replace(" ", "");
                clienteFiltro.Cpf = cpf;
            }

            if (!string.IsNullOrEmpty(filtroNome.Text))
            {
                clienteFiltro.Nome = filtroNome.Text;
            }

            clientesView = await _clienteGateway.ObterTodos(clienteFiltro);
            grd_RelatorioClientes.DataSource = clientesView;
        }
        private async void btn_excel_Click(object sender, EventArgs e)
        {
            await GerarExcel();
        }
        private async Task GerarExcel()
        {
            await _clienteGateway.GerarExcel(clientesView);
        }
    }
}
