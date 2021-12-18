using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLabBackEnd.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult about()
        {
            return View();
        }
        
        public IActionResult biography()
        {
            return View();
        }
        
        public IActionResult films()
        {
            return View();
        }
        
        public IActionResult gallery()
        {
            return View();
        }
        
        public IActionResult profile()
        {
            return View();
        }
        
        public IActionResult jipers4()
        {
            return View();
        }
        public IActionResult silentnight()
        {
            return View();
        }
        public IActionResult spiderman3()
        {
            return View();
        }
        public IActionResult tomholland()
        {
            return View();
        }
    }
}