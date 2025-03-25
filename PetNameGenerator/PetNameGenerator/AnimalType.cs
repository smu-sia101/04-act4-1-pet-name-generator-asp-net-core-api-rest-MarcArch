using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator
{
    public class AnimalType : Controller
    {
        public IActionResult Post()
        {
            return View();
        }
    }
}
