using OnlineSiparis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSiparis.Models
{
    public class UserOrder
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        //public EnumOrderState OrderState { get; set; }
    }
}