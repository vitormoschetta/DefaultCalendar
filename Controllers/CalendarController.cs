using System.Linq;
using DefaultCalendar.Data;
using DefaultCalendar.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefaultCalendar.Controllers
{
    public class CalendarController: Controller
    {
        private readonly ApplicationDbContext _context;
        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listaModelo = _context.Event.ToList();      
            return View(listaModelo);
        }


        public IActionResult Create(string date)
        {
            var modelo = new Event() {
                Start = date,
            };
            return PartialView("_CreateEvent", modelo);
        }


        [HttpPost]
        public IActionResult Create(Event modelo)
        {
            _context.Add(modelo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int eventId)
        {
            var modelo = _context.Event.Single(x => x.EventId == eventId);
            return PartialView("_EditEvent", modelo);
        }


        [HttpPost]
        public IActionResult Edit(Event modelo)
        {
            _context.Update(modelo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}