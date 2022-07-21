using Crud_WPF.Gateway.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Crud_WPF.Forms
{
    public partial class FormPrincipal : Form
    {
        public readonly ClienteGateway _clienteGateway = new ClienteGateway();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private async void listaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _clienteGateway.ComsumirClientes();
              
            ListarCliente form = new ListarCliente();
            form.ShowDialog();
        }
        private void incluirClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarCliente form = new CadastrarCliente();
            form.ShowDialog();
        }
        private void relatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioCliente form = new RelatorioCliente();
            form.ShowDialog();
        }
        private async void importarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_importarClientes.ShowDialog() != DialogResult.Cancel)
                {
                    if (btn_importarClientes.FileNames != null)
                    {

                        var arquivo = btn_importarClientes.FileName;
                        byte[] arquiboByte = Encoding.ASCII.GetBytes(arquivo);
                        var resultConvesao = Convert.ToBase64String(arquiboByte);

                        if(await _clienteGateway.ImportarClientes(resultConvesao))
                            MessageBox.Show("Clientes adicionados a fila de importação!");
                        else
                            MessageBox.Show("Erro ao adicionar clientes a fila de importação!");
                    }
                }

                else
                {
                    MessageBox.Show("Selecione pelo menos um arquivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema ao selecionar arquivos" + ex.Message);
                throw;
            }
        }
    }
}
