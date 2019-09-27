using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using canineProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace canineProj.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private IDogRepository repository;
        public DogController(IDogRepository repo, UserManager<ApplicationUser> userMgr)
        {
            repository = repo;
            _userManager = userMgr;
        }


        // GET: /<controller>/
        //public IActionResult List(string accountID) => View(repository.Dogs.Where(d => d.AccountID == accountID));

        public async Task<IActionResult> List()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            string accountID = user.Id;
            return View(repository.Dogs.Where(d => d.AccountID == accountID));
        }

        [HttpGet]
        public ViewResult Edit(int dogId)
        {
            return View(repository.Dogs.FirstOrDefault(p => p.DogID == dogId));
        }

        [HttpPost]
        public IActionResult Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                repository.SaveDog(dog);
                //TempData["message"] = $"{dog.Name} has been saved";
                return RedirectToAction("List", new { accountID = dog.AccountID });
            }
            else
            {
                //there is something wrong with the data values
                return View(dog);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            string accountID = user.Id;

            var model = new Dog
            {
                AccountID = accountID
            };
            return View("Edit", model);
        }


        [HttpPost]
        public IActionResult Delete(int DogID)
        {

            Dog deletedDog = repository.DeleteDog(DogID);
            if (deletedDog != null)
            {
                //TempData["message"] = $"{deletedDog.Name} was deleted";
            }
            return RedirectToAction("List", new { accountID = deletedDog.AccountID });
        }
    }
}
