using prmToolkit.NotificationPattern;

namespace VemdeZap.Domain.Commands
{
    public class Response
    {
        public Response(INotifiable notifiable)
        {
            Success = notifiable.IsValid();
            Notifications = notifiable.Notifications;
        }

        public Response(INotifiable notifiable, object data)
        {
            Notifications = notifiable.Notifications;
            Success = notifiable.IsValid();
            Data = data;
        }

        public IEnumerable<Notification> Notifications { get; set; } //Coleção de notificações acaso não haja sucesso da requisição

        public bool Success { get; private set; } //Se foi executado com sucesso ou não
        public object Data { get; private set; } // toda resposta será jogada neste objeto
    }
}
