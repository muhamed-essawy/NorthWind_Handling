using NorthWind_Handling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWind_Handling.Controllers
{
    public class ProductController : Controller
    {
        NorthWindContext Context = new NorthWindContext();

        public object Db { get; private set; }

        public ActionResult Index()
        {
            

            return View(Context.Products.ToList() );
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel ProductVM)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product()
                {

                    ProductID = ProductVM.ID,
                    ProductName = ProductVM.ProductName,
                    SupplierID = ProductVM.SupplierID,
                    Discontinued = ProductVM.Discontinued

                };
                Context.Products.Add(p);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("./");

            }
            Product p = Context.Products.SingleOrDefault(pp => pp.ProductID == id);
            if (p == null)

                return RedirectToAction("Index");


            ProductViewModel pvm = new ProductViewModel()
            {
                ID = p.ProductID,
                ProductName = p.ProductName,
                Discontinued = p.Discontinued,
                SupplierID = p.SupplierID

        };
        //    Context.Products.Remove(p);
            Context.SaveChanges();

            return View(pvm);


        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                Product p = Context.Products.SingleOrDefault(pp => pp.ProductID == id);
                if (p == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Context.Products.Remove(p);
                    


                    try
                    {
                        Context.SaveChanges();

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(  e);
                    }






                    return RedirectToAction("Index");
                }

            }
        }

    }
}