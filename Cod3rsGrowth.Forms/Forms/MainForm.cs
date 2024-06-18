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
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoSelecionarUmaDataDeveAdicionarOValorAoFiltro(object sender, EventArgs e)
        {
            filtro.DataDoCadastro = dateTimePicker.Value;
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void AoAlterarASelecaoDoImputRadioDeNomeDeveAtualizarALista(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisa.Text = string.Empty;
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void LimparFiltro()
        {
            filtro.Nome = null;
            filtro.EstaVivo = null;
            filtro.DataDoCadastro = null;
            filtro.Id = null;
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
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
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
    }
}
