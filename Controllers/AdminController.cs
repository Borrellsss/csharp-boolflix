using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
