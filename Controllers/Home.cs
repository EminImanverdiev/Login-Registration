using Microsoft.AspNetCore.Mvc;
using RegistrationLogin.Models;
using RegistrationLogin.Helpers;

namespace RegistrationLogin.Controllers
{
    public class Home : Controller
    {
        UsersContext _db= new UsersContext();   
        public IActionResult RegistrationUser()
        {
            return View();
        }
        public IActionResult PostRegistrationValue(string regname,string regsurname,string regpassword)
        {
            LoginUser newuser = new LoginUser();
            string hashedPassword = HashHelper.GetMD5Hash(regpassword);
            newuser.Name = regname;
            newuser.Surname = regsurname;
            newuser.Password = hashedPassword;
            _db.LoginUsers.Add(newuser);
            _db.SaveChanges();
            return RedirectToAction("Login");  
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Success()
        {
            ViewBag.Products = _db.Products.ToList();
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostLoginValue(string name, string surname, string password)
        {
            string hashedPassword = HashHelper.GetMD5Hash(password);
            var user = _db.LoginUsers.FirstOrDefault(u => u.Name == name && u.Surname == surname && u.Password == hashedPassword);

            if (user != null)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

    }
}
