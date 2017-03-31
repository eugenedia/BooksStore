using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using BooksStore.WebUI.Models;
using BooksStore.Domain.Concrete;
using System.Data.Entity;

namespace BooksStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

           // const string culture = "en-US";
            var info = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
            //info.NumberFormat.CurrencyDecimalSeparator = "."
            //info.NumberFormat.NumberDecimalSeparator = "."
            //info.NumberFormat.PercentDecimalSeparator = "."
            //info.NumberFormat.CurrencyGroupSeparator = ","
            //info.NumberFormat.NumberGroupSeparator = ","
            //info.NumberFormat.PercentGroupSeparator = ","
            //info.NumberFormat.
            info.NumberFormat.CurrencySymbol = " Р.";
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
            System.Threading.Thread.CurrentThread.CurrentUICulture = info;
            // CultureInfo ci = CultureInfo.GetCultureInfo(culture);

            //Thread.CurrentThread.CurrentCulture = ci;
            //Thread.CurrentThread.CurrentUICulture = ci;
        }
        public ViewResult List(string category, string type = null, int page = 1)
        {
            //throw new System.ArgumentException("Parameter cannot be null", "original");
            EFDbContext context = new EFDbContext();
            //var products = context.Products.Include(i=>i.Type).ToList();
            //var products = context.Products.Include("Type").ToList();
            //IEnumerable<Domain.Entities.Type> types = context.Types
            //.Distinct()
            //.OrderBy(x => x.Name)
            //.ToList()
            //.Select(x => new Domain.Entities.Type { Name = x.Name, NameEng = x.NameEng });
            //var Products = context.Products.Include(i => i.Type).Include(i => i.Category).ToList();

            ProductsListViewModel model = new ProductsListViewModel
            {

                Products = context.Products.Include(i => i.Type).Include(i => i.Category)
                    .Where(p => ((category == null?true:p.Category.Name == category) && (type == null?true:p.Type.Name == type)))
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = 
                         context.Products.Include(i => i.Type).Include(i => i.Category)
                         .Where(e => (category==null?true:e.Category.Name == category)&&(type==null?true:e.Type.Name==type)).Count()
                },
                CurrentCategory = category,
                CurrentType = type
            };
            return View(model);
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}