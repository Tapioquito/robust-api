using MediatR;


namespace VemdeZap.Domain.Commands.User.UserAdd
{
    public class UserAddNotification : INotification
    {

        public UserAddNotification(Entities.User user)
        {
            User = user;
        }
        public Entities.User User { get; set; }

    }
}
