using System.Collections;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Collections.ObjectModel;

namespace InfoWoto.ServicoNotaAlunos.Domain.Notification;

//IReadOnlyCollection<string> => será uma coleção de leitura.
public class ContextoNotificacao : IReadOnlyCollection<string>
{
   private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
   {
      Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
   };
   //crio uma coleção que ela é privada
   private readonly Collection<string> _notificacoes = new Collection<string>();
   
   //faço uma consulta se tem notificações => HasNotifications (TemNotificacoes)
   public bool TemNotificacoes => _notificacoes.Any();

   //se eu quiser saber quantas notificações tem lá dentro eu uso a propriedade (Count)
   public int Count => _notificacoes.Count;

   //se eu quiser adiconar uma notificaçao eu uso este método (Add)
   public void Add(string notificacao) => _notificacoes.Add(notificacao);

   public IEnumerator<string> GetEnumerator() => _notificacoes.GetEnumerator();

   IEnumerator IEnumerable.GetEnumerator() => _notificacoes.GetEnumerator();

   //este (AddRange) => seria para adicionar varias notificações de um a vez só
   public void AddRange(IEnumerable<string> notifications)
   {
       foreach (var i in _notificacoes)
       {
           _notificacoes.Add(i);
       }
   }

    //quando eu precisar pegar todas as minhas notificações ele vai serializar e me devolver um Json.
       public string ToJson()
       {
           return JsonSerializer.Serialize(_notificacoes, _jsonSerializerOptions);
       }

    
}

