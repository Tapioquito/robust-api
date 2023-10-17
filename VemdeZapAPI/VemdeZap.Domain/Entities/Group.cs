using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Commands.Group.GroupUpdate;
using VemdeZap.Domain.Entities.Enums;

namespace VemdeZap.Domain.Entities
{
    public class Group : BaseEntity
    {
        public Group(string name, EnumTypes type, User user)
        {
            Name = name;
            Type = type;
            User = user;
            if (user == null)
            {
                AddNotification("User", "Informe o usuário");
            }
            new AddNotifications<Group>(this)
                .IfNullOrInvalidLength(x => x.Name, 3, 50, "O nome deve ter entre 3 e 50 caracteres")
                .IfEnumInvalid(x => x.Type, "Informe um tipo válido");
        }
        public void UpdateGroup(string name, EnumTypes type)
        {
            Name = name;
            Type = type;
        }
        protected Group()
        {

        }
        public string Name { get; set; }
        public EnumTypes Type { get; set; }
        public User User { get; set; }


    }
}
