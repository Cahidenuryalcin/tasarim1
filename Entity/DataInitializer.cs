using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineSiparis.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {


            context.Adminler.Add(new Admin() { Name = "cahide", Password = "123" });
               
         

            var  yemekler = new List<Yemek>()
            {
                new Yemek(){ Name= "Kahvaltı", Price= 20.00 , Image= "serpme.jpg"},
                new Yemek(){ Name= "Pankek", Price= 20.00 , Image= "serpme.jpg"},
                new Yemek(){ Name= "Peynir", Price= 20.00 , Image= "serpme.jpg"},
            };




            foreach( var yemek in yemekler)
            {
                context.Yemekler.Add(yemek);
            }
            
      

            for( var i=0; i < 20; i++)
            {
                context.Orders.Add(new Order() { });
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}