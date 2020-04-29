using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTaskManager.Models
{
    public class ProductInLocation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int Series { get; set; }
        public int Count { get; set; }
    }
}
