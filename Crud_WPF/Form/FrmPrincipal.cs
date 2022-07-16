using Crud_WPF.DTO.Cliente;
using Crud_WPF.Gateway.Classes;
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
    public partial class FrmPrincipal : Form
    {
        public readonly ClienteGateway _ClienteGateway = new ClienteGateway();
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private async void btn_Salvar_Click(object sender, EventArgs e)
        {
            nome.Text = "Huxley";
            cpf.Text = "11880842670";
            cbx_sexo.SelectedItem = "M";
            aniversario.Text = "09/01/1997";

            var cliente = new ClienteDTO() {

                Nome = nome.Text,
                Cpf = cpf.Text,
                Sexo = Convert.ToChar(cbx_sexo.SelectedItem),
                Aniversario = Convert.ToDateTime(aniversario.Text)
            };

            var retorno = await _ClienteGateway.Incluir(cliente);
        }
    }
}
