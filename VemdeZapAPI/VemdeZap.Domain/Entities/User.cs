using prmToolkit.NotificationPattern;
using VemdeZap.Domain.Extensions;

namespace VemdeZap.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User()
        {
            
        }
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            new AddNotifications<User>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 3, 50, "O nome deve ter entre 3 e 50 caracteres")
                .IfNullOrInvalidLength(x => x.LastName, 3, 50, "O sobrenome deve ter entre 3 e 50 caracteres")
                .IfNotEmail(x => x.Email, "Informe um e-mail válido")
                .IfNullOrInvalidLength(x => x.Password, 3, 8, "A senha deve ter entre 3 e 8 caracteres");
            if (!string.IsNullOrEmpty(Password)) Password = Password.ConvertToMD5();
            RegisterDate = DateTime.Now;
            isActive = false;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public bool isActive { get; private set; }

    }
}
