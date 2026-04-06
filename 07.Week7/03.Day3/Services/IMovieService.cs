using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
       Movie Details(int id);
        void Create(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
    }
}
