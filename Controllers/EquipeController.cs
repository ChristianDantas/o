using System;
using System.IO;
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
        
        public IActionResult Cadastrar(IFormCollection form )
        {
            Equipe novaEquipe=new Equipe();
            novaEquipe.IdEquipe=Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome=form["Nome"];
          if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaEquipe.Imagem   = file.FileName;                
            }
            else
            {
                novaEquipe.Imagem   = "padrao.png";
            }


            equipeModel.Create(novaEquipe);
            ViewBag.equipes=equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/listar");
        }
    
    }
}