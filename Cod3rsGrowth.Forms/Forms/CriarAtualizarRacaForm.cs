using Dominio.Modelos;
using Servico.Servicos;

namespace Forms.Forms
{
    public partial class CriarAtualizarRacaForm : Form
    {
        private readonly ServicoRaca _servicoRaca;
        private readonly int _id;
        private readonly Raca _raca = new Raca();

        public CriarAtualizarRacaForm(ServicoRaca servicoRaca, int? id = null)
        {
            _servicoRaca = servicoRaca;
            InitializeComponent();
            int ID_EM_CASO_DE_NULL = 0;
            _id = id ?? ID_EM_CASO_DE_NULL;
            _raca = _servicoRaca.ObterPorId(_id);
        }
        private void CriacaoRacaForm_Load(object sender, EventArgs e)
        {
            if (_raca == null)
            {
                ApresentarTelaParaCriacao();
                return;
            }
            ApresentarTelaParaEdicao();
        }
        private void AoClicarNoBotaoCriarOuAtualizar(object sender, EventArgs e)
        {
            var MENSAGEM_ERRO_RACA_MESMO_NOME = "Já existe uma raça com esse nome cadastrado.";
            var TITULO_ERRO = "Erro";
            if (_raca == null)
            {
                try
                {
                    CriarRaca();
                    this.Close();
                }
                catch (Microsoft.Data.SqlClient.SqlException)
                {
                    MessageBox.Show(MENSAGEM_ERRO_RACA_MESMO_NOME, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FluentValidation.ValidationException vleex)
                {
                    string MENSAGEM_ERRO_FLUENT_VALIDATION = string.Join('\n', vleex.Errors.Select(e => e.ErrorMessage));
                    MessageBox.Show(MENSAGEM_ERRO_FLUENT_VALIDATION, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            try
            {
                EditarRaca();
                this.Close();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                MessageBox.Show(MENSAGEM_ERRO_RACA_MESMO_NOME, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FluentValidation.ValidationException vleex)
            {
                string MENSAGEM_ERRO_FLUENT_VALIDATION = string.Join('\n', vleex.Errors.Select(e => e.ErrorMessage));
                MessageBox.Show(MENSAGEM_ERRO_FLUENT_VALIDATION, TITULO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AoClicarNoBotaoCancelarDeveFecharACaixaDeDialogo(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ApresentarTelaParaCriacao()
        {
            this.Text = "Criar Raca";
            criarButton.Text = "Criar";
            naoRadioButton.Checked = true;
        }
        private void ApresentarTelaParaEdicao()
        {
            this.Text = "Editar Raça";
            criarButton.Text = "Atualizar";
            BuscarDadosDaRacaSelecionada();
        }
        private void BuscarDadosDaRacaSelecionada()
        {
            textBoxNome.Text = _raca.Nome;
            textBoxHabilidadeRacial.Text = _raca.HabilidadeRacial;
            textBoxLocalizacaoGeografica.Text = _raca.LocalizacaoGeografica;
            simRadioButton.Checked = _raca.EstaExtinta;
            naoRadioButton.Checked = !_raca.EstaExtinta;
        }
        private void CriarRaca()
        {
            var novaRaca = new Raca();
            novaRaca.Nome = textBoxNome.Text;
            novaRaca.HabilidadeRacial = textBoxHabilidadeRacial.Text;
            novaRaca.LocalizacaoGeografica = textBoxLocalizacaoGeografica.Text;
            novaRaca.EstaExtinta = simRadioButton.Checked;
            _servicoRaca.Criar(novaRaca);
        }
        private void EditarRaca()
        {
            _raca.Nome = textBoxNome.Text;
            _raca.HabilidadeRacial = textBoxHabilidadeRacial.Text;
            _raca.LocalizacaoGeografica = textBoxLocalizacaoGeografica.Text;
            _raca.EstaExtinta = simRadioButton.Checked;
            _servicoRaca.Editar(_raca);
        }
    }
}
