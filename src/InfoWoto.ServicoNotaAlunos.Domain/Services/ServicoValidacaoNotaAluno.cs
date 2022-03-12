
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

namespace InfoWoto.ServicoNotaAlunos.Domain.Services;

public class ServicoValidacaoNotaAluno : IServicoValidacaoNotaAluno
{

    private readonly ContextoNotificacao _contextoNotificacao;

    public ServicoValidacaoNotaAluno(ContextoNotificacao contextoNotificacao)
    {
        _contextoNotificacao = contextoNotificacao;
    }
     private void ValidarProfessor(Professor professor, int disciplinaId)
     {
         // o professor deve ser um usuario ativo
         if(!professor.Usuario.Ativo)
           {
              _contextoNotificacao.Add(Constantes.MensagensValidacao.PROFESSOR_INATIVO);
              return;
           }
         
         //Professor deve ministrar a disciplina
         if(!(professor.DisciplinaId == disciplinaId))
         {
            _contextoNotificacao.Add(Constantes.MensagensValidacao.PROFESSOR_NAO_MINISTRA_A_DISCIPLINA);
            return;
         }

         //deve ser um professor titular e não suplente.
         if(!professor.ProfessorTitular && professor.ProfessorSuplente)
         {
             _contextoNotificacao.Add(Constantes.MensagensValidacao.PROFESSOR_DEVE_SER_TITULAR);
             return;
         }
     }
      private void ValidarDisciplina(Disciplina disciplina)
     {
         //A disciplina não pode ser do tipo encontro
         if(disciplina.TipoDisciplina == Enums.TipoDisciplina.Encontro)
         {
             _contextoNotificacao.Add(Constantes.MensagensValidacao.DISCIPLINA_TIPO_ENCONTRO);
             return;
         }

         //a disciplina deve estar ativa.
         if(!DisciplinaAtiva(disciplina))
         {
              _contextoNotificacao.Add(Constantes.MensagensValidacao.DISCIPLINA_INATIVA);
              return;
         }
     }
      private void ValidarAluno(Aluno aluno, int disciplinaId)
     {
        if(!aluno.Usuario.Ativo)
        {
            _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_INATIVO);
            return;
        }

        if(!AlunoEstaMatriculado(aluno, disciplinaId))
        {
            _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_NAO_ESTA_MATRICULADO);
            return;
        }
     }

     private bool DisciplinaAtiva(Disciplina disciplina) => 
          disciplina.DataInicio <= DateTime.Now && disciplina.DataFim >= DateTime.Now;

    private bool AlunoEstaMatriculado(Aluno aluno, int disciplinaId) =>
       aluno.AlunosTurmas
            .SelectMany(alunoTurma => alunoTurma.Turmas)
            .Any(turma => turma.DisciplinaId == disciplinaId);      
     public void ValidarLancamento(Aluno aluno, Professor professor, Disciplina disciplina)
     {
         ValidarAluno(aluno, disciplina.Id);
         ValidarProfessor(professor, disciplina.Id);
         ValidarDisciplina(disciplina);
        
         
     }

     public void ValidarLancamento(ServicoNotaValidacaoRequest request)
     {
         //uma forma (errada) de instanciar a classe sem injeção de dependencia
         //bom não bem errado, mas estmos fazendo um aclopamentos.
         var inicialHandler =  new AlunoValidacaoHandler(_contextoNotificacao);

         inicialHandler
         .SetNext(new ProfessorValidacaoHandler(_contextoNotificacao))
         .SetNext(new DisciplinaValidacaoHandler(_contextoNotificacao));

         inicialHandler.Handle(request);
     }

 
}