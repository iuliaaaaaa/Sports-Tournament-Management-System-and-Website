using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Generators;
using SynthesisAssignment.Models;

namespace SynthesisAssignment.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        private DatabaseContext db;

        public string Message;

        public LoginModel(DatabaseContext _db)
        {
            db = _db;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostButton1(IFormCollection data)
        {

            user.Username = Request.Form["username"];
            user.Password = Request.Form["pswd"];
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Email = Request.Form["email"];
            user.Role = user.Role ;
            db.Users.Add(user);
            db.SaveChanges();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));


            return RedirectToPage("Tournaments");
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Tournaments");
        }

        public IActionResult OnPostButton2(string? returnUrl)
        {
            user.Email = Request.Form["email"];
            user.Password = Request.Form["pswd"];
            var usr = Login(user.Email, user.Password);

            if (usr == null)
            {
                Message = "Sorry, seams that this account doesn't exist";

            }
            

            if (usr != null)
            {
                
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
                //claims.Add(new Claim(ClaimTypes.Role, user.Role));

                if ("iulia@staff" == user.Email)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "staff"));


                }
                else if ("spectator" == user.Role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "spectator"));

                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "player"));

                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));




                if (!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    //return Redirect(returnUrl);
                    return RedirectToPage("Tournaments");
                }
                else
                {
                    return RedirectToPage("Tournaments");
                }

            }
            else
            {

                ModelState.AddModelError("InvalidCredentials", "The supplied username and/or password is invalid");
                return Page();
               
            }

        }
        private User Login(string email, string password)
        {
            var user = db.Users.SingleOrDefault(a => a.Email.Equals(email));
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }

                if (password == user.Password)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
