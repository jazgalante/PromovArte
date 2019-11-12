using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PromovArte.Models;

namespace PromovArte.Controllers
{
    public class BackOfficeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BackOffice()
        {
            List<Evento> eventos = new List<Evento>();
            eventos = BD.ListarTodosEventos();
            ViewBag.eventos = eventos;
            return View("Backoffice");
        }
        
     
      public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUsuario(Artista art)
        {
            if(ModelState.IsValid)
            {
                if(BD.ExisteUsuario(art))
                 {

                     return RedirectToAction("Index", "BackOffice");

                 }
                 else
                {
                    ViewBag.Error = "Usuario o contraseña inválida";
                    return View("Login");
                }
            }

            else
            {
                return View("Login", art);
            }

        }
        public ActionResult DestacarEvento(int IdEvento)
        {
            BD.DestacarEvento(IdEvento);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult BorrarEvento(int IdEvento)
        {
            BD.BorrarEvento(IdEvento);
            return RedirectToAction("Index", "Backoffice");
        }

        public ActionResult DestacarArtista(int IdArtista)
        {
            BD.DestacarArtista(IdArtista);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult BorrarArtista(int IdArtista)
        {
            BD.BorrarArtista(IdArtista);
            return RedirectToAction("Index", "Backoffice");
        }

        public ActionResult ModificarCrearEvento(Evento evento, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "E")
                {
                    BD.EditarEvento(evento);

                }
                else
                {
                    BD.CrearEvento(evento);
                }
                return View("BackOffice");
            }
            else
            {
                return View("FormModifica");
            }
        }
        public ActionResult ModificarCrearArtista(Artista Artista, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "E")
                {
                    BD.EditarArtista(Artista);

                }
                else
                {
                    BD.CrearArtista(Artista);
                }
                return View("BackOffice");
            }
            else
            {
                return View("FormModifica");
            }
        }


    }
}