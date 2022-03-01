using InfoWoto.ServicoNotaAlunos.Domain.Messages;

namespace InfoWoto.ServicoNotaAlunos.Application.Interfaces;

    public interface IServicoAplicacaoNotaAluno
    {
         Task ProcessarLancamentoNota(RegistrarNotaAluno registrarNotaAluno);
    }
