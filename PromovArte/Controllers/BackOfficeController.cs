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
        public ActionResult Index(int IdArt)
        {
            ViewBag.Id = IdArt;
            ViewBag.eventos = BD.ListarEventosXArtista(IdArt);
              ViewBag.ListaTipo = BD.ListarTipoEventos();
            return View();
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
                int Id = BD.ExisteUsuario(art);
                if (Id!=-1)
                 {
                    Session["Artista"] = Id;
                     return RedirectToAction("Index", "BackOffice", new { IdArt = Id });

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

            int Id = Convert.ToInt32(Session["Artista"]);
            return RedirectToAction("Index", "BackOffice", new { IdArt = Id });
        }
        public ActionResult BorrarEvento(int IdEvento)
        {
            BD.BorrarEvento(IdEvento);
            int Id = Convert.ToInt32(Session["Artista"]);
            return RedirectToAction("Index", "BackOffice", new { IdArt = Id });
        }

        public ActionResult DestacarArtista(int IdArtista)
        {
            BD.DestacarArtista(IdArtista);
            return RedirectToAction("Index", "Home", new { IdArt = IdArtista });
        }



        public ActionResult ModificarCrearEvento(string Accion, int idEvento)
        {
            ViewBag.Accion=Accion;
            if (Accion=="E")
            {
                Evento MiEve = BD.TraerUnEvento(idEvento);
                ViewBag.Tipos = BD.ListarTipoEventos();
                return View("Evento", MiEve);
            }
            if (Accion=="I")
            {
                ViewBag.Tipos = BD.ListarTipoEventos();
                return View("Evento");
            }
            return View("Error");
        }
        public ActionResult ModificarCrearArtista(int idArtista, string Accion)
        {
            if (Accion == "E")
            {
                Artista art = BD.TraerUnArtista(idArtista);
                return View("EditarArtista", art);
            }
            else
            {
                Artista art = BD.TraerUnArtista(idArtista);
                return View("Artista", art);
            }



        }

        [HttpPost]
        public ActionResult GrabarEvento(Evento even, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (even.Foto != null)
                {
                    string NuevaUbicacion = Server.MapPath("~/Content/") + even.Foto.FileName;
                    even.Foto.SaveAs(NuevaUbicacion);
                    even.NombreImagen = even.Foto.FileName;
                }
                if (Accion == "E")
                {
                    if (Session["Artista"] != null)
                    {
                        even.Artista = Convert.ToInt32(Session["Artista"]);
                    }
                    BD.EditarEvento(even);
                }
                if (Accion== "I")
                {
                    if (Session["Artista"] != null)
                    {
                        even.Artista = Convert.ToInt32(Session["Artista"]);
                    }
                    BD.CrearEvento(even);
                }
            }
            else
            {
                ViewBag.Tipos = BD.ListarTipoEventos();
                return View("Evento", even);
            }

            int Id = Convert.ToInt32(Session["Artista"]);
            return RedirectToAction("Index", "BackOffice", new { IdArt = Id });

        }

        [HttpPost]
        public ActionResult GrabarArtista(Artista art)
        {
            if (ModelState.IsValid)
            {
                if (art.Foto != null)
                {
                    string NuevaUbicacion = Server.MapPath("~/Content/") + art.Foto.FileName;
                    art.Foto.SaveAs(NuevaUbicacion);
                    art.NombreFoto = art.Foto.FileName;
                }
                
                    BD.EditarArtista(art);
               
                
            }
            else
            {
              
                
                return View("EditarArtista", art);
            }

            return RedirectToAction("Index", new { IdArt = art.IdArtista });

        }


    }
}