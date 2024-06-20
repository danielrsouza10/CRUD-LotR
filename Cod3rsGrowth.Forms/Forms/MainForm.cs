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
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
            InicializarListaDeRacas(filtroRaca);
        }
        private void InicializarListaDePersonagens(Filtro filtroPersonagem, Filtro filtroRaca)
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
            gridPersonagens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var POSICAO_ESTA_VIVO_NA_TABELA = 6;
            var POSICAO_DATA_DE_CADASTRO_NA_TABELA = 7;
            if(gridPersonagens.Columns.Count>0)
            {
                gridPersonagens.Columns[POSICAO_ESTA_VIVO_NA_TABELA].HeaderText = "Esta vivo?";
                gridPersonagens.Columns[POSICAO_DATA_DE_CADASTRO_NA_TABELA].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        private void InicializarListaDeRacas(Filtro filtroRaca)
        {
            gridRacas.DataSource = _servicoRaca.ObterTodos(filtroRaca);
            gridRacas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var POSICAO_HABILIDADE_RACIAL_NA_TABELA = 2;
            var POSICAO_LOCALIZACAO_GEOGRAFICA_NA_TABELA = 3;
            var POSICAO_ESTA_EXTINTA_NA_TABELA = 4;

            gridRacas.Columns[POSICAO_HABILIDADE_RACIAL_NA_TABELA].HeaderText = "Habilidade Racial";
            gridRacas.Columns[POSICAO_LOCALIZACAO_GEOGRAFICA_NA_TABELA].HeaderText = "Localização Geográfica";
            gridRacas.Columns[POSICAO_ESTA_EXTINTA_NA_TABELA].HeaderText = "Esta Extinta?";
        }
        private void AoClicarNaTabDePersonagensDeveListarTodasOsPersonagensNoDataGrid(object sender, EventArgs e)
        {
            LimparFiltro();
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoClicarNaTabDeRacasDeveListarTodasAsRacasNoDataGrid(object sender, EventArgs e)
        {
            InicializarListaDeRacas(filtroRaca);
        }
        private void AoDigitarNaBarraDePesquisaDePersonagemDeveListarNoDataGrid(object sender, EventArgs e)
        {
            filtroPersonagem.Nome = nomePersonagemRadioButton.Checked ? barraDePesquisaDePersonagem.Text : null;
            if (idPersonagemRadioButton.Checked)
            {
                try
                {
                    filtroPersonagem.Id = int.Parse(barraDePesquisaDePersonagem.Text);
                    InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
                }
                catch { }
            }
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
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
                    InicializarListaDeRacas(filtroRaca);
                }
                catch { }
            }
            InicializarListaDeRacas(filtroRaca);
        }
        private void AoDarCheckNoBoxVivoDeveFiltarAListaDePersonagens(object sender, EventArgs e)
        {
            barraDePesquisaDePersonagem.Text = string.Empty;
            filtroPersonagem.EstaVivo = vivoPersonagemCheckBox.Checked ? vivoPersonagemCheckBox.Checked : null;
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoDarCheckNoBoxExtintaDeveFiltarAListaDeRacas(object sender, EventArgs e)
        {
            barraDePesquisaDeRaca.Text = string.Empty;
            filtroRaca.EstaExtinta = racaExtintaCheckBox.Checked ? racaExtintaCheckBox.Checked : null;
            InicializarListaDeRacas(filtroRaca);
        }
        private void AoSelecionarUmaDataDeveAdicionarOValorAoFiltro(object sender, EventArgs e)
        {
            filtroPersonagem.DataDoCadastro = dateTimePicker.Value;
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoAlterarASelecaoDoImputRadioDeNomePersonagemDeveAtualizarAListaPersonagem(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
        }
        private void AoAlterarASelecaoDoImputRadioDeNomeRacaDeveAtualizarAListaRaca(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDeRaca.Text = string.Empty;
            InicializarListaDeRacas(filtroRaca);
        }
        private void AoClicarNoBotaoAdicionarDeveAbrirAJanelaDeCriacao(object sender, EventArgs e)
        {
            if(tabControl.SelectedTab == tabPersonagens)
            {
                var criacaoPersonagem = new CriacaoPersonagemForm(_servicoPersonagem, _servicoRaca);
                criacaoPersonagem.ShowDialog();
                InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
            } else if(tabControl.SelectedTab == tabRacas)
            {
                var criacaoRaca = new CriacaoRacaForm(_servicoRaca);
                criacaoRaca.ShowDialog();
                InicializarListaDeRacas(filtroRaca);
            }
        }
        private void AoClicarNoBotaoResetDeveCarregarAsListasSemFiltrosAplicados(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisaDePersonagem.Text = string.Empty;
            barraDePesquisaDeRaca.Text = string.Empty;
            InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
            InicializarListaDeRacas(filtroRaca);
        }
        private void AoClicarNoBotaoRemoverDeveVerificarTabAtivaERemoverDeAcordo(object sender, EventArgs e)
        {
            if(tabControl.SelectedTab == tabPersonagens)
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
            var idDaLinhaSelecionadaNoDataGrid = gridPersonagens.CurrentCell.RowIndex;
            var COLUNA_ID = "Id";
            var MENSAGEM_CONFIRMACAO_REMOCAO_DE_PERSONAGEM = "Tem certeza que quer remover o personagem selecionado?";
            var TITULO_MESSAGE_BOX = "Confirme sua escolha";
            try
            {
                int idDoPersonagemSelecionado = int.Parse(gridPersonagens.Rows[idDaLinhaSelecionadaNoDataGrid]
                                                    .Cells[COLUNA_ID].Value
                                                    .ToString());
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
                    InicializarListaDePersonagens(filtroPersonagem, filtroRaca);
                }
            }
            catch
            {
                var MENSAGEM_ERRO_LISTA_VAZIA = "Lista vazia";
                var TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA = "Erro";
                MessageBox.Show(MENSAGEM_ERRO_LISTA_VAZIA, TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoverRaca()
        {
            var idDaLinhaSelecionadaNoDataGridViewDeRacas = gridRacas.CurrentCell.RowIndex;
            var COLUNA_ID = "Id";
            var MENSAGEM_CONFIRMACAO_REMOCAO_DE_RACA = "Tem certeza que quer remover a raça selecionada?";
            var TITULO_MESSAGE_BOX = "Confirme sua escolha";
            try
            {
                int idDaRacaSelecionada = int.Parse(gridRacas.Rows[idDaLinhaSelecionadaNoDataGridViewDeRacas]
                                                    .Cells[COLUNA_ID].Value
                                                    .ToString());
                var retornoDaConfirmacaoDoUsuario = MessageBox.Show(MENSAGEM_CONFIRMACAO_REMOCAO_DE_RACA, TITULO_MESSAGE_BOX, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (retornoDaConfirmacaoDoUsuario == DialogResult.Yes)
                {

                }
                try
                {
                    _servicoRaca.Deletar(idDaRacaSelecionada);
                }
                catch (Exception ex)
                {
                    var MENSAGEM_DE_ERRO_AO_DELETAR_RACA = "Existem personagens vinculados a essa raça. Exclua-os primeiramente para que seja possível exluir essa raça";
                    MessageBox.Show(MENSAGEM_DE_ERRO_AO_DELETAR_RACA);
                }
                LimparFiltro();
                InicializarListaDeRacas(filtroRaca);
            }
            catch
            {
                var MENSAGEM_ERRO_LISTA_VAZIA = "Lista vazia";
                var TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA = "Erro";
                MessageBox.Show(MENSAGEM_ERRO_LISTA_VAZIA, TITULO_MESSAGE_BOX_ERRO_LISTA_VAZIA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
