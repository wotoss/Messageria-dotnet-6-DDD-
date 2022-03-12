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

        public static class MensagensValidacao
        {
            public const string ALUNO_INATIVO = "O aluno não está ativo para receber notas";
            public const string ALUNO_NAO_ESTA_MATRICULADO = "O aluno não está matriculado na disciplina para receber nota em uma atividade";

            public const string PROFESSOR_INATIVO = "O professor não esta ativo para lançar notas";

            public const string PROFESSOR_NAO_MINISTRA_A_DISCIPLINA = "O professor não ministra a disciplina para lançar nota";

            public const string PROFESSOR_DEVE_SER_TITULAR = "O professor para lançar notas deve ser titular da disciplina";

            public  const string DISCIPLINA_TIPO_ENCONTRO = "Uma disciplina do tipo encontro não pode receber notas";

            public  const string DISCIPLINA_INATIVA = "A disciplina está fora do periodo de lançamentos de notas";
        }


        /*
        public static class MensagensValidacao
          {
        public const string ALUNO_INATIVO = "O aluno não está ativo para receber notas";
        public const string ALUNO_NAO_ESTA_MATRICULADO = "O aluno não está matriculado na disciplina para receber nota em uma atividade";
        public const string PROFESSOR_INATIVO = "O professor não está ativo para lançar notas";
        public const string PROFESSOR_NAO_MINISTRA_A_DISCIPLINA = "O professor não ministra a disciplina para lançar nota";
        public const string PROFESSOR_DEVE_SER_TITULAR = "O professor para lançar notas deve ser titular da disciplina";
        public const string DISCIPLINA_TIPO_ENCONTRO = "Uma disciplina do tipo encontro não pode recber notas";
        public const string DISCIPLINA_INATIVA = "A disciplina está fora do periodo de lançamentos de notas";
          }
        */

        
    }
    
