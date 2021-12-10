using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.Repository
{
    public interface IQueryRepository<T>
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> query);
    }
}
