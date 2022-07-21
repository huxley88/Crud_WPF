using System.Windows.Forms;

namespace Crud_WPF.Forms
{
    partial class RelatorioCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioCliente));
            this.grd_RelatorioClientes = new System.Windows.Forms.DataGridView();
            this.filtroNome = new System.Windows.Forms.TextBox();
            this.nomefiltro = new System.Windows.Forms.Label();
            this.filtroCpf = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_filtroSexo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_RelatorioClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_RelatorioClientes
            // 
            this.grd_RelatorioClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_RelatorioClientes.Location = new System.Drawing.Point(1, 66);
            this.grd_RelatorioClientes.Name = "grd_RelatorioClientes";
            this.grd_RelatorioClientes.Size = new System.Drawing.Size(899, 390);
            this.grd_RelatorioClientes.TabIndex = 0;
            // 
            // filtroNome
            // 
            this.filtroNome.Location = new System.Drawing.Point(12, 27);
            this.filtroNome.Name = "filtroNome";
            this.filtroNome.Size = new System.Drawing.Size(509, 20);
            this.filtroNome.TabIndex = 1;
            this.filtroNome.TextChanged += new System.EventHandler(this.filtroNome_TextChanged);
            // 
            // nomefiltro
            // 
            this.nomefiltro.AutoSize = true;
            this.nomefiltro.Location = new System.Drawing.Point(13, 8);
            this.nomefiltro.Name = "nomefiltro";
            this.nomefiltro.Size = new System.Drawing.Size(35, 13);
            this.nomefiltro.TabIndex = 2;
            this.nomefiltro.Text = "Nome";
            // 
            // filtroCpf
            // 
            this.filtroCpf.Culture = new System.Globalization.CultureInfo("");
            this.filtroCpf.Location = new System.Drawing.Point(538, 27);
            this.filtroCpf.Mask = "000.000.000-00";
            this.filtroCpf.Name = "filtroCpf";
            this.filtroCpf.Size = new System.Drawing.Size(94, 20);
            this.filtroCpf.TabIndex = 2;
            this.filtroCpf.TextChanged += new System.EventHandler(this.filtroCpf_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "CPF";
            // 
            // cbx_filtroSexo
            // 
            this.cbx_filtroSexo.FormattingEnabled = true;
            this.cbx_filtroSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbx_filtroSexo.Location = new System.Drawing.Point(650, 26);
            this.cbx_filtroSexo.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_filtroSexo.Name = "cbx_filtroSexo";
            this.cbx_filtroSexo.Size = new System.Drawing.Size(109, 21);
            this.cbx_filtroSexo.TabIndex = 3;
            this.cbx_filtroSexo.SelectedIndexChanged += new System.EventHandler(this.cbx_filtroSexo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sexo";
            // 
            // btn_excel
            // 
            this.btn_excel.Location = new System.Drawing.Point(788, 24);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(88, 24);
            this.btn_excel.TabIndex = 7;
            this.btn_excel.Text = "Excel";
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // RelatorioCliente
            // 
            this.ClientSize = new System.Drawing.Size(899, 456);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.filtroCpf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nomefiltro);
            this.Controls.Add(this.filtroNome);
            this.Controls.Add(this.grd_RelatorioClientes);
            this.Controls.Add(this.cbx_filtroSexo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RelatorioCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ListarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_RelatorioClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd_RelatorioClientes;
        private System.Windows.Forms.TextBox filtroNome;
        private System.Windows.Forms.Label nomefiltro;
        private System.Windows.Forms.MaskedTextBox filtroCpf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_filtroSexo;
        private System.Windows.Forms.Label label1;
        private Button btn_excel;
    }
}
