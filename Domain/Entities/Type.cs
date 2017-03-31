using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Domain.Entities
{
    [Table("Type")]
    public class Type
    {
        [Key]
        public  int TypeId { get; set; }
        public  string Name { get; set; }

        public  string NameEng { get; set; }
        public  List<Product> Products { get; set; }
    }
}
