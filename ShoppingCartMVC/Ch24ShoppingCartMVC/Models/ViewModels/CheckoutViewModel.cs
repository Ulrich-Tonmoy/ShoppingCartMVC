using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public CheckoutViewModel(string productId,string name, int quantity, decimal unitPrice, decimal totalPrice)
        {
            this.ProductID = productId;
            this.Name = name;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.TotalPrice = totalPrice;
        }
    }
}