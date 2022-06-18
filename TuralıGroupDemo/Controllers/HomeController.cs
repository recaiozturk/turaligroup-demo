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
        private IBankDal _bankService;
        private ICaseDal _caseService;
        private IOrderDal _orderService;
        public HomeController(IClientDal clientService, IProductDal productService, 
            IBankDal bankSerice,ICaseDal caseService,IOrderDal orderService )
        {
            _clientService = clientService;
            _productService = productService;
            _bankService = bankSerice;
            _caseService = caseService;
            _orderService = orderService;
        }

        //Sessiondaki sepetteki ürün listesi
        List<OrderLine> shopingCardList;


        public ActionResult Index()
        {
            int count = 0;

            if (Session["ShoppingCart"] != null)
            {
                count = ((List<OrderLine>)Session["ShoppingCart"]).Count();
            }

            //müşteri borcu
            decimal clientDept=0;
            if (Session["sessionUsername"] != null)
            {
                clientDept = _clientService.GetById((int)Session["sessionId"]).Debt;
            }

            //bankalar
            var banks = _bankService.GetAll();
            var cases = _caseService.GetAll();


            var model = new IndexViewModel()
            {
                Banks=banks,
                Cases=cases,
                ShopCardProductCount = count,
                ClientDebt= clientDept

            };


            return View(model);           
        }


        //Ödeme Sayfası
        public ActionResult PaymentPage()
        {

            var banks = _bankService.GetAll();
            var cases= _caseService.GetAll();

            return View(new PaymentViewModel
            {
                Banks = banks,
                Cases = cases
            });

        }

        [HttpPost]
        public ActionResult PaymentPage(string payment,int selectedValue)
        {

            if (payment == "Bank")
            {
                var bank = _bankService.GetById(selectedValue);
                var extra = bank.Extra;
                var client = _clientService.GetById((int)Session["sessionId"]);

                //vade farkı
                var newDebt= client.Debt + (client.Debt * extra)/100;

                //ödeeme sonrası işlem
                bank.Balance = bank.Balance + newDebt;
                client.Debt = 0;
                _clientService.Update(client);
                _bankService.Update(bank);
            }

            if (payment == "Case")
            {
                var casee = _caseService.GetById(selectedValue);
                
                var client = _clientService.GetById((int)Session["sessionId"]);

                
                var debt = client.Debt;

                //ödeeme sonrası işlem
                casee.Balance = casee.Balance + debt;
                client.Debt = 0;
                _clientService.Update(client);
                _caseService.Update(casee);
            }

            return RedirectToAction("Index", "Home");

        }

        //Sepet
        public ActionResult ShopCard()
        {
            

            if (Session["ShoppingCart"] != null)
            {
                shopingCardList = (List<OrderLine>)Session["ShoppingCart"];
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            decimal generalDiscountAmount=0;
            decimal generalKDVAmount=0;
            decimal generalTotalPrice=0;

            foreach (var orderLine in shopingCardList)
            {
                orderLine.Product=_productService.GetById(orderLine.ProductId);

                var discount = orderLine.Product.Discount;
                var price = orderLine.Product.PurchasePrice;
                var kdv = orderLine.Product.KDV;



                orderLine.DiscountAmount = (price * discount) / 100;
                generalDiscountAmount += orderLine.DiscountAmount;

                orderLine.KDVAmount = (price*kdv)/100;
                generalKDVAmount += orderLine.KDVAmount;

                orderLine.TotalPrice = (price + orderLine.KDVAmount - orderLine.DiscountAmount)*orderLine.Quantity;
                generalTotalPrice += orderLine.TotalPrice;

            }

            //set order lines totalprice,total amount...
            

            return View(new ShopCardViewModel
            {
                generalDiscountAmount = generalDiscountAmount,
                generalKDVAmount = generalKDVAmount,
                generalTotalPriceAmount = generalTotalPrice,
                Orderlines=shopingCardList
            });
        }

        //Sepet Post
        [HttpPost]
        public ActionResult ShopCard(decimal totalPrice)
        {

            var clientId = (int)Session["sessionId"];

            //sipariş oluşturuyoruz
            _orderService.Create(new Order
            {
                ClientId = clientId,
                TotalPrice = totalPrice
            });

            //sepeti sıfırlıyoruz
            Session["ShoppingCart"] = null;

            //borç tanımlıyoruz
            var client=_clientService.GetById(clientId);
            client.Debt = client.Debt + totalPrice;
            _clientService.Update(client);

            //banka güncel bakiye
            var banks = _bankService.GetAll();
            var cases = _caseService.GetAll();

            var indexModel = new IndexViewModel
            {
                // sepet ödeme işleminden sorna sıfırlandı
                ShopCardProductCount = 0,
                ClientDebt=client.Debt,
                Banks=banks,
                Cases=cases
                
            };

            return View("Index",indexModel);
        }

        //Ürünler sayfası
        public ActionResult Products()
        {


            int count = 0;

            if (Session["ShoppingCart"] != null)
            {
                count = ((List<OrderLine>)Session["ShoppingCart"]).Count();
            }

            return View(new ProductsViewModel
            {
                ShopCardProductCount=count,
                Products = _productService.GetAll()
            });
        }




        //Sepete Ürün Ekle
        public ActionResult AddShopCart(OrderLine model)
        {
            var orderLine = new OrderLine()
            {
                ProductId=model.ProductId,
                Quantity=model.Quantity,
                Price=model.Price,
            };

            List<OrderLine> shopingCardList = (List<OrderLine>)Session["ShoppingCart"];

            if(shopingCardList == null)
            {
                shopingCardList = new List<OrderLine>();
                Session.Add("ShoppingCart", shopingCardList);
            }
                

            //sepette ürün varsa 
            if (shopingCardList.Count != 0)          
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



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            
            if (_clientService.LoginCheck(model.Name,model.Password) !=0)
            {
                Session.Add("sessionUsername", model.Name);
                Session.Add("sessionId", _clientService.LoginCheck(model.Name, model.Password));

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