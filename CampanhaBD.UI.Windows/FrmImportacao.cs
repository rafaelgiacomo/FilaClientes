using CampanhaBD.Business;
using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampanhaBD.UI.Windows
{
    public partial class FrmImportacao : Form
    {

        #region Propriedades
        public readonly CoreBusiness _core = CoreBusiness.GetInstance(
            ConfigurationManager.ConnectionStrings["CampanhaBD"].ConnectionString);

        private BaseOriginalBusiness _baseOriginalBus;
        private BancoBusiness _bancoBus;
        private ImportacaoBusiness _impBus;

        public List<BaseOriginalModel> ListaBases { get; set; }
        public List<BancoModel> ListaBancos { get; set; }

        public ImportacaoModel Importacao { get; set; }
        public FiltroModel Filtro { get; set; }
        #endregion

        public FrmImportacao()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _core.AbrirConexao();

                _baseOriginalBus = new BaseOriginalBusiness(_core);
                _bancoBus = new BancoBusiness(_core);
                _impBus = new ImportacaoBusiness(_core);

                ListaBases = _baseOriginalBus.ListarBases();
                ListaBancos = _bancoBus.ListarTodos();

                ltbBase.DataSource = ListaBases;
                ltbBanco.DataSource = ListaBancos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Eventos

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                Importacao = PreencheImportacao();
                Filtro = PreencheFiltro();

                int qtdClientes = _impBus.EstimarQuantidade(Filtro);

                if (Importacao.ValidaDadosParaSalvar())
                {
                    pgbProgresso.Style = ProgressBarStyle.Blocks;
                    pgbProgresso.Value = 0;
                    pgbProgresso.Maximum = qtdClientes;

                    backgroundWorker1.RunWorkerAsync();

                    TravarTela(true);
                }
                else
                {
                    MessageBox.Show("Informe um nome para importação");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Iniciando Importação
                _impBus.IniciarImportacaoClientesSql(Importacao, Filtro);

                //Loop de Importação
                for (int i=0; i<pgbProgresso.Maximum; i++)
                {
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(0);
                        return;
                    }
                    else
                    {
                        _impBus.ImportarClienteDoSql(Importacao, Filtro);
                        backgroundWorker1.ReportProgress(i);
                    }
                }

                //Terminando Importação
                _impBus.TerminarImportacaoClientesSql(Importacao);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                pgbProgresso.Value = 0;
                lblProgresso.Text = string.Empty;
                return;
            }else
            {
                pgbProgresso.Value = e.ProgressPercentage;
                lblProgresso.Text = pgbProgresso.Value + " de " + pgbProgresso.Maximum;
            }            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                _impBus.CancelarImportacao();
                lblErro.Text = "Operação Cancelada pelo Usuário!";
            }
            else if (e.Error != null)
            {
                lblErro.Text = "Aconteceu um erro durante a execução do processo!";
            }
            else
            {
                lblErro.Text = "Importação Concluida com sucesso!";
            }

            TravarTela(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cancelamento da tarefa com fim determinado [backgroundWorker1]
            if (backgroundWorker1.IsBusy)//se o backgroundWorker1 estiver ocupado
            {
                // notifica a thread que o cancelamento foi solicitado.
                // Cancela a tarefa DoWork 
                backgroundWorker1.CancelAsync();
            }
            //desabilita o botão cancelar.
            btnCancelar.Enabled = false;
            lblErro.Text = "Cancelando...";
        }

        private void btnEstimar_Click(object sender, EventArgs e)
        {
            try
            {
                Filtro = PreencheFiltro();

                int qtdClientes = _impBus.EstimarQuantidade(Filtro);

                MessageBox.Show(qtdClientes + " Clientes filtrados");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmImportacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            _core.FecharConexao();
        }

        #endregion

        private void TravarTela(bool travar)
        {
            btnImportar.Enabled = !travar;
            btnCancelar.Enabled = travar;
            btnEstimar.Enabled = !travar;
            grpFiltros.Enabled = !travar;
            grpFiltroConfigurado.Enabled = !travar;
            grpAtualizar.Enabled = !travar;
        }

        private FiltroModel PreencheFiltro()
        {
            try
            {
                FiltroModel filtro = new FiltroModel();

                #region Pegando Bancos Selecionado 
                foreach (int index in ltbBanco.SelectedIndices)
                {
                    var indice = int.Parse(index.ToString());
                    filtro.Bancos.Add(ListaBancos[indice].Codigo);
                }
                #endregion

                #region Pegando Bases Selecionadas 
                foreach (int index in ltbBase.SelectedIndices)
                {
                    var indice = int.Parse(index.ToString());
                    filtro.BasesOriginais.Add(ListaBases[indice].Id);
                }
                #endregion

                #region Pegando TiposEmprestimos
                var texto = txtTipoEmprestimo.Text;

                if (!"".Equals(texto))
                {
                    var valores = texto.Split(';');

                    foreach (var valor in valores)
                    {
                        if (!"".Equals(valor))
                        {
                            filtro.TiposEmprestimos.Add(int.Parse(valor));
                        }
                    }
                }
                #endregion

                #region Importar Atualizando
                filtro.AtualizarDadosCliente = chbAtualizar.Checked;
                #endregion

                return filtro;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private ImportacaoModel PreencheImportacao()
        {
            try
            {
                ImportacaoModel imp = new ImportacaoModel();

                imp.UsuarioId = 1;
                imp.Nome = txtNomeImportacao.Text;

                return imp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

