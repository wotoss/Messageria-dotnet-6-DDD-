using InfoWoto.ServicoNotaAlunos.Application.Interfaces;
using InfoWoto.ServicoNotaAlunos.Domain.Excecoes;
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
          try
          {
            Console.WriteLine("Orquestrando o fluxo da aplicação");
            await _servicoNotaAluno.LancarNota(registrarNotaAluno);
          }
          //esta excessão esta tratando a classe de Dominio
          catch(DomainException ex)
          {
              System.Console.WriteLine(ex.Message);
          }
          //esta excessão esta tratando o sistema 
          catch (Exception ex)
          {
              System.Console.WriteLine(ex.Message);
              //throw;
          }
          
       }
    }
