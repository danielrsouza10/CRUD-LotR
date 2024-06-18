using Dominio.ENUMS;
using Dominio.Filtros;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Servico.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Define o valor default da profissao
            boxProfissao.SelectedIndex = 0;
            
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCriar_Click(object sender, EventArgs e)
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
                CaixaDeDialogoForm caixaDeDialogoForm = new CaixaDeDialogoForm(ex.Message);
                caixaDeDialogoForm.ShowDialog();
            }
        }
    }
}
