using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectName.DATA.EF;
using StoreFrontLab.UI.MVC.Models;
using PagedList; //Added for access to PagedList
using PagedList.Mvc; //Added for access to PagedList.MVC

namespace StoreFrontLab.UI.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private ClimbersClubEntities db = new ClimbersClubEntities();

        #region Non Crud Functionality

        //// GET: Products
        //public ActionResult Index(int page = 1)
        //{
        //    int pageSize = 5;
        //    var products = db.Products.Include(p => p.Category).Include(p => p.StockStatu).ToList();
        //    return View(products.ToPagedList(page, pageSize));
        //}

        //// GET: Products/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        //#region Custom Add-To-Cart Functionality (Called from Details View)

        //public ActionResult AddToCart(int qty, int productID)
        //{
        //    //Create an empty shell for the LOCAL shopping cart variable
        //    Dictionary<int, CartItemViewModel> shoppingCart = null;

        //    //Check if the Session shopping cart exists. If so, we can use it to populate the local version
        //    if (Session["cart"] != null)
        //    {
        //        //Session shopping car exists. Put it's items in the local version, which is easier to work with
        //        shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
        //        //We need to UNBOX the Session object to its smaller, more specific type -- Explicit Casting
        //    }

        //    else
        //    {
        //        //If the Session cart doesn't exist yet, we need to instantiate it to get started
        //        shoppingCart = new Dictionary<int, CartItemViewModel>();
        //    }//After this if/else, we now have a local cart thats ready to add things to it

        //    //Find the product they referenced by its ID
        //    Product product = db.Products.Where(b => b.ProductID == productID).FirstOrDefault();

        //    if (product == null)
        //    {
        //        //If given a bad ID, return the user to some other page to try again.
        //        //Alternatively, we could throw some kind of error, which we will
        //        //discuss further in Module 6.
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        //If the book is valid, add the line-item to the cart
        //        CartItemViewModel item = new CartItemViewModel(qty, product);

        //        //Put the item in the local cart. If they already have that product as a 
        //        //cart item, instead we will update the quantity. This is a big part
        //        //of why we have the dictionary.
        //        if (shoppingCart.ContainsKey(product.ProductID))
        //        {
        //            shoppingCart[product.ProductID].Qty += qty;
        //        }
        //        else
        //        {
        //            shoppingCart.Add(product.ProductID, item);
        //        }

        //        //Now update the SESSION version of the cart so we can maintain that info between requests
        //        Session["cart"] = shoppingCart; //No explicit casting needed here
        //    }

        //    //Send them to View their Cart Items
        //    return RedirectToAction("Index", "ShoppingCart");

        //}

        //#endregion



        //// GET: Products/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
        //    ViewBag.StockStatusID = new SelectList(db.StockStatus, "StockStatusID", "StockStatus");
        //    return View();
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductID,ProductName,CategoryID,GenderID,StockStatusID,UnitsInStock,Price,IsMensApperal,IsFemaleApperal,OtherApperal,ProductImage,BrandName")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
        //    ViewBag.StockStatusID = new SelectList(db.StockStatus, "StockStatusID", "StockStatus", product.StockStatusID);
        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
        //    ViewBag.StockStatusID = new SelectList(db.StockStatus, "StockStatusID", "StockStatus", product.StockStatusID);
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductID,ProductName,CategoryID,GenderID,StockStatusID,UnitsInStock,Price,IsMensApperal,IsFemaleApperal,OtherApperal,ProductImage,BrandName")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
        //    ViewBag.StockStatusID = new SelectList(db.StockStatus, "StockStatusID", "StockStatus", product.StockStatusID);
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.StockStatu);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.StockStatusID = new SelectList(db.StockStatus, "StockStatusID", "StockStatus");
            return View(products.ToList());
        }

        #region AJAX CRUD Functionality

        //Deletes the product record, but it will return only JSON data on the id & confirmation
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            string confirmMessage = string.Format("Deleted product '{0}' from the database.", product.ProductName);

            return Json(new { id = id, message = confirmMessage });
        }

        //Gets the Partial view for Details with AJAX
        //Generate this view like normal, but choose Details scaffolding for Publisher AND check Partial View checkbox
        [HttpGet]
        public PartialViewResult ProductDetails(int id)
        {
            Product product = db.Products.Find(id);
            return PartialView(product);

            //Create Partial View (PublisherDetails.cshtml)
            // - Template: Details
            // - Model Class: Product
            // - Data Context Class: ClimberClubEntities
            // - Check "Create as Partial View" checkbox
            // - Minor tweaks to the View content
        }


        //Create a new Product record. Also returns Publisher's data as JSON.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ProductCreate(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Json(product);

            /*
             * Create a Partial View (ProductCreate.cshtml)
             * - Template: Create
             * - Model: Product
             * - Date Context Class: ClimberClubEntities
             * - Check "Create as Partial View"
             */
        }

        //Gets PartialView for a product edit form displayed with AJAX
        [HttpGet]
        public PartialViewResult ProductEdit(int id)
        {
            Product product = db.Products.Find(id);
            return PartialView(product);

            /*
             * Create a Partial View (ProductEdit.cshtml)
             * - Template: Edit
             * - Model: Product
             * - Data Context Class: ClimberClubEntities
             * - Check the Create as Partial View checkbox
             * - Minor tweaks to content
             */

        }

        //Edits publisher record and returns publisher's data as JSON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return Json(product);
        }

        

        #endregion
    }
}
