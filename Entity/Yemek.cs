using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSiparis.Entity
{
    public class Yemek
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}