namespace CampanhaBD.UI.Windows
{
    partial class FrmImportacao
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
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.txtCaminhoArquivo = new System.Windows.Forms.TextBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.grpAtualizar = new System.Windows.Forms.GroupBox();
            this.chbAtualizar = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ltbBanco = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ltbBase = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMaxDataImportado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMinDataImportado = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTipoEmprestimo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFimDataPagamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInicioDataPagamento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaxParcela = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtMinParcela = new System.Windows.Forms.TextBox();
            this.grpFiltroConfigurado = new System.Windows.Forms.GroupBox();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblErro = new System.Windows.Forms.Label();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnEstimar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtNomeImportacao = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpFiltros.SuspendLayout();
            this.grpAtualizar.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpFiltroConfigurado.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Location = new System.Drawing.Point(13, 57);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(1029, 23);
            this.pgbProgresso.TabIndex = 7;
            // 
            // txtCaminhoArquivo
            // 
            this.txtCaminhoArquivo.Enabled = false;
            this.txtCaminhoArquivo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoArquivo.Location = new System.Drawing.Point(13, 25);
            this.txtCaminhoArquivo.Name = "txtCaminhoArquivo";
            this.txtCaminhoArquivo.Size = new System.Drawing.Size(989, 26);
            this.txtCaminhoArquivo.TabIndex = 70;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.grpAtualizar);
            this.grpFiltros.Controls.Add(this.groupBox7);
            this.grpFiltros.Controls.Add(this.groupBox6);
            this.grpFiltros.Controls.Add(this.groupBox5);
            this.grpFiltros.Controls.Add(this.groupBox3);
            this.grpFiltros.Controls.Add(this.groupBox2);
            this.grpFiltros.Controls.Add(this.groupBox1);
            this.grpFiltros.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(12, 163);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1059, 215);
            this.grpFiltros.TabIndex = 75;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros para Importação";
            // 
            // grpAtualizar
            // 
            this.grpAtualizar.Controls.Add(this.chbAtualizar);
            this.grpAtualizar.Location = new System.Drawing.Point(846, 29);
            this.grpAtualizar.Name = "grpAtualizar";
            this.grpAtualizar.Size = new System.Drawing.Size(196, 171);
            this.grpAtualizar.TabIndex = 48;
            this.grpAtualizar.TabStop = false;
            // 
            // chbAtualizar
            // 
            this.chbAtualizar.AutoSize = true;
            this.chbAtualizar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAtualizar.Location = new System.Drawing.Point(7, 25);
            this.chbAtualizar.Name = "chbAtualizar";
            this.chbAtualizar.Size = new System.Drawing.Size(149, 24);
            this.chbAtualizar.TabIndex = 0;
            this.chbAtualizar.Text = "Importar Atualizando";
            this.chbAtualizar.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ltbBanco);
            this.groupBox7.Location = new System.Drawing.Point(239, 29);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(191, 171);
            this.groupBox7.TabIndex = 50;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Banco Emprestimo";
            // 
            // ltbBanco
            // 
            this.ltbBanco.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbBanco.FormattingEnabled = true;
            this.ltbBanco.ItemHeight = 20;
            this.ltbBanco.Location = new System.Drawing.Point(15, 28);
            this.ltbBanco.Name = "ltbBanco";
            this.ltbBanco.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ltbBanco.Size = new System.Drawing.Size(158, 124);
            this.ltbBanco.TabIndex = 41;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ltbBase);
            this.groupBox6.Location = new System.Drawing.Point(13, 29);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(220, 171);
            this.groupBox6.TabIndex = 49;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Base para Importação";
            // 
            // ltbBase
            // 
            this.ltbBase.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbBase.FormattingEnabled = true;
            this.ltbBase.ItemHeight = 20;
            this.ltbBase.Location = new System.Drawing.Point(13, 28);
            this.ltbBase.Name = "ltbBase";
            this.ltbBase.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ltbBase.Size = new System.Drawing.Size(193, 124);
            this.ltbBase.TabIndex = 41;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMaxDataImportado);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtMinDataImportado);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(641, 114);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 86);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Data Importado";
            // 
            // txtMaxDataImportado
            // 
            this.txtMaxDataImportado.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDataImportado.Location = new System.Drawing.Point(102, 44);
            this.txtMaxDataImportado.Name = "txtMaxDataImportado";
            this.txtMaxDataImportado.Size = new System.Drawing.Size(87, 26);
            this.txtMaxDataImportado.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(99, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Máximo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Mínimo";
            // 
            // txtMinDataImportado
            // 
            this.txtMinDataImportado.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinDataImportado.Location = new System.Drawing.Point(9, 44);
            this.txtMinDataImportado.Name = "txtMinDataImportado";
            this.txtMinDataImportado.Size = new System.Drawing.Size(87, 26);
            this.txtMinDataImportado.TabIndex = 44;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtTipoEmprestimo);
            this.groupBox3.Location = new System.Drawing.Point(640, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 79);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo do Emprestimo";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(104, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 20);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "Não Importar";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Codigo";
            // 
            // txtTipoEmprestimo
            // 
            this.txtTipoEmprestimo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoEmprestimo.Location = new System.Drawing.Point(10, 44);
            this.txtTipoEmprestimo.Name = "txtTipoEmprestimo";
            this.txtTipoEmprestimo.Size = new System.Drawing.Size(87, 26);
            this.txtTipoEmprestimo.TabIndex = 44;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFimDataPagamento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtInicioDataPagamento);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(436, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 86);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data de Pagamento";
            // 
            // txtFimDataPagamento
            // 
            this.txtFimDataPagamento.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFimDataPagamento.Location = new System.Drawing.Point(103, 44);
            this.txtFimDataPagamento.Name = "txtFimDataPagamento";
            this.txtFimDataPagamento.Size = new System.Drawing.Size(87, 26);
            this.txtFimDataPagamento.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "Fim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Início";
            // 
            // txtInicioDataPagamento
            // 
            this.txtInicioDataPagamento.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicioDataPagamento.Location = new System.Drawing.Point(9, 44);
            this.txtInicioDataPagamento.Name = "txtInicioDataPagamento";
            this.txtInicioDataPagamento.Size = new System.Drawing.Size(87, 26);
            this.txtInicioDataPagamento.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaxParcela);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.txtMinParcela);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(435, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 79);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valor de Parcela";
            // 
            // txtMaxParcela
            // 
            this.txtMaxParcela.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxParcela.Location = new System.Drawing.Point(103, 44);
            this.txtMaxParcela.Name = "txtMaxParcela";
            this.txtMaxParcela.Size = new System.Drawing.Size(87, 26);
            this.txtMaxParcela.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Máximo";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(6, 21);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 20);
            this.label38.TabIndex = 36;
            this.label38.Text = "Mínimo";
            // 
            // txtMinParcela
            // 
            this.txtMinParcela.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinParcela.Location = new System.Drawing.Point(9, 44);
            this.txtMinParcela.Name = "txtMinParcela";
            this.txtMinParcela.Size = new System.Drawing.Size(87, 26);
            this.txtMinParcela.TabIndex = 44;
            // 
            // grpFiltroConfigurado
            // 
            this.grpFiltroConfigurado.Controls.Add(this.txtCaminhoArquivo);
            this.grpFiltroConfigurado.Controls.Add(this.btnAbrirArquivo);
            this.grpFiltroConfigurado.Enabled = false;
            this.grpFiltroConfigurado.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltroConfigurado.Location = new System.Drawing.Point(12, 88);
            this.grpFiltroConfigurado.Name = "grpFiltroConfigurado";
            this.grpFiltroConfigurado.Size = new System.Drawing.Size(1059, 69);
            this.grpFiltroConfigurado.TabIndex = 76;
            this.grpFiltroConfigurado.TabStop = false;
            this.grpFiltroConfigurado.Text = "Utilizar Filtro Configurado";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirArquivo.Location = new System.Drawing.Point(1008, 25);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(36, 26);
            this.btnAbrirArquivo.TabIndex = 71;
            this.btnAbrirArquivo.Text = "...";
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblErro);
            this.groupBox10.Controls.Add(this.lblProgresso);
            this.groupBox10.Controls.Add(this.pgbProgresso);
            this.groupBox10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(12, 384);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1059, 100);
            this.groupBox10.TabIndex = 77;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Status da Importação";
            // 
            // lblErro
            // 
            this.lblErro.AutoSize = true;
            this.lblErro.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErro.Location = new System.Drawing.Point(729, 34);
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(21, 20);
            this.lblErro.TabIndex = 70;
            this.lblErro.Text = "...";
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.Location = new System.Drawing.Point(9, 34);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(21, 20);
            this.lblProgresso.TabIndex = 69;
            this.lblProgresso.Text = "...";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnEstimar);
            this.groupBox11.Controls.Add(this.btnImportar);
            this.groupBox11.Controls.Add(this.btnCancelar);
            this.groupBox11.Controls.Add(this.btnLimpar);
            this.groupBox11.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(605, 13);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(466, 69);
            this.groupBox11.TabIndex = 78;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Ações";
            // 
            // btnEstimar
            // 
            this.btnEstimar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstimar.Location = new System.Drawing.Point(349, 25);
            this.btnEstimar.Name = "btnEstimar";
            this.btnEstimar.Size = new System.Drawing.Size(105, 33);
            this.btnEstimar.TabIndex = 78;
            this.btnEstimar.Text = "Estimar Qtd";
            this.btnEstimar.UseVisualStyleBackColor = true;
            this.btnEstimar.Click += new System.EventHandler(this.btnEstimar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Location = new System.Drawing.Point(16, 25);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(105, 33);
            this.btnImportar.TabIndex = 77;
            this.btnImportar.Text = "Importar Base";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(127, 25);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 33);
            this.btnCancelar.TabIndex = 76;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(238, 25);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(105, 33);
            this.btnLimpar.TabIndex = 75;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtNomeImportacao);
            this.groupBox12.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(12, 13);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(587, 69);
            this.groupBox12.TabIndex = 77;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Nome da Importação";
            // 
            // txtNomeImportacao
            // 
            this.txtNomeImportacao.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeImportacao.Location = new System.Drawing.Point(13, 25);
            this.txtNomeImportacao.Name = "txtNomeImportacao";
            this.txtNomeImportacao.Size = new System.Drawing.Size(563, 26);
            this.txtNomeImportacao.TabIndex = 70;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FrmImportacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 498);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.grpFiltroConfigurado);
            this.Controls.Add(this.grpFiltros);
            this.Name = "FrmImportacao";
            this.Text = "Importação de Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImportacao_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpAtualizar.ResumeLayout(false);
            this.grpAtualizar.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpFiltroConfigurado.ResumeLayout(false);
            this.grpFiltroConfigurado.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.TextBox txtCaminhoArquivo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ListBox ltbBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFimDataPagamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInicioDataPagamento;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtMaxDataImportado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMinDataImportado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTipoEmprestimo;
        private System.Windows.Forms.GroupBox grpAtualizar;
        private System.Windows.Forms.CheckBox chbAtualizar;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox ltbBanco;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox grpFiltroConfigurado;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnEstimar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblErro;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaxParcela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtMinParcela;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox txtNomeImportacao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

