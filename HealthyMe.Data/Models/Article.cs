using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public byte[] Image { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}