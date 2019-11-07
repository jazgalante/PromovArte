﻿using System;
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
            return View("Login");
        }
        //public ActionResult Loginearse(Admin admin)
        //{
        //    List<Noticia> n = new List<Noticia>();
        //    bool b;
        //    if(ModelState.IsValid)
        //    {
        //        b = BD.Log(admin);

        //        n = BD.listarnoticias();
        //        ViewBag.N = n;
        //        return View("Backoffice");
        //    }
        //    else
        //    {
        //        return View("Login");
        //    }
        //}


        //[HttpPost]

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

        //public ActionResult FormAgrega()
        //{
        //ViewBag.Tips = BD.traertipos();
        //ViewBag.Id = 0;
        //ViewBag.Accion = "I";
        //    return View("FormModifica");
        //}

        //public ActionResult FormModifica(int Id)
        //{
        //ViewBag.Tips = BD.traertipos();
        //Noticia Noti = BD.traerNoticiaElegida(Id);
        //ViewBag.Accion = "E";
        //    return View("FormModifica",Noti);
        //}
    }
}