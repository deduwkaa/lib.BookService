using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int PublicationYear { get; set; }

        public string FileUrl { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
