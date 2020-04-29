using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTaskManager.Models.ViewModels
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
    }
}
