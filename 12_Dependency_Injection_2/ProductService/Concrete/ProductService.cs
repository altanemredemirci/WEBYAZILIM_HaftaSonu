using _12_Dependency_Injection_2.Context;
using _12_Dependency_Injection_2.Models;
using _12_Dependency_Injection_2.ProductService.Abstract;
using System.Linq.Expressions;

namespace _12_Dependency_Injection_2.ProductService.Concrete
{
    public class ProductService : IProductService
    {

        //DataContext context = new DataContext();

        //public void Create(Product p)
        //{
        //    context.Products.Add(p);
        //    context.SaveChanges();
        //}

        public void Create(Product p)
        {
            using (var context = new DataContext())
            {
                context.Products.Add(p);
                context.SaveChanges();
            }
        }



        public void Delete(Product p)
        {
            using(var context = new DataContext())
            {
                context.Products.Remove(p);
                context.SaveChanges();
            }
        }

        public Product Find(int id)
        {
            using(var context = new DataContext())
            {
                var product = context.Products.Find(id);

                return product;
            }
        }

        public List<Product> List()
        {
            using(var context = new DataContext())
            {
                var products = context.Products.ToList();

                return products;
            }
        }

        public List<Product> List(Expression<Func<Product, bool>> filter)
        {
            using(var context = new DataContext())
            {   
                //i=> i.Price>1000 Expression
                var products = context.Products.Where(filter).ToList();

                return products;
            }
        }

        public void Update()
        {
            using(var context=new DataContext())
            {
                context.SaveChanges();
            }
        }
    }
}
