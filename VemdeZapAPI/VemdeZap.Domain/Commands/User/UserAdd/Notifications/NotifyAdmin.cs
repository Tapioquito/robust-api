using MediatR;
using System.Diagnostics;

namespace VemdeZap.Domain.Commands.User.UserAdd.Notifications
{
    public class NotifyAdmin : INotificationHandler<UserAddNotification>
    {
        public async Task Handle(UserAddNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Notificar Administrador" + notification.User.FirstName);
        }
    }
}
