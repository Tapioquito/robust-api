using MediatR;
using System.Diagnostics;

namespace VemdeZap.Domain.Commands.User.UserAdd.Notifications
{
    public class SendUserActivationEmail : INotificationHandler<UserAddNotification>
    {
        public async Task Handle(UserAddNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Enviar e-mail de ativação para usuário" + notification.User.FirstName);
        }
    }
}
