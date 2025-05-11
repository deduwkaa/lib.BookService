using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Abstractions;
using BLL.DTO;
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

        public async Task<ICollection<BookDTO>> GetBooksByGenre(string genre)
        {
            var books = await _bookRepository.Get(b => b.Genre == genre).ConfigureAwait(false);
            var BookDTOs = _mapper.Map(books);

            return BookDTOs;
        }
        public async Task<ICollection<BookDTO>> GetBooksByAuthor(string author)
        {
            var books = await _bookRepository.Get(b => b.Author == author).ConfigureAwait(false);
            var BookDTOs = _mapper.Map(books);

            return BookDTOs;
        }
        public async Task<ICollection<BookDTO>> GetBooksByYear(int year)
        {
            var books = await _bookRepository.Get(b => b.PublicationYear == year).ConfigureAwait(false);
            var BookDTOs = _mapper.Map(books);

            return BookDTOs;
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

        public async Task UpdateBook(BookDTO book)
        {
            await _bookRepository.Update(_mapper.Map(book)).ConfigureAwait(false);
        }
    }
}
