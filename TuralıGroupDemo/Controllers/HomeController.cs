using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuralıGroupDemo.Entity;
using TuralıGroupDemo.Models;
using TuralıGroupDemo.Repository.Abstract;

namespace TuralıGroupDemo.Controllers
{
    public class HomeController : Controller
    {

        private IClientDal _clientService;
        private IProductDal _productService;
        public HomeController(IClientDal clientService, IProductDal productService )
        {
            _clientService = clientService;
            _productService = productService;
        }


        public ActionResult Index()
        {
            int count = 0;

            if (Session["ShoppingCart"] != null)
            {
                count = ((List<OrderLine>)Session["ShoppingCart"]).Count();
            }

            var model = new IndexViewModel()
            {

                ShopCardProductCount = count
            };
            return View(model);           
        }

        public ActionResult Products()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll()
            });
        }



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddShopCart(OrderLine model)
        {
            var orderLine = new OrderLine()
            {
                ProductId=model.ProductId,
                Quantity=model.Quantity,
                Price=model.Price,
            };

            List<OrderLine> shopingCardList = (List<OrderLine>)Session["ShoppingCart"];

            //sepette ürün varsa 
            if(shopingCardList.Count != 0)
            {
                for (int i = 0; i < shopingCardList.Count; i++)
                {
                    //sepete aynı ürünü eklersek sadece miktarı arttırsın
                    if(shopingCardList[i].ProductId == orderLine.ProductId)
                    {
                        shopingCardList[i].Quantity += model.Quantity;

                        return RedirectToAction("Products");
                        
                    }
                }
            }

            //eklediğimiz ürün yeni ise direk eklesin
            shopingCardList.Add(orderLine);

            return RedirectToAction("Products");
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            
            if (_clientService.LoginCheck(model.Name,model.Password))
            {
                Session.Add("sessionUsername", model.Name);

                //sepetteri ürünleri tutmak için
                var orderLines = new List<OrderLine>();               
                Session.Add("ShoppingCart", orderLines);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Yanlış kullanıcı adı ve ya şifre";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }


    }
}