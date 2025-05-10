using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> Get(Expression<Func<Book, bool>> filter = null);
        Task<Book> GetById(Guid id);
        Task Create(Book entity, string createBody = null);
        Task Update(Book entity, string modifieBody = null);
        Task Delete(Guid id);
    }
}
