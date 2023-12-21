using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSiparis.Entity;

namespace OnlineSiparis.Models
{
    public class AdminOrder
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        //public EnumOrderState OrderState { get; set; }

        public string Name { get; set; }
        public string No { get; set; }
        public string Service { get; set; }
    }
}