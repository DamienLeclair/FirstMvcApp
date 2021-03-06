﻿namespace SportsStore.WebUI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;

    public class AdminController : Controller
    {
        readonly IProductsRepository repository;

        public AdminController(IProductsRepository repository)
        {
            this.repository = repository;
        }
        
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            
            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}