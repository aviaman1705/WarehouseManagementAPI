using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTaskManager.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Message { get; set; }
        public string Lvl { get; set; }
    }
}
