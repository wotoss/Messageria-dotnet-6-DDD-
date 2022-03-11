namespace InfoWoto.ServicoNotaAlunos.Domain.Excecoes;

 //DomainException esta herdando de Exception
 // => seria uma excessão personalizada com a ajuda da classe herdada Exception
public class DomainException : Exception
{
   public DomainException(string mensagem) : base (mensagem){}

   public DomainException(string mensagem, Exception excecao) : base(mensagem, excecao)
   {

   }
}