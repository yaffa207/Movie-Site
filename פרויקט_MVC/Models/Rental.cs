using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace פרויקט_MVC.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
    }
}