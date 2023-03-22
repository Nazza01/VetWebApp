using Microsoft.AspNetCore.Mvc;
using VetWebApp.Models;

namespace VetWebApp.Controllers
{
    public class PetController : Controller
    {
        // This view is the default returned by the AddAnimal.cshtml file
        public IActionResult ManagePets()
        {
            Console.WriteLine("Managing Pets");
            return View();
        }
        public IActionResult AddPets()
        {
            Console.WriteLine("Add Pets");
            return View();
        }
    }
}
