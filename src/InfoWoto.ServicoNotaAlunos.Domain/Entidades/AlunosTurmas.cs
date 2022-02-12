using System;
using System.Collections.Generic;
namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;

    public class AlunosTurmas
    {
        public AlunosTurmas(int alunoId, int turmoId, DateTime dataCadastro)
                           
        {
           AlunoId = alunoId;
           TurmoId = turmoId;
           DataCadastro = dataCadastro;
           Turmas = new List<Turma>();
           Alunos = new List<Aluno>();
        }
        //relacionameto de (muitos para muitos)
        //um aluno tem várias turmas
        public int AlunoId { get; set; }
        
        //relacionameto de (muitos para muitos)
        //e uma turmas tem varios alunos
        public  int TurmoId { get; set; }

        public DateTime DataCadastro { get; set; }

        //relacionamento
        public ICollection<Turma> Turmas { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    
}