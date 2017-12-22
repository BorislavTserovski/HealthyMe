using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}