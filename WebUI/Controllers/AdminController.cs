using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;

namespace BooksStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // const string culture = "en-US";
            var info = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
            //info.NumberFormat.CurrencyDecimalSeparator = "."
            info.NumberFormat.NumberDecimalSeparator = ".";
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

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            ViewBag.Types = new SelectList(repository.Types, "TypeId", "Name", product.TypeId);
            ViewBag.Categories = new SelectList(repository.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null, HttpPostedFileBase filefsys=null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                if (filefsys != null)
                {
                    string pic = System.IO.Path.GetFileName(filefsys.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"),pic);
                    string url = System.IO.Path.Combine("/Content/images/", pic);
                    filefsys.SaveAs(path);
                    product.ImageUrl = url;
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                ViewBag.Types = new SelectList(repository.Types, "TypeId", "Name", product.TypeId);
                ViewBag.Categories = new SelectList(repository.Categories, "CategoryId", "Name", product.CategoryId);
                return View(product);
            }
        }

        public ViewResult Create()
        {
            ViewBag.Types = new SelectList(repository.Types, "TypeId", "Name");
            ViewBag.Categories = new SelectList(repository.Categories, "CategoryId", "Name");
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}