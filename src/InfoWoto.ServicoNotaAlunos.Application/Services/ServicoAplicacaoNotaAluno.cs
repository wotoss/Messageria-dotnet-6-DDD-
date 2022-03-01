using InfoWoto.ServicoNotaAlunos.Application.Interfaces;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Messages;

namespace InfoWoto.ServicoNotaAlunos.Application.Services;

    public class ServicoAplicacaoNotaAluno : IServicoAplicacaoNotaAluno
    {

       private readonly IServicoNotaAluno _servicoNotaAluno;

       public ServicoAplicacaoNotaAluno(IServicoNotaAluno servicoNotaAluno)
       {
           _servicoNotaAluno = servicoNotaAluno;
       }
    
       public async Task ProcessarLancamentoNota(RegistrarNotaAluno registrarNotaAluno)
       {
           Console.WriteLine("Orquestrando o fluxo da aplicação");
          await _servicoNotaAluno.LancarNota(registrarNotaAluno);
       }
    }
