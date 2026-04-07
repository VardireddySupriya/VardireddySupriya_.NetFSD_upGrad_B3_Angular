using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        void Add(Products product);
        void Update(Products product);
        void Delete(int  id);
    }
}
