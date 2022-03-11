namespace InfoWoto.ServicoNotaAlunos.Domain.Utils;

    //Constantes são mensagem ou numeros informações que não serão alteradas no sistema.
    public static class Constantes
    {
        //vamos iniciar as mensagens da aplicação.
        public static class MensagensAplicacao
        {
            //coloco o const e escrevo a msg em caixa alta ou letra MAISCULA => seguindo a convenção DOTNET
            public const string SEM_MENSAGEM_NA_FILA = "Não possuem mensagens a ser processadas na fila..";

            public const string INICANDO_SERVICO = "Iniciando o serviço de notas";
        }

        //vou montar mensagem de excessão
        public static class MensagensExcecao
        {
            public const string ALUNO_INEXISTENTE = "O aluno informado não existe";

            public const string PROFESSOR_INEXISTENTE = "O professor informado não exste";

            public const string DISCIPLINA_INEXISTENTE = "A atividade informada não possui uma disciplina";
        }
    }
    
