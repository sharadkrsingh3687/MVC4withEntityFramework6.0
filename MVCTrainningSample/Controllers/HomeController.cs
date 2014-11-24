using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

using MVCTrainningSample.DAL;
using MVCTrainningSample.Models;
using MVCTrainningSample.DAL.Security;
using MVCTrainningSample.Common;

namespace MVCTrainningSample.Controllers
{
    [CustomAuthorize(Roles = "User")]
    public class HomeController : BaseController
    {
        TestAppDbContext db = null;
        public HomeController()
        {
            db = new TestAppDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int id = 0)
        {
            if (id > 0)
            {
                var product = db.Products.Where(p => p.ID == id).FirstOrDefault();
                return Json(new { data = product }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = new Product() }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult NewProduct(string id = null)
        {
            ProductModel vm = new ProductModel();
            int productId = 0;
            IList<ProductType> lstProductType = db.ProductTypes.ToList();
            if (lstProductType == null)
            {
                lstProductType = new List<ProductType>();
            }
            ViewBag.ProductTypeList = lstProductType;
            if (!String.IsNullOrEmpty(id))
            {
                productId = Convert.ToInt32(id);
                vm.ProductDetail = db.Products.Where(p => p.ID == productId).FirstOrDefault();
            }

            return View("NewProduct", vm);
        }

        [HttpGet]
        public ActionResult ProductType()
        {
            return PartialView("NewProductType", new ProductType());
        }
        [HttpPost]
        public ActionResult SaveProductType(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                bool outcome = false;
                string message = null;
                ProductType dbProductType = null;

                if (productType.Id > 0)
                {
                    dbProductType = db.ProductTypes.Where(p => p.Id == productType.Id).FirstOrDefault();
                    if (dbProductType != null)
                    {
                        dbProductType.Name = productType.Name;
                        dbProductType.Description = productType.Description;
                        dbProductType.IsActive = productType.IsActive;
                    };
                    db.Entry(dbProductType).State = EntityState.Modified;
                    outcome = true;
                    message = "Record updated successfully!";
                }
                else
                {
                    db.Entry(productType).State = EntityState.Added;
                    message = "New record inserted successfully!";
                    outcome = true;
                }
                db.SaveChanges();
                return Json(new { outcome = outcome, message = message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "ProductType data is not validated!" }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SaveProduct([Bind(Prefix = "ProductDetail")] Product product)
        {
            if (ModelState.IsValid)
            {
                bool outcome = false;
                string message = null;
                Product dbProduct = null;

                if (product.ID > 0)
                {
                    dbProduct = db.Products.Where(p => p.ID == product.ID).FirstOrDefault();
                    if (dbProduct != null)
                    {
                        dbProduct.Name = product.Name;
                        dbProduct.Type = product.Type;
                        dbProduct.Price = product.Price;
                        dbProduct.Quantity = product.Quantity;
                        dbProduct.Description = product.Description;
                    };
                    db.Entry(dbProduct).State = EntityState.Modified;
                    outcome = true;
                    message = "Record updated successfully!";
                }
                else
                {
                    db.Entry(product).State = EntityState.Added;
                    message = "New record inserted successfully!";
                    outcome = true;
                }
                db.SaveChanges();
                return Json(new { outcome = outcome, message = message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Product data is not validated!" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Product()
        {
            ProductModel vm = new ProductModel();
            IList<Product> lstProduct = db.Products.ToList();
            IList<ProductType> lstProductType = db.ProductTypes.ToList();
            if (lstProduct != null)
                vm.ProductList = lstProduct;
            if (lstProductType != null)
                vm.ProductTypeList = lstProductType;

            return View("ProductDetail", vm);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            bool outcome = false;
            string message = null;
            Product dbProduct = null;
            if (id > 0)
            {
                dbProduct = db.Products.Where(p => p.ID == id).FirstOrDefault();
                db.Entry(dbProduct).State = EntityState.Deleted;
                db.SaveChanges();
                outcome = true;
                message = "Record deleted successfully!";
                return Json(new { outcome = outcome, message = message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { outcome = false, message = "Product ID should be greater then zero!" }, JsonRequestBehavior.AllowGet);

        }

    }
}
