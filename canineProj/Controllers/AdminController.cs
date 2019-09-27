using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using canineProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace canineProj.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private IResultRepository repository;
        private IBreedRepository breedrepo;
        private IProductRepository productrepo;
        private IOrderRepository orderRepo;
        public AdminController(IResultRepository repo, IBreedRepository brepo, IProductRepository prepo, IOrderRepository orepo)
        {
            repository = repo;
            breedrepo = brepo;
            productrepo = prepo;
            orderRepo = orepo;
        }

        /// <summary>
        /// KRISTEN's PRODUCT ADMIN
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductList()
        {
            return View(productrepo.Products);
        }
        public ViewResult EditProduct(int productId)
        {
            var model = new Product();
            model = productrepo.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productrepo.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("ProductList");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }
        public ViewResult CreateProduct() => View("EditProduct", new Product());
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            Product deletedProduct = productrepo.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("ProductList");
        }


        public ViewResult ResultsList() => View(repository.Results);


        /// <summary>
        /// RESULT EDIT INDIVIDUAL PAGES
        /// </summary>
        /// <param name="resultID"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Edit(int resultID)
        {
            return View(repository.Results.FirstOrDefault(r => r.ResultID == resultID));
        }
        [HttpPost]
        public IActionResult Edit(Result result)
        {
            if (ModelState.IsValid)
            {
                repository.SaveResult(result);
                //TempData["message"] = $"{result.ResultID} has been saved";
                return RedirectToAction("ResultsList");
            }
            else
            {
                //there is something wrong with the data values
                return View();
            }
        }
        public ViewResult Create() => View("Edit", new Result());
        [HttpPost]
        public IActionResult Delete(int resultID)
        {
            Result deletedResult = repository.DeleteResult(resultID);
            if (deletedResult != null)
            {
                //TempData["message"] = $"{deletedDog.ResultID} was deleted";
            }
            return Redirect("ResultsList");
        }




        /// <summary>
        /// BREED STUFF
        /// </summary>
        /// <param name="resultID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BreedEdit(int resultID)
        {
            return View(breedrepo.Breeds.FirstOrDefault(b => b.ResultID == resultID));
        }
        [HttpPost]
        public IActionResult BreedEdit(Breed breed)
        {
            if (ModelState.IsValid)
            {
                breedrepo.SaveBreed(breed);
                //TempData["message"] = $"Breed Number {breed.BreedID} has been saved";
                return View();
            }
            else
            {
                //there is something wrong with the data values
                return View(breed);
            }
        }
        public ViewResult BreedCreate(int resultID) => View("BreedEdit", new Breed()
        {
            ResultID = resultID
        });
        [HttpPost]
        public IActionResult BreedDelete(int BreedID)
        {

            Breed deletedBreed = breedrepo.DeleteBreed(BreedID);
            if (deletedBreed != null)
            {
                //TempData["message"] = $"{deletedDog.Name} was deleted";
            }
            return View();
        }


        public ViewResult OrderList() => View(orderRepo.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = orderRepo.Orders
            .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true; orderRepo.SaveOrder(order);
            }
            return RedirectToAction(nameof(OrderList));
        }


    }
}
