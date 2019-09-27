using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using canineProj.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace canineProj.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Enter()
        {
            return View();
        }

        
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}
