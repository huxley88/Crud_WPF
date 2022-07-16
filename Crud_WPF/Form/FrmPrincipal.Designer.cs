
namespace Crud_WPF
{
    partial class FrmPrincipal
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
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.nome = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cpf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sexo = new System.Windows.Forms.Label();
            this.cbx_sexo = new System.Windows.Forms.ComboBox();
            this.aniversario = new System.Windows.Forms.TextBox();
            this.lb_aniversario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Location = new System.Drawing.Point(570, 372);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(110, 51);
            this.btn_Salvar.TabIndex = 0;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(42, 372);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(109, 51);
            this.btn_Sair.TabIndex = 1;
            this.btn_Sair.Text = "Sair";
            this.btn_Sair.UseVisualStyleBackColor = true;
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Location = new System.Drawing.Point(24, 32);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(45, 17);
            this.nome.TabIndex = 2;
            this.nome.Text = "Nome";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(419, 22);
            this.textBox1.TabIndex = 3;
            // 
            // cpf
            // 
            this.cpf.Location = new System.Drawing.Point(501, 56);
            this.cpf.Name = "cpf";
            this.cpf.Size = new System.Drawing.Size(179, 22);
            this.cpf.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "CPF";
            // 
            // sexo
            // 
            this.sexo.AutoSize = true;
            this.sexo.Location = new System.Drawing.Point(24, 114);
            this.sexo.Name = "sexo";
            this.sexo.Size = new System.Drawing.Size(49, 21);
            this.sexo.TabIndex = 6;
            this.sexo.Text = "Sexo";
            // 
            // cbx_sexo
            // 
            this.cbx_sexo.FormattingEnabled = true;
            this.cbx_sexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbx_sexo.Location = new System.Drawing.Point(27, 138);
            this.cbx_sexo.Name = "cbx_sexo";
            this.cbx_sexo.Size = new System.Drawing.Size(121, 24);
            this.cbx_sexo.TabIndex = 7;
            // 
            // aniversario
            // 
            this.aniversario.Location = new System.Drawing.Point(210, 138);
            this.aniversario.Name = "aniversario";
            this.aniversario.Size = new System.Drawing.Size(179, 22);
            this.aniversario.TabIndex = 9;
            // 
            // lb_aniversario
            // 
            this.lb_aniversario.AutoSize = true;
            this.lb_aniversario.Location = new System.Drawing.Point(207, 114);
            this.lb_aniversario.Name = "lb_aniversario";
            this.lb_aniversario.Size = new System.Drawing.Size(99, 21);
            this.lb_aniversario.TabIndex = 8;
            this.lb_aniversario.Text = "Aniversario";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 469);
            this.Controls.Add(this.aniversario);
            this.Controls.Add(this.lb_aniversario);
            this.Controls.Add(this.cbx_sexo);
            this.Controls.Add(this.sexo);
            this.Controls.Add(this.cpf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Salvar);
            this.Name = "FrmPrincipal";
            this.Text = "Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox cpf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sexo;
        private System.Windows.Forms.ComboBox cbx_sexo;
        private System.Windows.Forms.TextBox aniversario;
        private System.Windows.Forms.Label lb_aniversario;
    }
}

