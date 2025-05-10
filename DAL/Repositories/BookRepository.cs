using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository

    {
    private readonly LibContext context;

    public BookRepository(LibContext context)
    {
        this.context = context;
    }

    public async Task<ICollection<Book>> Get(Expression<Func<Book, bool>> filter = null)
    {
        IQueryable<Book> list = context.Set<Book>();
        if (filter != null)
            return await list?.Where(filter).ToListAsync();
        else return await list?.ToListAsync();
    }

    public async Task Create(Book entity, string createBody = null)
    {
        context.Set<Book>().Add(entity);
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<Book> GetById(Guid id)
    {
        return await context.Set<Book>().FindAsync(id);
    }

    public async Task Update(Book entity, string updateBody = null)
    {
        context.Set<Book>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task Delete(Guid id)
    {
        Book entity = await context.Set<Book>().FindAsync(id).ConfigureAwait(false);
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
    }
}
