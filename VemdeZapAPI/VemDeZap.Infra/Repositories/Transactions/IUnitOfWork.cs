using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VemDeZap.Infra.Repositories.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
