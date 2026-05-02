using _12_Dependency_Injection_2.Models;
using _12_Dependency_Injection_2.ProductService.Abstract;
using System.Linq.Expressions;

namespace _12_Dependency_Injection_2.ProductService.Concrete
{
    public class MySqlProductService : IProductService
    {
        public void Create(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> List()
        {
            throw new NotImplementedException();
        }

        public List<Product> List(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
