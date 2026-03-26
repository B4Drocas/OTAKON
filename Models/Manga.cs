using System.ComponentModel.DataAnnotations;

namespace OTAKode.Models
{
    public class Manga
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; } = 0;

        [Range(0.01, 999.99)]
        public decimal Price { get; set; }

        public int Chapters { get; set; } = 0;

        [StringLength(500)]
        public string CoverImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public int ViewCount { get; set; } = 0;
    }
}
