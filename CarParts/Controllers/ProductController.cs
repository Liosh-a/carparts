using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Description,Price,CategoryId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Products.Add(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        //    return View(product);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Add(ProductAddViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            Product product = new Product()
        //            {
        //                Name = model.Name,
        //                Price = model.Price,
        //                Description = model.Description,
        //                CategoryId = model.CategoryId
        //            };
        //            _context.Products.Add(product);
        //            for (int i = 0; i < model.DescriptionImages.Count(); i++)
        //            {
        //                var temp = model.DescriptionImages[i];
        //                if (temp != null)
        //                {
        //                    _context.ProductDescriptionImages
        //                        .FirstOrDefault(t => t.Name == temp)
        //                        .ProductId = product.Id;
        //                }

        //            }
        //            _context.SaveChanges();
        //            scope.Complete();
        //        }
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        //    return View(model);
        //}
    }
}