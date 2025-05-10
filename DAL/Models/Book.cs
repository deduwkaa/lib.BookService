using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Book
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]

        public string Description { get; set; }

        [Column("publication_year")]

        public int PublicationYear { get; set; }

        [Column("file_url")]
        public string FileUrl { get; set; }

        [Column("author")]

        public string Author { get; set; }

        [Column("genre")]
        public string Genre { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
