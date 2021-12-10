using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.Repository
{
    public interface ICommandRepository<T>
    {
        void Add(T item);
        void Add(IEnumerable<T> items);
       
        void Update(T item);

        void Update(IEnumerable<T> items);

        Task Save();

        Task Delete(Guid userId);
    }
}
