using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCore;
namespace Identity.Controllers
   
{
    [Authorize]
    public class AppRolesController : Controller
    {
        
        private readonly RoleManager<IdentityRole> rolemanager;

        public AppRolesController(RoleManager<IdentityRole> rolemanager)
        {
            this.rolemanager = rolemanager;
        }

        //list all the roles created
        public IActionResult Index()
        {
            var roles = rolemanager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if(!rolemanager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                rolemanager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");  
            
        }



    }
}
