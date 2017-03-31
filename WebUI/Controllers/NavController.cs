using BooksStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStore.Domain.Entities;

namespace BooksStore.WebUI.Controllers
{
    public class NavController : Controller
    {

        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string type = null, string category = null)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedType = type;
            //IEnumerable<string> categories = repository.Categories
            //.Select(x => x.Name)
            //.Distinct()
            //.OrderBy(x => x);
            IEnumerable<string> categories = repository.categoriesFilterByType(type);
            return PartialView(categories);
        }

        public PartialViewResult MenuTop(string type=null, string category = null)
        {
            ViewBag.SelectedType = type;
            IEnumerable<Domain.Entities.Type> types = repository.Types
            .Distinct()
            .OrderBy(x => x.Name)
            .ToList()
            .Select(x => new Domain.Entities.Type { Name = x.Name, NameEng = x.NameEng });

            return PartialView(types);
        }
    }
}