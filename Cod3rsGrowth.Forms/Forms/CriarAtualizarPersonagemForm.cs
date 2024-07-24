using Dominio.ENUMS;
using Dominio.Filtros;
using Dominio.Modelos;
using Servico.Servicos;

namespace Forms.Forms
{
    public partial class CriarAtualizarPersonagemForm : Form
    {
        private readonly ServicoPersonagem _servicoPersonagem;
        private readonly ServicoRaca _servicoRaca;
        private readonly int _id;
        private readonly Filtro _filtro = new Filtro();
        private readonly Personagem _personagem = new Personagem();

        public CriarAtualizarPersonagemForm(ServicoPersonagem servicoPersonagem, ServicoRaca servicoRaca, int? id = null)
        {
            _servicoPersonagem = servicoPersonagem;
            _servicoRaca = servicoRaca;
            int ID_EM_CASO_DE_NULL = 0;
            _id = id ?? ID_EM_CASO_DE_NULL;
            _personagem = _servicoPersonagem.ObterPorId(_id);
            InitializeComponent();
        }
        public void CriacaoPersonagem_Load(object sender, EventArgs e)
        {
            if (_personagem == null)
            {
                ApresentarTelaParaCriacao();
                return;
            }
            ApresentarTelaParaEdicao();
        }
        private void AoClicarNoBotaoCancelarDeveFecharAJanelaDeCriacao(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AoClicarNoBotaoCriarOuAtualizar(object sender, EventArgs e)
        {
            var MENSAGEM_ERRO_PERSONAGEM_MESMO_NOME = "Já existe um personagem com esse nome cadastrado.";
            string TITULO_ERRO = "Erro";
            char QUEBRA_DE_LINHA = '\n';
            if (_personagem == null)
            {
                try
                {
                    CriarPersonagem();
                    this.Close();
                }
                catch (Microsoft.Data.SqlClient.SqlException)
                {
                    MessageBox.Show(MENSAGEM_ERRO_PERSONAGEM_MESMO_NOME, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FluentValidation.ValidationException vleex)
                {
                    string MENSAGEM_ERRO_FLUENT_VALIDATION = string.Join(QUEBRA_DE_LINHA, vleex.Errors.Select(e => e.ErrorMessage));
                    MessageBox.Show(MENSAGEM_ERRO_FLUENT_VALIDATION, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            try
            {
                EditarPersonagem();
                this.Close();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                MessageBox.Show(MENSAGEM_ERRO_PERSONAGEM_MESMO_NOME, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FluentValidation.ValidationException vleex)
            {
                string MENSAGEM_ERRO_FLUENT_VALIDATION = string.Join(QUEBRA_DE_LINHA, vleex.Errors.Select(e => e.ErrorMessage));
                MessageBox.Show(MENSAGEM_ERRO_FLUENT_VALIDATION, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ApresentarTelaParaCriacao()
        {
            this.Text = "Criar Personagem";
            buttonCriar.Text = "Criar";
            boxRacas.DataSource = _servicoRaca.ObterTodos(_filtro);
            boxRacas.DisplayMember = "Nome";
            boxProfissao.DataSource = Enum.GetValues(typeof(ProfissaoEnum));
        }
        private void ApresentarTelaParaEdicao()
        {
            this.Text = "Editar Personagem";
            buttonCriar.Text = "Atualizar";
            boxRacas.DataSource = _servicoRaca.ObterTodos(_filtro);
            boxRacas.DisplayMember = "Nome";
            BuscarDadosDoPersonagemSelecionado();
        }
        private void BuscarDadosDoPersonagemSelecionado()
        {
            var DECREMENTO_PARA_ACESSAR_INDEX_RACA = 1;
            boxNome.Text = _personagem.Nome;
            boxRacas.SelectedIndex = _personagem.IdRaca - DECREMENTO_PARA_ACESSAR_INDEX_RACA;
            boxProfissao.DataSource = Enum.GetValues(typeof(ProfissaoEnum));
            boxProfissao.SelectedIndex = (int)(_personagem.Profissao);
            boxAltura.Value = (decimal)_personagem.Altura;
            boxIdade.Value = (int)_personagem.Idade;
            radioButtonSim.Checked = _personagem.EstaVivo;
            radioButtonNao.Checked = !_personagem.EstaVivo;
        }
        public void CriarPersonagem()
        {
            Personagem novoPersonagem = new Personagem();
            novoPersonagem.Nome = boxNome.Text;
            _filtro.NomeDoPersonagem = boxRacas.Text;
            novoPersonagem.IdRaca = _servicoRaca.ObterTodos(_filtro).FirstOrDefault(r => r.Nome == _filtro.NomeDaRaca).Id;
            novoPersonagem.Profissao = (ProfissaoEnum)Enum.Parse(typeof(ProfissaoEnum), boxProfissao.Text);
            novoPersonagem.Altura = (float)boxAltura.Value;
            novoPersonagem.Idade = (int)boxIdade.Value;
            novoPersonagem.EstaVivo = radioButtonSim.Checked;
            _servicoPersonagem.Criar(novoPersonagem);
        }
        public void EditarPersonagem()
        {
            _personagem.Nome = boxNome.Text;
            _filtro.NomeDaRaca = boxRacas.Text;
            _personagem.IdRaca = _servicoRaca.ObterTodos(_filtro).FirstOrDefault(r => r.Nome == _filtro.NomeDaRaca).Id;
            _personagem.Profissao = (ProfissaoEnum)Enum.Parse(typeof(ProfissaoEnum), boxProfissao.Text);
            _personagem.Altura = (float)boxAltura.Value;
            _personagem.Idade = (int)boxIdade.Value;
            _personagem.EstaVivo = radioButtonSim.Checked;
            _servicoPersonagem.Editar(_personagem);
        }
    }
}
