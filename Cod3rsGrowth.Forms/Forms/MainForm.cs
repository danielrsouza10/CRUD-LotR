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
        private void MainForm_Load(object sender, EventArgs e)
        {
            InicializarListaDePersonagens();
        }
        private void InicializarListaDePersonagens()
        {
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoDigitarNaBarraDePesquisaDeveListarOsItensCorrespondentesAPesquisa(object sender, EventArgs e)
        {
            filtro.Nome = nomeRadioButton.Checked ? barraDePesquisa.Text : null;
            if (idRadioButton.Checked)
            {
                try
                {
                    filtro.Id = int.Parse(barraDePesquisa.Text);
                    dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
                }
                catch { }
            }
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoEntrarNaBarraDePesquisaDeveLimparOPlaceholder(object sender, EventArgs e)
        {
            barraDePesquisa.PlaceholderText = string.Empty;
        }
        private void AoSairDaBarraDePesquisaDeveAdicionarOPlaceholder(object sender, EventArgs e)
        {
            barraDePesquisa.PlaceholderText = "Pesquise o personagem...";
        }
        private void AoDarCheckNoBoxVivoDeveFiltarALista(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisa.Text = string.Empty;
            filtro.EstaVivo = vivoCheckBox.Checked;
            InicializarListaDePersonagens();
        }
        private void AoSelecionarUmaDataDeveAdicionarOValorAoFiltro(object sender, EventArgs e)
        {
            filtro.DataDoCadastro = dateTimePicker.Value;
            InicializarListaDePersonagens();
        }
        private void AoAlterarASelecaoDoImputRadioDeNomeDeveAtualizarALista(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisa.Text = string.Empty;
            InicializarListaDePersonagens();
        }

        private void AoClicarNoBotaoAdicionarDeveAbrirAJanelaDeCriacao(object sender, EventArgs e)
        {
            var criacaoPersonagem = new CriacaoPersonagemForm(_servicoPersonagem, _servicoRaca);
            criacaoPersonagem.Show();
        }

        private void AoClicarNoBotaoResetDeveCarregarAListaSemFiltrosAplicados(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisa.Text = string.Empty;
            InicializarListaDePersonagens();
        }
        private void LimparFiltro()
        {
            filtro.Nome = null;
            filtro.EstaVivo = null;
            filtro.DataDoCadastro = null;
            filtro.Id = null;
        }

        private void AoClicarNoBotaoRemoverDevePedirConfirmacaoERemoverPersonagemSelecionado(object sender, EventArgs e)
        {
            var idDaLinhaSelecionadaNoDataGridView = dataGridView1.CurrentCell.RowIndex;
            var valorDaColunaRespectivaAoId = 0;
            var idDoPersonagemSelecionado = int.Parse(dataGridView1.Rows[idDaLinhaSelecionadaNoDataGridView]
                                                .Cells[valorDaColunaRespectivaAoId].Value
                                                .ToString());
            var retornoDaConfirmacaoDoUsuario = MessageBox.Show("Tem certeza que quer remover o personagem selecionado?", "Confirme sua escolha",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(retornoDaConfirmacaoDoUsuario == DialogResult.Yes) _servicoPersonagem.Deletar(idDoPersonagemSelecionado);
            LimparFiltro();
            InicializarListaDePersonagens();
        }
    }
}
