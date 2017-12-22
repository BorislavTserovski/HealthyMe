using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Web.Areas.Writer.Models.Articles
{
    public class PublishArticleFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public byte[] Image { get; set; }
    }
}