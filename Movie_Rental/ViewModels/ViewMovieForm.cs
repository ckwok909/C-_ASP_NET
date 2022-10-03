using Movie_Rental.Models;

namespace Movie_Rental.ViewModels
{
    public class ViewMovieForm
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}
