using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;

namespace InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;


    //esta classe vai representar o (contrato do serviço de dominio)
    public interface IServicoValidacaoNotaAluno
    {    
         void ValidarLancamento(Aluno aluno, Professor professor, Disciplina disciplina);
         void ValidarLancamento(ServicoNotaValidacaoRequest request);
    }