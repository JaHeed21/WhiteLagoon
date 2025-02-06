using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("Description", "Description cannot be Exactly same as Name");
                //ModelState.AddModelError("", "Description cannot be Exactly same as Name");
            }
            if (obj.Price<=0)
            {
                ModelState.AddModelError("Price", "Price cannot be Negative or Zero. ");
                //ModelState.AddModelError("", "Description cannot be Exactly same as Name");
            }

            if (ModelState.IsValid)
            {
                _context.Villas.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Villa");
            }
            return View();
            
        }

        public IActionResult Update(int villaId)
        { 
            Villa? obj = _context.Villas.FirstOrDefault(x => x.Id ==villaId);
            if (obj == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
         {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _context.Villas.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Villa");
            }
            return View();

        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _context.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

         [HttpPost]
        public IActionResult Delete(Villa obj)
         {
           
                Villa? deletevilla = _context.Villas.Where(x => x.Id == obj.Id).FirstOrDefault();
                if (deletevilla is not null)
                {
                    _context.Villas.Remove(deletevilla);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Villa");
                }

            return View();


        }

    }
}

