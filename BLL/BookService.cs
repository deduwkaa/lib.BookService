using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace BLL
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapperProfiler _mapper;

        public BookService(IMapperProfiler mapper, IBookRepository repository)
        {
            _bookRepository = repository;
            _mapper = mapper;
        }

        public async Task AddBook(BookDTO book)
        {
            await _bookRepository.Create(_mapper.Map(book)).ConfigureAwait(false);
        }
        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.Get().ConfigureAwait(false);
            var BookDTOs = _mapper.Map(books);

            return BookDTOs;
        }
        public async Task<BookDTO> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map(book);
            return dto;
        }
        public async Task<TokenInfoDTO> CheckLogin(string Email, string Password)
        {
            Expression<Func<Book, bool>> filter = x => x.Email == Email;
            var result = await _bookRepository.Get(filter);
            var book = _mapper.Map(result.FirstOrDefault());
            if (book == null)
            {
                return new TokenInfoDTO(Guid.Empty, null);
            }
            else if (book.Password != Password)
            {
                return new TokenInfoDTO(Guid.Empty, null);
            }
            else
            {
                var token = AuthService.GenerateJSONWebToken(_config, book);
                return new TokenInfoDTO(book.Id, token);
            }
        }
        public async Task UpdateBook(BookDTO book)
        {
            await _bookRepository.Update(_mapper.Map(book)).ConfigureAwait(false);
        }
    }
}
