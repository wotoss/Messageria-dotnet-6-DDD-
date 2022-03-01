

using FluentValidation;
using InfoWoto.ServicoNotaAlunos.Domain.Messages;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations;

public class RegistrarNotaAlunoValidacao : AbstractValidator<RegistrarNotaAluno>
{

//esta propriedade foi feita para evitar de dar um new na classe
public static RegistrarNotaAlunoValidacao Instance => new RegistrarNotaAlunoValidacao();


//declarando desta forma pode ser usados em outros lugares e fica mensagem padrão ou static    
public static string AlunoIdMsgErro => "O id do aluno está inválido";
public static string ProfessorIdMsgErro => "O id do professor está inválido";

public static string AtividadeIdMsgErro => "O id do atividade está inválido";

public  static string CorrelationIdIdMsgErro => "O id da transação está inválido";

public static string ValorNotaMsgErro => "O valor da nota não pode ser inferior a zero";

 public RegistrarNotaAlunoValidacao()
 {
    //regra para => AlunoId
     RuleFor(x => x.AlunoId)
     //maior que default(int) o nosso default do id é zero
           .GreaterThan(default(int))
           .WithMessage(AlunoIdMsgErro);

     RuleFor(x => x.ProfessorId)
            .GreaterThan(default(int))
            .WithMessage(ProfessorIdMsgErro);  

     RuleFor(x => x.AtividadeId)
            .GreaterThan(default(int)) 
            .WithMessage(AtividadeIdMsgErro);  

     RuleFor(x => x.CorrelationId)
            .NotNull()
            .WithMessage(CorrelationIdIdMsgErro)
            .NotEqual(Guid.Empty)
            .WithMessage(CorrelationIdIdMsgErro);  

    RuleFor(x => x.ValorNota)
            .GreaterThanOrEqualTo(default(int))
            .WithMessage(ValorNotaMsgErro);            
  }
}