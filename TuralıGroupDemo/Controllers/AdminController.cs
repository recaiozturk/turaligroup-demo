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
    public class AdminController : Controller
    {
        //Dependency Injection

        private IClientDal _clientService;
        private IProductDal _productService;
        private IBankDal _bankService;
        private ICaseDal _caseService;
        public AdminController(IClientDal clientService, IProductDal productService, IBankDal bankService, ICaseDal caseService)
        {
            _clientService = clientService;
            _productService = productService;
            _bankService = bankService;
            _caseService = caseService;
        }


        // List Client
        public ActionResult ClientList()
        {
            return View(new ClientLıstModel
            {
                Clients = _clientService.GetAll()
            });
        }

        //Create Client - GET
        [HttpGet]
        public ActionResult CreateClient()
        {
            return View();
        }

        //Create Client - POST
        [HttpPost]
        public ActionResult CreateClient(ClientModel model)
        {
            var entity = new Client()
            {
                Name = model.Name,
                Surname = model.Surname,
                Password=model.Password,
                Phone = model.Phone,
                City = model.City

            };

            _clientService.Create(entity);

            return RedirectToAction("ClientList");
        }

        //Edit Client - GET
        [HttpGet]
        public ActionResult EditClient(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var entity = _clientService.GetById((int)id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            var model = new ClientModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Phone = entity.Phone,
                City = entity.City
            };

            return View(model);
        }

        //Edit Client - POST
        [HttpPost]
        public ActionResult EditClient(ClientModel model)
        {

            var entity = _clientService.GetById(model.Id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Name = model.Name;
            entity.Password = model.Password;
            entity.Surname = model.Surname;
            entity.Phone = model.Phone;
            entity.City = model.City;

            _clientService.Update(entity);

            return RedirectToAction("ClientList");
        }

        //Delete Client
        [HttpPost]
        public ActionResult DeleteClient(int clientId)
        {
            var entity = _clientService.GetById(clientId);

            if (entity != null)
            {
                _clientService.Delete(entity);
            }

            return RedirectToAction("ClientList");
        }


        // Product Control -------------------------------------

        // List Product
        public ActionResult ProductList()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll()
            });
        }

        //Create Product - GET
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        //Create Product - POST
        [HttpPost]
        public ActionResult CreateProduct(Product model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                PurchasePrice = model.PurchasePrice,
                SalePrice = model.SalePrice,
                Discount = model.Discount,
                KDV = model.KDV = model.KDV,
                ImageUrl = model.ImageUrl

            };

            _productService.Create(entity);

            return RedirectToAction("ProductList");
        }

        //Edit Product - GET
        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var entity = _productService.GetById((int)id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                PurchasePrice = entity.PurchasePrice,
                SalePrice = entity.SalePrice,
                Discount = entity.Discount,
                KDV = entity.KDV = entity.KDV,
                ImageUrl = entity.ImageUrl
            };

            return View(model);
        }

        //Edit Product - POST
        [HttpPost]
        public ActionResult EditProduct(ProductModel model)
        {

            var entity = _productService.GetById(model.Id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Name = model.Name;
            entity.PurchasePrice = model.PurchasePrice;
            entity.SalePrice= model.SalePrice;
            entity.Discount = model.Discount;
            entity.KDV = model.KDV;
            entity.ImageUrl = model.ImageUrl;

            _productService.Update(entity);

            return RedirectToAction("ProductList");
        }

        //Delete Product
        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("ProductList");
        }


        // Bank Control -------------------------------------

        // List Bank
        public ActionResult BankList()
        {
            return View(new BankListModel
            {
                Banks = _bankService.GetAll()
            });
        }

        //Create Bank - GET
        [HttpGet]
        public ActionResult CreateBank()
        {
            return View();
        }

        //Create Bank - POST
        [HttpPost]
        public ActionResult CreateBank(Bank model)
        {
            var entity = new Bank()
            {
                Name = model.Name,
                Balance = model.Balance,
                Extra = model.Extra

            };

            _bankService.Create(entity);

            return RedirectToAction("BankList");
        }

        //Edit Bank - GET
        [HttpGet]
        public ActionResult EditBank(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var entity = _bankService.GetById((int)id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            var model = new BankModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance,
                Extra = entity.Extra
            };

            return View(model);
        }

        //Edit Bank - POST
        [HttpPost]
        public ActionResult EditBank(BankModel model)
        {

            var entity = _bankService.GetById(model.Id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Name = model.Name;
            entity.Balance = model.Balance;
            entity.Extra = model.Extra;

            _bankService.Update(entity);

            return RedirectToAction("BankList");
        }

        //Delete Bank
        [HttpPost]
        public ActionResult DeleteBank(int bankId)
        {
            var entity = _bankService.GetById(bankId);

            if (entity != null)
            {
                _bankService.Delete(entity);
            }

            return RedirectToAction("BankList");
        }



        // Case Control -------------------------------------

        // List Case
        public ActionResult CaseList()
        {
            return View(new CaseListModel
            {
                Cases = _caseService.GetAll()
            });
        }

        //Create Case - GET
        [HttpGet]
        public ActionResult CreateCase()
        {
            return View();
        }

        //Create Case - POST
        [HttpPost]
        public ActionResult CreateCase(Case model)
        {
            var entity = new Case()
            {
                Name = model.Name,
                Balance = model.Balance

            };

            _caseService.Create(entity);

            return RedirectToAction("CaseList");
        }

        //Edit Case - GET
        [HttpGet]
        public ActionResult EditCase(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var entity = _caseService.GetById((int)id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            var model = new CaseModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance
            };

            return View(model);
        }

        //Edit Case - POST
        [HttpPost]
        public ActionResult EditCase(CaseModel model)
        {

            var entity = _caseService.GetById(model.Id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Name = model.Name;
            entity.Balance = model.Balance;

            _caseService.Update(entity);

            return RedirectToAction("CaseList");
        }

        //Case Bank
        [HttpPost]
        public ActionResult DeleteCase(int bankId)
        {
            var entity = _caseService.GetById(bankId);

            if (entity != null)
            {
                _caseService.Delete(entity);
            }

            return RedirectToAction("CaseList");
        }

    }
}