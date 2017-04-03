using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using System.Data.Entity;

namespace BooksStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {

            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    //dbEntry.Category = product.Category;
                    if(product.ImageData!=null)
                        dbEntry.ImageData = product.ImageData;
                    if (product.ImageMimeType != null)
                        dbEntry.ImageMimeType = product.ImageMimeType;
                    dbEntry.TypeId = product.TypeId;
                    dbEntry.CategoryId = product.CategoryId;
                    if(product.ImageUrl!=null)
                        dbEntry.ImageUrl = product.ImageUrl;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<Entities.Type> Types
        {
            get { return  context.Types.ToList(); }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories.ToList(); }
        }

        public IEnumerable<String>  categoriesFilterByType(string type = null)
        {
            var categories = context.Products
                        .Include(i => i.Type)
                        .Include(i => i.Category)
                        .Where(c => (type==null||type=="All")? true : c.Type.Name == type)
                        .Select(i => i.Category.Name)
                        .Distinct()
                        .ToList();
            return categories;
        }

    }
}
