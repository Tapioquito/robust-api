using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VemdeZap.Domain.Entities;
using VemdeZap.Domain.Interfaces.Repositories;
using VemDeZap.Infra.Repositories.Base;

namespace VemDeZap.Infra.Repositories
{
    public class GroupRepository: BaseRepository<Group, Guid>, IRepositoryGroup
    {
        private readonly VemDeZapContext _context;

        public GroupRepository(VemDeZapContext context):base(context)
        {
            _context = context;
        }
    }
}
