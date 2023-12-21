using OnlineSiparis.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSiparis.Models
{

   
public class ShippingDetails
    {
        DataContext _context = new DataContext();

        [Required(ErrorMessage = "Lütfen Adınızı giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Masa Numarasını giriniz")]
        public  List<Order> Masalar { get; set; }
        public  int No { get; set; }
        [Required(ErrorMessage = "Lütfen Servis Sayısını giriniz")]
        public int Service { get; set; }

        public ShippingDetails()
        {
            Masalar = _context.Orders.ToList();
        }
    }

  
}