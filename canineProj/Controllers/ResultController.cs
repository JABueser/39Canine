using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using canineProj.Models;
using canineProj.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace canineProj.Controllers
{
    public class ResultController : Controller
    {

        private IResultRepository repository;
        private IBreedRepository breedrepo;
        private IDogRepository dogrepo;
        public ResultController(IResultRepository repo, IBreedRepository brepo, IDogRepository drepo)
        {

            repository = repo;
            breedrepo = brepo;
            dogrepo = drepo;
        }



        public IActionResult Index(int rkey)
        {

            var model = new ResultViewModel
            {
                result = repository.Results.FirstOrDefault(r => r.Rkey == rkey),
                breed = breedrepo.Breeds.FirstOrDefault(b => b.Rkey == rkey),
                dog = dogrepo.Dogs.FirstOrDefault(d=>d.Rkey == rkey),
                
            };

            if(model.breed == null || model.breed == null)
            {
                return View("ErrorPage");
            }

            return View(model);
        }

    }
}
