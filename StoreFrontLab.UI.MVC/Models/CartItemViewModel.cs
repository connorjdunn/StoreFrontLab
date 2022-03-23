using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectName.DATA.EF;

namespace StoreFrontLab.UI.MVC.Models
{
    public class CartItemViewModel
    {
        [Range(1, int.MaxValue)]
        public int Qty { get; set; }

        public Product Product { get; set; }

        public CartItemViewModel(int qty, Product product)
        {
            Qty = qty;
            Product = product;
        }
    }
}