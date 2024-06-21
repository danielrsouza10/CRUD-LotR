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
        Filtro filtroPersonagem = new Filtro();
        Filtro filtroRaca = new Filtro();

        public MainForm(ServicoPersonagem servicoPersonagem, ServicoRaca servicoRaca)
        {
            _servicoPersonagem = servicoPersonagem;
            _servicoRaca = servicoRaca;
            InitializeComponent();
        }
        private void LimparFiltro()
        {
            filtroPersonagem.Nome = null;
            filtroPersonagem.EstaVivo = null;
            filtroPersonagem.DataDoCadastro = null;
            filtroPersonagem.Id = null;
            filtroRaca.Nome = null;
            filtroRaca.EstaExtinta = null;
            filtroRaca.Id = null;
        }
        private void IniciarFormPrincipal(object sender, EventArgs e)
        {
            LimparFiltro();
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
            DefinirGridDeRacas(filtroRaca);
        }
        private void DefinirGridDePersonagens(Filtro filtroPersonagem, Filtro filtroRaca)
        {
            var personagens = _servicoPersonagem.ObterTodos(filtroPersonagem);
            var racas = _servicoRaca.ObterTodos(filtroRaca);

            var listaCombinada = from personagem in personagens
                                 join raca in racas on personagem.IdRaca equals raca.Id
                                 select new
                                 {
                                     Id = personagem.Id,
                                     Nome = personagem.Nome,
                                     Raca = raca.Nome,
                                     Profissao = personagem.Profissao,
                                     Idade = personagem.Idade,
                                     Altura = personagem.Altura,
                                     EstaVivo = personagem.EstaVivo,
                                     DataDoCadastro = personagem.DataDoCadastro
                                 };

            var bindingList = new BindingList<object>(listaCombinada.Cast<object>().ToList());
            gridPersonagens.DataSource = bindingList;
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
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoClicarNaTabDeRacasDeveListarTodasAsRacasNoDataGrid(object sender, EventArgs e)
        {
            DefinirGridDeRacas(filtroRaca);
        }
        private void AoDigitarNaBarraDePesquisaDePersonagemDeveListarNoDataGrid(object sender, EventArgs e)
        {
            filtroPersonagem.Nome = nomePersonagemRadioButton.Checked ? barraDePesquisaDePersonagem.Text : null;
            if (idPersonagemRadioButton.Checked)
            {
                try
                {
                    filtroPersonagem.Id = int.Parse(barraDePesquisaDePersonagem.Text);
                    DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
                }
                catch { }
            }
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoDigitarNaBarraDePesquisaDeRacaDeveListarNoDataGrid(object sender, EventArgs e)
        {
            filtroRaca.Nome = nomeRacaRadioButton.Checked ? barraDePesquisaDeRaca.Text : null;
            filtroRaca.EstaExtinta = racaExtintaCheckBox.Checked ? racaExtintaCheckBox.Checked : null;
            if (idRacaRadioButton.Checked)
            {
                try
                {
                    filtroRaca.Id = int.Parse(barraDePesquisaDeRaca.Text);
                    DefinirGridDeRacas(filtroRaca);
                }
                catch { }
            }
            DefinirGridDeRacas(filtroRaca);
        }
        private void AoDarCheckNoBoxVivoDeveFiltarAListaDePersonagens(object sender, EventArgs e)
        {
            barraDePesquisaDePersonagem.Text = string.Empty;
            filtroPersonagem.EstaVivo = vivoPersonagemCheckBox.Checked ? vivoPersonagemCheckBox.Checked : null;
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoDarCheckNoBoxExtintaDeveFiltarAListaDeRacas(object sender, EventArgs e)
        {
            barraDePesquisaDeRaca.Text = string.Empty;
            filtroRaca.EstaExtinta = racaExtintaCheckBox.Checked ? racaExtintaCheckBox.Checked : null;
            DefinirGridDeRacas(filtroRaca);
        }
        private void AoSelecionarUmaDataDeveAdicionarOValorAoFiltro(object sender, EventArgs e)
        {
            filtroPersonagem.DataDoCadastro = dateTimePicker.Value;
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoAlterarASelecaoDoImputRadioDeNomePersonagemDeveAtualizarAListaPersonagem(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoAlterarASelecaoDoImputRadioDeNomeRacaDeveAtualizarAListaRaca(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDeRaca.Text = string.Empty;
            DefinirGridDeRacas(filtroRaca);
        }
        private void AoClicarNoBotaoAdicionarDeveAbrirAJanelaDeCriacao(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPersonagens)
            {
                var criacaoPersonagem = new CriarAtualizarPersonagemForm(_servicoPersonagem, _servicoRaca);
                criacaoPersonagem.ShowDialog();
                DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
            }
            else if (tabControl.SelectedTab == tabRacas)
            {
                var criacaoRaca = new CriarAtualizarRacaForm(_servicoRaca);
                criacaoRaca.ShowDialog();
                DefinirGridDeRacas(filtroRaca);
            }
        }
        private void AoClicarNoBotaoEditarDeveAbrirJanelaDeEdicao(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPersonagens)
            {
                var idSelecionado = ObterIdDoPersonagemSelecionadoNoGrid();
                var criacaoPersonagem = new CriarAtualizarPersonagemForm(_servicoPersonagem, _servicoRaca, idSelecionado);
                criacaoPersonagem.ShowDialog();
                DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
            }
            else if (tabControl.SelectedTab == tabRacas)
            {
                var idSelecionado = ObterIdDaRacaSelecionadoNoGrid();
                var criacaoRaca = new CriarAtualizarRacaForm(_servicoRaca, idSelecionado);
                criacaoRaca.ShowDialog();
                DefinirGridDeRacas(filtroRaca);
            }
        }
        private void AoClicarNoBotaoResetDeveCarregarAsListasSemFiltrosAplicados(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            barraDePesquisaDeRaca.Text = string.Empty;
            DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
            DefinirGridDeRacas(filtroRaca);
        }
        private void AoClicarNoBotaoRemoverDeveVerificarTabAtivaERemoverDeAcordo(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPersonagens)
            {
                RemoverPersonagem();
            }
            else if (tabControl.SelectedTab == tabRacas)
            {
                RemoverRaca();
            }
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
                DefinirGridDePersonagens(filtroPersonagem, filtroRaca);
            }
        }
        private void RemoverRaca()
        {
            var idDaRacaSelecionada = ObterIdDaRacaSelecionadoNoGrid();
            var MENSAGEM_CONFIRMACAO_REMOCAO_DE_RACA = "Tem certeza que quer remover a ra�a selecionada?";
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
                        var MENSAGEM_DE_ERRO_AO_DELETAR_RACA = "Existem personagens vinculados a essa ra�a.\nExclua-os primeiramente para que seja poss�vel ecxluir essa ra�a.";
                        MessageBox.Show(MENSAGEM_DE_ERRO_AO_DELETAR_RACA);
                    }
                    LimparFiltro();
                    DefinirGridDeRacas(filtroRaca);
                }
        }
        private void FormatarGridDePersonagens()
        {
            gridPersonagens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var POSICAO_ESTA_VIVO_NA_TABELA = 6;
            var POSICAO_DATA_DE_CADASTRO_NA_TABELA = 7;
            if (gridPersonagens.Columns.Count > 0)
            {
                gridPersonagens.Columns[POSICAO_ESTA_VIVO_NA_TABELA].HeaderText = "Esta vivo?";
                gridPersonagens.Columns[POSICAO_DATA_DE_CADASTRO_NA_TABELA].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        private void FormatarGridRacas()
        {
            gridRacas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var POSICAO_HABILIDADE_RACIAL_NA_TABELA = 2;
            var POSICAO_LOCALIZACAO_GEOGRAFICA_NA_TABELA = 3;
            var POSICAO_ESTA_EXTINTA_NA_TABELA = 4;

            gridRacas.Columns[POSICAO_HABILIDADE_RACIAL_NA_TABELA].HeaderText = "Habilidade Racial";
            gridRacas.Columns[POSICAO_LOCALIZACAO_GEOGRAFICA_NA_TABELA].HeaderText = "Localiza��o Geogr�fica";
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
                var MENSAGEM_ERRO_LISTA_VAZIA = "Lista vazia";
                var TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA = "Erro";
                MessageBox.Show(MENSAGEM_ERRO_LISTA_VAZIA, TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
