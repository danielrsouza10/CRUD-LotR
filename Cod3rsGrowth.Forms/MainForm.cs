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

        Filtro filtro = new Filtro();
        private void MainForm_Load(object sender, EventArgs e)
        {
            InicializarListaDePersonagens();
            dataGridView1.DataSource = _servicoPersonagem.ObterTodos(filtro);
        }

        BindingList<Personagem> listaDePersonagens = new ();
 
        
        private void InicializarListaDePersonagens()
        {
            listaDePersonagens = new BindingList<Personagem>();

            listaDePersonagens.AllowNew = true;

            listaDePersonagens.RaiseListChangedEvents = true;

           
            //listaDePersonagens.Add(new Personagem() { Nome = "Legolas", Profissao = ProfissaoEnum.Arqueiro });
        }
    }
}
