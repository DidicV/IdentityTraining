using IdentityTraining.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTraining.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _context.Users.OrderBy(u => u.UserName).ToList();

            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            var userRoles = _userManager.GetRolesAsync(user).Result.ToList();

            var roles = _context.Roles.ToList();

            ViewBag.UserRoles = userRoles;
            ViewBag.Roles = roles;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IFormCollection collection)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnassignAdmin(string id, IFormCollection collection)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            _context.Users.Remove(user);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}