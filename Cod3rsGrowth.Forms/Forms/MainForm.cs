using Dominio.ENUMS;
using Dominio.Filtros;
using Forms.Forms;
using Servico.Servicos;
using System.ComponentModel;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly ServicoPersonagem _servicoPersonagem;
        private readonly ServicoRaca _servicoRaca;
        private readonly Filtro _filtroPersonagem = new Filtro();
        private readonly Filtro _filtroRaca = new Filtro();

        public MainForm(ServicoPersonagem servicoPersonagem, ServicoRaca servicoRaca)
        {
            _servicoPersonagem = servicoPersonagem;
            _servicoRaca = servicoRaca;
            InitializeComponent();
        }
        private void LimparFiltro()
        {
            _filtroPersonagem.Nome = null;
            _filtroPersonagem.EstaVivo = null;
            _filtroPersonagem.DataFinal = null;
            _filtroPersonagem.Profissao = (ProfissaoEnum)Enum.Parse(typeof(ProfissaoEnum), "Nenhum");
            _filtroPersonagem.DataInicial = null;
            _filtroPersonagem.DataFinal = null;
            _filtroRaca.Nome = null;
            _filtroRaca.EstaExtinta = null;
            filtroRacaBox.SelectedItem = null;
        }
        private void IniciarFormPrincipal(object sender, EventArgs e)
        {
            filtroRacaBox.DataSource = _servicoRaca.ObterTodos(_filtroRaca);
            filtroRacaBox.DisplayMember = "Nome";
            boxFiltroProfissao.DataSource = Enum.GetValues(typeof(ProfissaoEnum));
            LimparFiltro();
            DefinirGridDePersonagens(_filtroPersonagem);
            DefinirGridDeRacas(_filtroRaca);
        }
        private void DefinirGridDePersonagens(Filtro filtroPersonagem)
        {
            gridPersonagens.DataSource = _servicoPersonagem.ObterTodos(filtroPersonagem);
            FormatarGridDePersonagens();
        }
        private void DefinirGridDeRacas(Filtro filtroRaca)
        {
            gridRacas.DataSource = _servicoRaca.ObterTodos(filtroRaca);
            FormatarGridRacas();
        }
        private void AoClicarNaTabDePersonagensDeveListarTodasOsPersonagensNoDataGrid(object sender, EventArgs e)
        {
            LimparFiltro();
            DefinirGridDePersonagens(_filtroPersonagem);
        }
        private void AoClicarNaTabDeRacasDeveListarTodasAsRacasNoDataGrid(object sender, EventArgs e)
        {
            LimparFiltro();
            DefinirGridDeRacas(_filtroRaca);
        }
        private void AoDigitarNaBarraDePesquisaDePersonagemDeveListarNoDataGrid(object sender, EventArgs e)
        {
            _filtroPersonagem.Nome = barraDePesquisaDePersonagem.Text;
            DefinirGridDePersonagens(_filtroPersonagem);
        }
        private void AoDigitarNaBarraDePesquisaDeRacaDeveListarNoDataGrid(object sender, EventArgs e)
        {
            _filtroRaca.Nome = barraDePesquisaDeRaca.Text;
            DefinirGridDeRacas(_filtroRaca);
        }
        private void AoDarCheckNoBoxVivoDeveFiltarAListaDePersonagens(object sender, EventArgs e)
        {
            if (vivoPersonagemCheckBox.Checked && mortoPersonagemCheckBox.Checked) mortoPersonagemCheckBox.Checked = false;
            barraDePesquisaDePersonagem.Text = string.Empty;
            _filtroPersonagem.EstaVivo = vivoPersonagemCheckBox.Checked ? vivoPersonagemCheckBox.Checked : null;
            DefinirGridDePersonagens(_filtroPersonagem);
        }
        private void AoDarCheckNoBoxMortoDeveFiltarAListaDePersonagens(object sender, EventArgs e)
        {
            if (mortoPersonagemCheckBox.Checked && vivoPersonagemCheckBox.Checked) vivoPersonagemCheckBox.Checked = false;
            barraDePesquisaDePersonagem.Text = string.Empty;
            _filtroPersonagem.EstaVivo = mortoPersonagemCheckBox.Checked ? !mortoPersonagemCheckBox.Checked : null;
            DefinirGridDePersonagens(_filtroPersonagem);
        }
        private void AoDarCheckNoBoxExtintaDeveFiltarAListaDeRacas(object sender, EventArgs e)
        {
            barraDePesquisaDeRaca.Text = string.Empty;
            _filtroRaca.EstaExtinta = racaExtintaCheckBox.Checked ? racaExtintaCheckBox.Checked : null;
            DefinirGridDeRacas(_filtroRaca);
        }
        private void AoSelecionarUmaDataDeveAdicionarOValorAoFiltro(object sender, EventArgs e)
        {
            _filtroPersonagem.DataFinal = dataInicialTimePicker.Value;
            DefinirGridDePersonagens(_filtroPersonagem);
        }
        private void AoClicarNoBotaoAdicionarDeveAbrirAJanelaDeCriacao(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPersonagens)
            {
                var criacaoPersonagem = new CriarAtualizarPersonagemForm(_servicoPersonagem, _servicoRaca);
                criacaoPersonagem.ShowDialog();
                DefinirGridDePersonagens(_filtroPersonagem);
                return;
            }
            var criacaoRaca = new CriarAtualizarRacaForm(_servicoRaca);
            criacaoRaca.ShowDialog();
            DefinirGridDeRacas(_filtroRaca);
        }
        private void AoClicarNoBotaoEditarDeveAbrirJanelaDeEdicao(object sender, EventArgs e)
        {
            int idSelecionado;
            if (tabControl.SelectedTab == tabPersonagens)
            {
                idSelecionado = ObterIdDoPersonagemSelecionadoNoGrid();
                var criacaoPersonagem = new CriarAtualizarPersonagemForm(_servicoPersonagem, _servicoRaca, idSelecionado);
                criacaoPersonagem.ShowDialog();
                DefinirGridDePersonagens(_filtroPersonagem);
                return;
            }
            idSelecionado = ObterIdDaRacaSelecionadoNoGrid();
            var criacaoRaca = new CriarAtualizarRacaForm(_servicoRaca, idSelecionado);
            criacaoRaca.ShowDialog();
            DefinirGridDeRacas(_filtroRaca);
        }
        private void AoClicarNoBotaoResetLimparFiltroEDefinirOGrid(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            barraDePesquisaDeRaca.Text = string.Empty;
            DefinirGridDePersonagens(_filtroPersonagem);
            DefinirGridDeRacas(_filtroRaca);
        }
        private void AoClicarNoBotaoRemoverDeveVerificarTabAtivaERemoverDeAcordo(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPersonagens)
            {
                RemoverPersonagem();
                return;
            }
            RemoverRaca();
        }
        private void RemoverPersonagem()
        {
            int idDoPersonagemSelecionado = ObterIdDoPersonagemSelecionadoNoGrid();
            var MENSAGEM_CONFIRMACAO_REMOCAO_DE_PERSONAGEM = "Tem certeza que quer remover o personagem selecionado?";
            var TITULO_MESSAGE_BOX = "Confirme sua escolha";
            var retornoDaConfirmacaoDoUsuario = MessageBox.Show(MENSAGEM_CONFIRMACAO_REMOCAO_DE_PERSONAGEM, TITULO_MESSAGE_BOX, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (retornoDaConfirmacaoDoUsuario == DialogResult.Yes)
            {
                try
                {
                    _servicoPersonagem.Deletar(idDoPersonagemSelecionado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LimparFiltro();
                DefinirGridDePersonagens(_filtroPersonagem);
            }
        }
        private void RemoverRaca()
        {
            var idDaRacaSelecionada = ObterIdDaRacaSelecionadoNoGrid();
            var MENSAGEM_CONFIRMACAO_REMOCAO_DE_RACA = "Tem certeza que quer remover a raça selecionada?";
            var TITULO_MESSAGE_BOX = "Confirme sua escolha";
            var retornoDaConfirmacaoDoUsuario = MessageBox.Show(MENSAGEM_CONFIRMACAO_REMOCAO_DE_RACA, TITULO_MESSAGE_BOX, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (retornoDaConfirmacaoDoUsuario == DialogResult.Yes)
            {
                try
                {
                    _servicoRaca.Deletar(idDaRacaSelecionada);
                }
                catch (Exception ex)
                {
                    var MENSAGEM_DE_ERRO_AO_DELETAR_RACA = "Existem personagens vinculados a essa raça.\nExclua-os primeiramente para que seja possível ecxluir essa raça.";
                    MessageBox.Show(MENSAGEM_DE_ERRO_AO_DELETAR_RACA);
                }
                LimparFiltro();
                DefinirGridDeRacas(_filtroRaca);
            }
        }
        private void FormatarGridDePersonagens()
        {
            gridPersonagens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var POSICAO_ESTA_VIVO_NA_TABELA = "EstaVivo";
            var POSICAO_DATA_DE_CADASTRO_NA_TABELA = "DataDoCadastro";
            var POSICAO_ALTURA_NA_TABELA = "Altura";
            bool GRID_PERSONAGENS_EXISTE = gridPersonagens.Columns.Count > 0;
            if (GRID_PERSONAGENS_EXISTE)
            {
                gridPersonagens.Columns[POSICAO_ESTA_VIVO_NA_TABELA].HeaderText = "Esta vivo?";
                gridPersonagens.Columns[POSICAO_DATA_DE_CADASTRO_NA_TABELA].HeaderText = "Data do cadastro";
                gridPersonagens.Columns[POSICAO_DATA_DE_CADASTRO_NA_TABELA].DefaultCellStyle.Format = "dd/MM/yyyy";
                gridPersonagens.Columns[POSICAO_ALTURA_NA_TABELA].DefaultCellStyle.Format = "0.00##";
            }
        }
        private void FormatarGridRacas()
        {
            gridRacas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var POSICAO_LOCALIZACAO_GEOGRAFICA_NA_TABELA = 2;
            var POSICAO_HABILIDADE_RACIAL_NA_TABELA = 3;
            var POSICAO_ESTA_EXTINTA_NA_TABELA = 4;

            gridRacas.Columns[POSICAO_HABILIDADE_RACIAL_NA_TABELA].HeaderText = "Habilidade Racial";
            gridRacas.Columns[POSICAO_LOCALIZACAO_GEOGRAFICA_NA_TABELA].HeaderText = "Localização Geográfica";
            gridRacas.Columns[POSICAO_ESTA_EXTINTA_NA_TABELA].HeaderText = "Esta Extinta?";
        }
        private int ObterIdDoPersonagemSelecionadoNoGrid()
        {
            var idDaLinhaSelecionadaNoDataGrid = gridPersonagens.CurrentCell.RowIndex;
            var COLUNA_ID = "Id";
            try
            {
                return int.Parse(gridPersonagens.Rows[idDaLinhaSelecionadaNoDataGrid]
                                                    .Cells[COLUNA_ID].Value
                                                    .ToString());
            }
            catch (Exception ex)
            {
                var MENSAGEM_ERRO_LISTA_VAZIA = "Lista vazia";
                var TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA = "Erro";
                MessageBox.Show(MENSAGEM_ERRO_LISTA_VAZIA, TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private int ObterIdDaRacaSelecionadoNoGrid()
        {
            var idDaLinhaSelecionadaNoDataGrid = gridRacas.CurrentCell.RowIndex;
            var COLUNA_ID = "Id";
            try
            {
                return int.Parse(gridRacas.Rows[idDaLinhaSelecionadaNoDataGrid]
                                                    .Cells[COLUNA_ID].Value
                                                    .ToString());
            }
            catch (Exception ex)
            {
                int ID_EM_CASO_DE_NULL = 0;
                var MENSAGEM_ERRO_LISTA_VAZIA = "Lista vazia";
                var TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA = "Erro";
                MessageBox.Show(MENSAGEM_ERRO_LISTA_VAZIA, TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ID_EM_CASO_DE_NULL;
            }
        }

        private void AoAlterarASelecaoDoComboboxDeRacasDeveFiltrar(object sender, EventArgs e)
        {
            _filtroRaca.Nome = filtroRacaBox.GetItemText(filtroRacaBox.SelectedItem);
            DefinirGridDePersonagens(_filtroPersonagem);
        }

        private void AoAlterarASelecaoDoComboboxDeProfissaoDeveFiltrar(object sender, EventArgs e)
        {
            _filtroPersonagem.Profissao = (ProfissaoEnum)Enum.Parse(typeof(ProfissaoEnum), boxFiltroProfissao.Text);
            DefinirGridDePersonagens(_filtroPersonagem);
        }

        private void AoAlterarADataInicialDeveFiltrar(object sender, EventArgs e)
        {
            _filtroPersonagem.DataInicial = dataInicialTimePicker.Value.Date;
            DefinirGridDePersonagens(_filtroPersonagem);
        }

        private void AoAlterarADataFinalDeveFiltrar(object sender, EventArgs e)
        {
            _filtroPersonagem.DataFinal = dataFinalTimePicker.Value.Date;
            DefinirGridDePersonagens(_filtroPersonagem);
        }

        private void AoAlternarEntreTabsDeveRedefinirOGrid(object sender, TabControlEventArgs e)
        {
            filtroRacaBox.DataSource = _servicoRaca.ObterTodos(_filtroRaca);
            LimparFiltro();
            DefinirGridDePersonagens(_filtroPersonagem);
            DefinirGridDeRacas(_filtroRaca);
        }
    }
}
