using InfoWoto.ServicoNotaAlunos.Domain.Messages;

namespace InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;


    //esta classe vai representar o (contrato do serviço de dominio)
    public interface IServicoNotaAluno
    {
        //este é o meu contrato, será implementando => ServicoNotaAluno
         Task LancarNota(RegistrarNotaAluno registrarNotaAluno);
    }
