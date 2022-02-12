
using System;
using System.Collections.Generic;
using InfoWoto.ServicoNotaAlunos.Domain.Enums;
namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;

    public class Turma : Entidade
    {
        public Turma(string nome, Periodo periodo,  DateTime dataInicio, DateTime dataFinal,
                     DateTime dataCadastro, int disciplinaId)
        {
            Nome = nome;
            Periodo = periodo;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
            DataCadastro = dataCadastro;
            DisciplinaId = disciplinaId;
            AlunosTurmas = new List<AlunosTurmas>();
        }

        protected Turma() { }

        public  string Nome { get; private set; }

        //estamos usando nesta propriedade a estratégia Enum 
        //nesta abordagem eu crio um enum Periodo
        //trago a refencia desta classe => using InfoWoto.ServicoNotaAlunos.Domain.Enums;
        //por fim no lugar do tipo exemplo string ou int  eu passo o (enum Periodo). 
        public Periodo Periodo { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFinal { get; private set; }

        public DateTime DataCadastro { get; private set; }
       
        //neste relacionamento a turma tem uma disciplina
        public int DisciplinaId { get; private set; }

        //relacionameto
        // definimos o relacionameto com disciplina (inclusive tem o id => DisciplinaId)
        public Disciplina Disciplina { get; private set; }
        
        //definimos o relacionamento com a tuma 
        public ICollection<AlunosTurmas> AlunosTurmas { get; private set; }
    }
