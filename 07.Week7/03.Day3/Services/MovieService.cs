using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _repository.GetAll();
        }

        public Movie Details(int id)
        {
            return _repository.Details(id);
        }

        public void Create(Movie movie)
        {
            _repository.Create(movie);
        }

        public void Edit(Movie movie)
        {
            _repository.Edit(movie);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
