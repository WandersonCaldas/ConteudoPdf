using eConteudoPdf.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace eConteudoPdf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]        
        public ActionResult Index(Conteudo model)
        {
            if (ModelState.IsValid)
            {
            
                if(System.IO.File.Exists(model.caminho))
                {
                    StringBuilder texto = new StringBuilder();

                    PdfReader reader = new PdfReader(model.caminho);

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        texto.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }

                    model.conteudo = texto.ToString();                  
                }    
            }
            Response.Write(model.conteudo);
            Response.End();
            return View(model);
        }
    }
}
