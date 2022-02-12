using System;


namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;
    //lembrando que ao herdar a (classe Entidade) estamos herdando o (Id)
    public class Nota : Entidade
    {
        //(2º passo )
        //como colcamos as propriedades como privados, só podemos ter acesso através do construtor
        public Nota(int alunoId, int atividadeId, double valorNota, DateTime dataLancamento)
        {
           AlunoId = alunoId;
           AtividadeId = atividadeId;
           ValorNota = valorNota;
           DataLancamento = dataLancamento;
        }
        
        //(3º passo )
        //entity vai precisar de um (construtor vazio) para fazer a manipulação dos dados.
        protected Nota() { }
        
        //(1º passo)
        //vamos trabalhar com atributos privados para ajudar no encapsulamento
        //se eu quiser mudar o nome do usuario eu preciso ter um método que mude a propriedade.
        //Caso precise alterar usaremos (EdHook) métodos que alteram alguma propriedade.
        //relacionamento entre aluno e nota.
        public int AlunoId { get; private set; }
        
        //relacionamento entre atividade e nota.
        public int AtividadeId { get; private set; }

        public double ValorNota { get; private set; }

        public DateTime DataLancamento { get; private set; }
        
        //relacionamento entre Usuario e nota.
        //este será (usuario Sistemico).
        public int UsuarioId { get; private set; }

        public bool CanceladaPorRetentativa { get; private set; }

        //relacionamento
        //nota pertence a um aluno
        public Aluno Aluno { get; set; }
        
        //nota pertence a atividade
        public Atividade Atividade { get; set; }

    }
