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
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        Context c = new Context(); //* Instância Context que acessa o banco de dados

        [Route("Listar")]//*http:/localhost/Equipe/Listar
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Equipe = c.Equipe.ToList(); //* "Mochila" que contém equipes. 
            return View(); //* Esta "mochila" pode ser usada no View de equipe.
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            if (form["Nome"].ToString != null)
            {
                novaEquipe.Nome = form["Nome"].ToString();

                if (form.Files.Count > 0)
                {
                    var file = form.Files[0];
                    var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    var path = Path.Combine(folder, file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    novaEquipe.Imagem = file.FileName;
                }
                
                else
                {
                    novaEquipe.Imagem = "default.png";
                }
                
                c.Equipe.Add(novaEquipe);
                c.SaveChanges();
            }
            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Equipe e = c.Equipe.First(e => e.IdEquipe == id);

            c.Equipe.Remove(e);

            c.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }


        [Route("Editar/Id")]
        public IActionResult Editar(int id)
        {
            Equipe e = c.Equipe.First(e => e.IdEquipe == id);
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Equipe = e;

            return View("Edit");
        }

        [Route("Atualizar")]
        public object Atualizar(IFormCollection form, Equipe e)
        {
            Equipe novaEquipe = new Equipe();
            Equipe equipe = c.Equipe.First(x => x.IdEquipe == e.IdEquipe);

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                novaEquipe.Imagem = file.FileName;
                equipe.Imagem = novaEquipe.Imagem;
            }

            novaEquipe.Nome = form["Nome"].ToString();

            if (!string.IsNullOrEmpty(novaEquipe.Nome))
            {
                equipe.Nome = novaEquipe.Nome;
            }

            c.Equipe.Update(equipe);
            c.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}