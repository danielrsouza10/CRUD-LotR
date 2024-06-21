using Dominio.Modelos;
using Servico.Servicos;

namespace Forms.Forms
{
    public partial class CriacaoRacaForm : Form
    {
        private readonly ServicoRaca _servicoRaca;

        public CriacaoRacaForm(ServicoRaca servicoRaca)
        {
            _servicoRaca = servicoRaca;
            InitializeComponent();
        }
        private void AoClicarNoBotaoCriarDeveCriarUmaRacaOuDispararUmaExcecao(object sender, EventArgs e)
        {
            try
            {
                var raca = new Raca();
                raca.Nome = textBoxNome.Text;
                raca.HabilidadeRacial = textBoxHabilidadeRacial.Text;
                raca.LocalizacaoGeografica = textBoxLocalizacaoGeografica.Text;
                raca.EstaExtinta = simRadioButton.Checked;

                _servicoRaca.Criar(raca);
                this.Close();
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
    }
}
