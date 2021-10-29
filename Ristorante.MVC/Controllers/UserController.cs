using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Core.Interfaces;
using Ristorante.Core.Models;
using Ristorante.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ristorante.MVC.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IMainBusinessLayer bl;

        public UserController(IMainBusinessLayer mainBL)
        {
            bl = mainBL;
        }

        public IActionResult Login(string returnURL)
        {
            return View(new UserLoginViewModel { ReturnUrl = returnURL });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel uvm)
        {
            if (uvm == null)
            {
                return View("ExceptionError", new ResultBL(false, "Invalid User"));
            }

            var user = bl.GetUserByUsername(uvm.Username);
            if (user != null && ModelState.IsValid)
            {
                if (user.Password.Equals(uvm.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Ruolo.ToString())
                    };

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        RedirectUri = uvm.ReturnUrl
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(uvm.Password), "Password non corretta!");
                    return View(uvm);
                }
            }
            else
            {
                ModelState.AddModelError(nameof(uvm.Username), "Username non corretto");
                return View(uvm);
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden()
        {
            return View();
        }

    }
}