using System.ComponentModel.DataAnnotations;


namespace FavoriteSongs.Models
{

    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please enter a artist.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string artist { get; set; }

        [Required(ErrorMessage = "Please enter a cost.")]
        [DataType(DataType.Currency)]
        [Range(0, 100, ErrorMessage = "Please enter the cost between 0 and 100")]
        public double cost { get; set; }

        public int yearRecorded { get; set; }
        public string? GenreId { get; set; } //foriegn key
        public Genre? Genre { get; set; }
    }
}
