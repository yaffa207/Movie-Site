using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace פרויקט_MVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerSelect { get; set; }
        [Required]
        [RegularExpression("^[0-9]$")]
        public int CustomerAge { get; set; }
    }


}