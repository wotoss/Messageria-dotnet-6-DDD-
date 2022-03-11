
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;


namespace InfoWoto.ServicoNotaAlunos.Domain.Services;

public class ServicoValidacaoNotaAluno : IServicoValidacaoNotaAluno
{
     private void ValidarProfessor(Professor professor)
     {
         throw new NotImplementedException();
     }
      private void ValidarDisciplina(Disciplina disciplina)
     {
         throw new NotImplementedException();
     }
      private void ValidarAluno(Aluno aluno)
     {
         throw new NotImplementedException();
     }
     public void ValidarLancamento(Aluno aluno, Professor professor, Disciplina disciplina)
     {
         ValidarDisciplina(disciplina);
         ValidarProfessor(professor);
         ValidarAluno(aluno);
     }

 
}