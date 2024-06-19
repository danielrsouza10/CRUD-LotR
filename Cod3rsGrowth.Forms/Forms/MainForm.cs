using Dominio.ENUMS;
using Dominio.Filtros;
using Dominio.Modelos;
using Dominio.Validacao;
using Forms.Forms;
using Servico.Servicos;
using System.ComponentModel;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly ServicoPersonagem _servicoPersonagem;
        private readonly ServicoRaca _servicoRaca;
        Filtro filtro = new Filtro();

        public MainForm(ServicoPersonagem servicoPersonagem, ServicoRaca servicoRaca)
        {
            _servicoPersonagem = servicoPersonagem;
            _servicoRaca = servicoRaca;
            InitializeComponent();
        }
        private void LimparFiltro()
        {
            filtro.Nome = null;
            filtro.EstaVivo = null;
            filtro.DataDoCadastro = null;
            filtro.Id = null;
        }

        private void IniciarFormPrincipal(object sender, EventArgs e)
        {
            InicializarListaDePersonagens();
            InicializarListaDeRacas();
        }
        private void InicializarListaDePersonagens()
        {
            LimparFiltro();
            gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }

        private void InicializarListaDeRacas()
        {
            LimparFiltro();
            gridRacas.DataSource = _servicoRaca.ObterTodos(filtro);
        }
        private void AoDigitarNaBarraDePesquisaDeveListarOsItensCorrespondentesAPesquisa(object sender, EventArgs e)
        {
            filtro.Nome = nomeRadioButton.Checked ? barraDePesquisaDePersonagem.Text : null;
            if (idRadioButton.Checked)
            {
                try
                {
                    filtro.Id = int.Parse(barraDePesquisaDePersonagem.Text);
                    gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtro);
                }
                catch { }
            }
            gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoEntrarNaBarraDePesquisaDeveLimparOPlaceholder(object sender, EventArgs e)
        {
            barraDePesquisaDePersonagem.PlaceholderText = string.Empty;
        }
        private void AoSairDaBarraDePesquisaDeveAdicionarOPlaceholder(object sender, EventArgs e)
        {
            
     
        }
        private void AoDarCheckNoBoxVivoDeveFiltarALista(object sender, EventArgs e)
        {
            barraDePesquisaDePersonagem.Text = string.Empty;
            filtro.EstaVivo = vivoCheckBox.Checked;
            gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoSelecionarUmaDataDeveAdicionarOValorAoFiltro(object sender, EventArgs e)
        {
            filtro.DataDoCadastro = dateTimePicker.Value;
            gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoAlterarASelecaoDoImputRadioDeNomeDeveAtualizarALista(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }

        private void AoClicarNoBotaoAdicionarDeveAbrirAJanelaDeCriacao(object sender, EventArgs e)
        {
            var criacaoPersonagem = new CriacaoPersonagemForm(_servicoPersonagem, _servicoRaca);
            criacaoPersonagem.Show();
            InicializarListaDePersonagens();
        }

        private void AoClicarNoBotaoResetDeveCarregarAListaSemFiltrosAplicados(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            InicializarListaDePersonagens();
        }

        private void AoClicarNoBotaoRemoverDevePedirConfirmacaoERemoverPersonagemSelecionado(object sender, EventArgs e)
        {
            var idDaLinhaSelecionadaNoDataGridView = gridPersonagens.CurrentCell.RowIndex;
            var valorDaColunaRespectivaAoId = 0;
            try
            {
                int idDoPersonagemSelecionado = int.Parse(gridPersonagens.Rows[idDaLinhaSelecionadaNoDataGridView]
                                                    .Cells[valorDaColunaRespectivaAoId].Value
                                                    .ToString());
                var retornoDaConfirmacaoDoUsuario = MessageBox.Show("Tem certeza que quer remover o personagem selecionado?", "Confirme sua escolha", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (retornoDaConfirmacaoDoUsuario == DialogResult.Yes)
                    try
                    {
                        _servicoPersonagem.Deletar(idDoPersonagemSelecionado);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                LimparFiltro();
                InicializarListaDePersonagens();
            }
            catch 
            { 
                MessageBox.Show("Lista vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AoClicarNoMenuDeRacasDeveListarTodasAsRacasNoDataGrid(object sender, EventArgs e)
        {
            InicializarListaDeRacas();
        }

        private void AoClicarNoMenuDePersonagensDeveListarTodasOsPersonagensNoDataGrid(object sender, EventArgs e)
        {
            InicializarListaDePersonagens();
        }
    }
}
