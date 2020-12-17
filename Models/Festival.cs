using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backendbrzina.Models
{
    public class Festival
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int YearStart { get; set; }

        public int PlaceID { get; set; }
        public Place Place { get; set; }
    }
}