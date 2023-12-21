using OnlineSiparis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSiparis.Models
{
    public class Cart
    {
        private List<Cartline> _cardLines = new List<Cartline>();

        public List<Cartline> CartLines
        {
            get { return _cardLines; }
        }

        public void AddYemek(Yemek yemek, int quantity)
        {
            var line = _cardLines.FirstOrDefault(i => i.Yemek.Id == yemek.Id);
            if (line == null)
            {
                _cardLines.Add(new Cartline() { Yemek = yemek, Quantity = quantity });

            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteYemek(Yemek yemek)
        {
            _cardLines.RemoveAll(i => i.Yemek.Id == yemek.Id);
        }

        public double Total()
        {
            return _cardLines.Sum(i => i.Yemek.Price * i.Quantity);
        }

        public void Clear()
        {
            _cardLines.Clear();
        }

    }


    public class Cartline
    {
        public Yemek Yemek { get; set; }
        public int Quantity { get; set; }
    }
}