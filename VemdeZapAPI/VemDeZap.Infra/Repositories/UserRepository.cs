using Microsoft.EntityFrameworkCore;
using VemdeZap.Domain.Entities;
using VemdeZap.Domain.Interfaces.Repositories;
using VemDeZap.Infra.Repositories.Base;

namespace VemDeZap.Infra.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IRepositoryUser
    {
        private readonly VemDeZapContext _context;
        public UserRepository(VemDeZapContext context) : base(context)
        {
            _context = context;
        }
    }
}
