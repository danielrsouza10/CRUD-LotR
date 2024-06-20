using Dominio.ENUMS;
using Dominio.Filtros;
using Dominio.Modelos;
using Servico.Servicos;

namespace Forms.Forms
{
    public partial class CriacaoPersonagemForm : Form
    {
        private readonly ServicoPersonagem _servicoPersonagem;
        private readonly ServicoRaca _servicoRaca;
        Filtro filtro = new Filtro();

        public CriacaoPersonagemForm(ServicoPersonagem servicoPersonagem, ServicoRaca servicoRaca)
        {
            _servicoPersonagem = servicoPersonagem;
            _servicoRaca = servicoRaca;
            InitializeComponent();
        }
        public void CriacaoPersonagem_Load(object sender, EventArgs e)
        {
            boxRacas.DataSource = _servicoRaca.ObterTodos(filtro);
            boxRacas.DisplayMember = "Nome";
            boxProfissao.DataSource = Enum.GetValues(typeof(ProfissaoEnum)); 
        }
        private void AoClicarNoBotaoCancelarDeveFecharAJanelaDeCriacao(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AoClicarNoBotaoCriarDeveCriarUmPersonagemOuDispararUmaExcecao(object sender, EventArgs e)
        {
            try
            {
                var personagem = new Personagem();
                personagem.Nome = textBoxNome.Text;
                filtro.Nome = boxRacas.Text;
                personagem.IdRaca = _servicoRaca.ObterTodos(filtro).FirstOrDefault(r => r.Nome == filtro.Nome).Id;
                personagem.Profissao = (ProfissaoEnum)Enum.Parse(typeof(ProfissaoEnum), boxProfissao.Text);
                personagem.Altura = (int)boxAltura.Value;
                personagem.Idade = (int)boxIdade.Value;
                personagem.EstaVivo = radioButtonSim.Checked;

                _servicoPersonagem.Criar(personagem);
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
