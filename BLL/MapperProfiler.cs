using BLL.Abstractions;
using BLL.DTO;
using DAL.Models;

namespace BLL;

public class MapperProfiler : IMapperProfiler
{
    public Book Map(BookDTO bookDTO)
    {
        var tempBook = new Book();
        tempBook.Id = bookDTO.Id;
        tempBook.CreatedAt = bookDTO.CreatedAt;
        tempBook.Title = bookDTO.Title;
        tempBook.Author = bookDTO.Author;
        tempBook.Description = bookDTO.Description;
        tempBook.FileUrl = bookDTO.FileUrl;
        tempBook.Genre = bookDTO.Genre;
        tempBook.PublicationYear = bookDTO.PublicationYear;

        return tempBook;
    }

    public BookDTO Map(Book book)
    {
        var tempBook = new BookDTO();
        tempBook.Id = book.Id;
        tempBook.CreatedAt = book.CreatedAt;
        tempBook.Title= book.Title;
        tempBook.Author = book.Author;
        tempBook.Description = book.Description;
        tempBook.FileUrl = book.FileUrl;
        tempBook.Genre = book.Genre;
        tempBook.PublicationYear = book.PublicationYear;

        return tempBook;
    }

    public ICollection<BookDTO> Map(ICollection<Book> books)
    {
        var bookDTOs = new List<BookDTO>();

        foreach (var book in books)
        {
            var tempBook = new BookDTO();
            tempBook.Id = book.Id;
            tempBook.Title = book.Title;
            tempBook.CreatedAt = book.CreatedAt;
            tempBook.Author = book.Author;
            tempBook.Description = book.Description;
            tempBook.FileUrl = book.FileUrl;
            tempBook.Genre = book.Genre;
            tempBook.PublicationYear = book.PublicationYear;

             bookDTOs.Add(tempBook);
        }
        return bookDTOs;
    }
    public ICollection<Book> Map(ICollection<BookDTO> bookDTOs)
    {
        var books = new List<Book>();

        foreach (var book in bookDTOs)
        {
            var tempBook = new Book();
            tempBook.Id = book.Id;
            tempBook.Title = book.Title;
            tempBook.CreatedAt = book.CreatedAt;
            tempBook.Author = book.Author;
            tempBook.Description = book.Description;
            tempBook.FileUrl = book.FileUrl;
            tempBook.Genre = book.Genre;
            tempBook.PublicationYear = book.PublicationYear;

            books.Add(tempBook);
        }

        return books;
    }
}