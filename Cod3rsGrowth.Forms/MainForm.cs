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
            Filtro filtro = new Filtro();
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            filtro.Nome = textBox1.Text;
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
