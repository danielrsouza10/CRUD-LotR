namespace Servico.CustomExceptions
{
    public class PersonagemCustomExceptions : Exception
    {
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Instance { get; set; }

        public PersonagemCustomExceptions(string instance)
        {
            Title = "Exceção de Personagem";
            Detail = "Ocorreu um erro inesperado ao tentar obter o personagem.";
            Type = "personagem-custom-exception";
            Instance = instance;
        }
    }
}
