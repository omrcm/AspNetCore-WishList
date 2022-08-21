using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context; 
        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _context.Items.ToList();
            return View("Index",list);
        }

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Creata");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var item = _context.Items.FirstOrDefault(c => c.Id == Id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

