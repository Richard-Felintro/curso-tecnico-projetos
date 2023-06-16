using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projeto_gamer_fullstack.Infra;
using projeto_gamer_fullstack.Models;

namespace projeto_gamer_fullstack.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        [TempData]
        public string Message { get; set; }

        [Route("Login")]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            string emailInput = form["Email"].ToString();
            string senhaInput = form["Senha"].ToString();

            Jogador jogador = c.Jogador.FirstOrDefault(j => j.Email == emailInput && j.Senha == senhaInput)!;

            if (jogador != null)
            {
                HttpContext.Session.SetString("UserName", jogador.Nome);
                return LocalRedirect("~/");
            }
            Message = "Dados inválidos, tente novamente!";

            return LocalRedirect("~/Login/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return LocalRedirect("~/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}