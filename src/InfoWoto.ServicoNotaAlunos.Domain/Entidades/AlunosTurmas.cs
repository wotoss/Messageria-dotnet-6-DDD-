
namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;

    public class AlunosTurmas
    {
        public AlunosTurmas(int alunoId, int turmaId, DateTime dataCadastro)
                           
        {
           AlunoId = alunoId;
           TurmaId = turmaId;
           DataCadastro = dataCadastro;
           Turmas = new List<Turma>();
           Alunos = new List<Aluno>();
        }
        //relacionameto de (muitos para muitos)
        //um aluno tem várias turmas
        public int AlunoId { get; set; }
        
        //relacionameto de (muitos para muitos)
        //e uma turmas tem varios alunos
        public  int TurmaId { get; set; }

        public DateTime DataCadastro { get; set; }

        //relacionamento
        public ICollection<Turma> Turmas { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    
}