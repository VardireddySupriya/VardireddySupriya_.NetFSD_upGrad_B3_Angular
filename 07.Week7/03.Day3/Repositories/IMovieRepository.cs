using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie Details(int id);
        void Create(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
    }
}
