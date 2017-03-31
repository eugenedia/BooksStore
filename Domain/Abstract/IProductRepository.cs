using BooksStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
        IEnumerable<Category> Categories { get; }
        IEnumerable<Entities.Type> Types { get; }
        IEnumerable<String> categoriesFilterByType(string type);
    }
}
