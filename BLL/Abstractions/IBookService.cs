using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IBookService
    {
        public Task UpdateBook(BookDTO book);
        public Task<BookDTO> GetBookById(Guid id);
        public Task<ICollection<BookDTO>> GetAllBooks();
        public Task<ICollection<BookDTO>> GetBooksByYear(int year);
        public Task<ICollection<BookDTO>> GetBooksByAuthor(string author);
        public Task<ICollection<BookDTO>> GetBooksByGenre(string genre);
        public Task DeleteBook(Guid id);
        public Task AddBook(BookDTO book);
    }
}
