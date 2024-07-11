using mvc_Identity.Enums;

namespace mvc_Identity.Models
{
    public class Movie : Base
    {
        public string Title { get; set; }
        public GenreEnum Genre { get; set; }
        public LanguageEnum Language { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
    }
}
