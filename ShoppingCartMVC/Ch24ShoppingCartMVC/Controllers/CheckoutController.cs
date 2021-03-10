using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<CheckoutViewModel> checkOutModel = new List<CheckoutViewModel>();
            CartViewModel model = Session["cart"] as CartViewModel;
            CartModel cart = new CartModel();
            if (model == null)
            {
                model = cart.GetCart();
            }

            foreach (var item in model.Cart)
            {
                CheckoutViewModel checkout = new CheckoutViewModel(
                    item.ProductID, item.Name, item.Quantity, item.UnitPrice, item.Quantity * item.UnitPrice);
                checkOutModel.Add(checkout);
            }

            List<ProductViewModel> objCart = HttpContext.Session["cart"] as List<ProductViewModel>;
            if (objCart.Count > 0)
            {
                Session["EmptyCart"] = null;
            }
            return View(checkOutModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            List<ProductViewModel> objCart = HttpContext.Session["cart"] as List<ProductViewModel>;
            if (objCart.Count > 0)
            {
                Session["cart"] = null;
                TempData["payment"] = collection["payment"];
                TempData["address"] = collection["address"];
                return RedirectToAction("ConfirmOrder");
            }
            Session["EmptyCart"] = "Cart is Empty";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ConfirmOrder()
        {
            return View();
        }

    }
}
