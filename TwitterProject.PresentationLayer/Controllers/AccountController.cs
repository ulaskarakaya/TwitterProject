using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Services.Abstraction;

namespace TwitterProject.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index),"Home");
            }
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
