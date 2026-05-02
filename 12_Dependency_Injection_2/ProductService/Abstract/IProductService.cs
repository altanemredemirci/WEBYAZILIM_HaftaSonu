using _12_Dependency_Injection_2.Models;
using System.Linq.Expressions;

namespace _12_Dependency_Injection_2.ProductService.Abstract
{
    public interface IProductService
    {
        void Create(Product p);
        void Update();
        void Delete(Product p);
        List<Product> List();
        List<Product> List(Expression<Func<Product,bool>> filter);
        Product Find(int id);
    }
}

