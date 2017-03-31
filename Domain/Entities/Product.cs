using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Domain.Entities
{
    public class Product
    {
        [Required(ErrorMessage = "Please enter a product name")]
        public virtual int ProductID { get; set; }
        public virtual int TypeId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public virtual string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public virtual decimal Price { get; set; }
        //[Required(ErrorMessage = "Выберите категорию")]
        //public virtual string Category { get; set; }

        public virtual byte[] ImageData { get; set; }
        public virtual string ImageMimeType { get; set; }

        public string ImageUrl { get; set; }

        public virtual Type Type { get; set; }

        public virtual Category Category { get; set; }
    }
}
