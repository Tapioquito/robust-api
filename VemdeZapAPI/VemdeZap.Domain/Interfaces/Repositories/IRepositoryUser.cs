using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VemdeZap.Domain.Entities;
using VemdeZap.Domain.Interfaces.Repositories.Base;

namespace VemdeZap.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User, Guid>
    {

    }
}
