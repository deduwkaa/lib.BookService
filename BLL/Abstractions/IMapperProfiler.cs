using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Models;

namespace BLL.Abstractions
{
    public interface IMapperProfiler
    {
        public Book Map(BookDTO bookDTO);
        public BookDTO Map(Book book);
        public ICollection<Book> Map(ICollection<BookDTO> bookDTOs);
        public ICollection<BookDTO> Map(ICollection<Book> books);
    }
}
