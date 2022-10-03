using Microsoft.AspNetCore.Mvc;
using Movie_Rental.Models;
using System.Data.Entity;
using Movie_Rental.ViewModels;

namespace Movie_Rental.Controllers
{
    public class MoviesController : Controller
    {
        private Movie_RentalDB_Content _content;

        public MoviesController()
        {
            _content = new Movie_RentalDB_Content();
        }

        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }

        public IActionResult Index()
        {
            var movies = _content.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        [Route("movies/MovieForm/{id}")]
        public IActionResult MovieForm(int id)
        {
            var movie= _content.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                movie = new Movie
                {
                    Id = 0
                };
            }

            var viewModel = new ViewMovieForm
            {
                Movie = movie,
                Genres = _content.Genre.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _content.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _content.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = movie.DateAdded;
            }
            _content.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }
}
