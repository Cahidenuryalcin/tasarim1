using OnlineSiparis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSiparis.Models
{
    public class OrderModel
    {
     
            public int Id { get; set; }


            public virtual List<OrderLine> OrderLines { get; set; }


        public class OrderLine
        {
            public int Id { get; set; }

            public int MasaId { get; set; }
            public virtual Order Order { get; set; }

            public int Service { get; set; }
            public String Name { get; set; }


            public DateTime OrderDate { get; set; }
           

            public int Quantity { get; set; }
            public double Price { get; set; }

            public int ProductId { get; set; }
            public virtual Yemek Yemek { get; set; }

        }
    }
}