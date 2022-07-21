namespace Crud_WPF.Forms
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.listaClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incluirClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_importarClientes = new System.Windows.Forms.OpenFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaClientesToolStripMenuItem,
            this.incluirClientesToolStripMenuItem,
            this.relatoriosToolStripMenuItem,
            this.importarClientesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(587, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // listaClientesToolStripMenuItem
            // 
            this.listaClientesToolStripMenuItem.Name = "listaClientesToolStripMenuItem";
            this.listaClientesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.listaClientesToolStripMenuItem.Text = "Listar Clientes";
            this.listaClientesToolStripMenuItem.Click += new System.EventHandler(this.listaClientesToolStripMenuItem_Click);
            // 
            // incluirClientesToolStripMenuItem
            // 
            this.incluirClientesToolStripMenuItem.Name = "incluirClientesToolStripMenuItem";
            this.incluirClientesToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.incluirClientesToolStripMenuItem.Text = "Incluir Clientes";
            this.incluirClientesToolStripMenuItem.Click += new System.EventHandler(this.incluirClientesToolStripMenuItem_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.relatoriosToolStripMenuItem.Text = "Relatorio";
            this.relatoriosToolStripMenuItem.Click += new System.EventHandler(this.relatoriosToolStripMenuItem_Click);
            // 
            // importarClientesToolStripMenuItem
            // 
            this.importarClientesToolStripMenuItem.Name = "importarClientesToolStripMenuItem";
            this.importarClientesToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.importarClientesToolStripMenuItem.Text = "Importar Clientes";
            this.importarClientesToolStripMenuItem.Click += new System.EventHandler(this.importarClientesToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.BackgroundImage = global::Crud_WPF.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(587, 411);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Inicial";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem listaClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incluirClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarClientesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog btn_importarClientes;
    }
}
