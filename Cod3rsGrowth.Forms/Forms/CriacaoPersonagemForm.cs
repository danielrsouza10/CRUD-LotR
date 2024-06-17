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

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCriar_Click(object sender, EventArgs e)
        {
            var personagem = new Personagem();
            personagem.Nome = textBoxNome.Text;
            filtro.Nome = boxRacas.Text;
            personagem.IdRaca = _servicoRaca.ObterTodos(filtro).FirstOrDefault(r => r.Nome == filtro.Nome).Id;
            personagem.Profissao = (ProfissaoEnum)Enum.Parse(typeof(ProfissaoEnum), boxProfissao.Text);
            personagem.Altura = 1;
            personagem.Idade = 1;

            _servicoPersonagem.Criar(personagem);
        }

        
    }
}
