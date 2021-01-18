using System;
using eplayers_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eplayers_back.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel =new Equipe();
        [Route("listar")]
        public IActionResult index ()
        {
            ViewBag.equipes=equipeModel.ReadAll();
            return View();
        }
         [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form )
        {
            Equipe novaEquipe=new Equipe();
            novaEquipe.IdEquipe=Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome=form["Nome"];
            novaEquipe.Imagem=form["Imagem"];
            equipeModel.Create(novaEquipe);
            ViewBag.equipes=equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/listar");
        }
    
    }
}