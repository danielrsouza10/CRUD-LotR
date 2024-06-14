using Dominio.ENUMS;
using Dominio.Filtros;
using Dominio.Modelos;
using Dominio.Validacao;
using Servico.Servicos;
using System.ComponentModel;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly ServicoPersonagem _servicoPersonagem;
        Filtro filtro = new Filtro();

        public MainForm(ServicoPersonagem servicoPersonagem)
        {
            _servicoPersonagem = servicoPersonagem;
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
        private void barraDePesquisa_TextChanged(object sender, EventArgs e)
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
        private void barraDePesquisa_Enter(object sender, EventArgs e)
        {
            barraDePesquisa.PlaceholderText = string.Empty;
        }
        private void barraDePesquisa_Leave(object sender, EventArgs e)
        {
            barraDePesquisa.PlaceholderText = "Pesquise o personagem...";
        }
        private void vivoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LimparFiltro();
            barraDePesquisa.Text = string.Empty;
            filtro.EstaVivo = vivoCheckBox.Checked;
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            filtro.DataDoCadastro = dateTimePicker.Value;
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }
        private void nomeRadioButton_CheckedChanged(object sender, EventArgs e)
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
    }
}
