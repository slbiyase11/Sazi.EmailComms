using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.Repository
{
    public interface IGenericRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : class
    {
    }
}
