using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PromovArte.Models;

namespace PromovArte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.EvDest = BD.TraerEventoDestacado();
            ViewBag.ArtDest = BD.TraerArtistaDestacado();
            ViewBag.ListaTipo = BD.ListarTipoEventos();
            ViewBag.ListaEventos = BD.ListarTodosEventos();
            return View();
        }

        public ActionResult ListadoTipoEventos()
        {
            List<TipoEvento> Tpe = new List<TipoEvento>();
            Tpe = BD.ListarTipoEventos();
            ViewBag.TipoEvento = Tpe;
            return View();
        }


        public ActionResult DetalleEvento(int IdEvento)
        {
            Evento MiEvento = new Evento();
            MiEvento = BD.TraerUnEvento(IdEvento);
            ViewBag.Evento = MiEvento;
            return View();
        }
        public ActionResult DetalleArtista(int IdArtista)
        {
            Artista MiArtista = new Artista();
            MiArtista = BD.TraerUnArtista(IdArtista);
            List<Evento> MisPublicaciones = BD.ListarEventosXArtista(IdArtista);
            ViewBag.MisPublicaciones = MisPublicaciones;
            ViewBag.Artista = MiArtista;
            return View();
        }


        public ActionResult ListadoEventos(int IdTipoEvento)
        {

            ViewBag.ListaEventosTipo = BD.ListarEventosXTipo(IdTipoEvento);
            return View();
        }
        public ActionResult ListadoEventosPorArtista(int IdArtista)
        {

            ViewBag.ListaEventosArt = BD.ListarEventosXArtista(IdArtista);
            return View();
        }


        public ActionResult TraerUnEvento(int IdEvento)
        {
            ViewBag.TraerEvento = BD.TraerUnEvento(IdEvento);
            return View();
        }
        public ActionResult TraerUnArtista(int IdArtista)
        {
            ViewBag.TraerArtista = BD.TraerUnArtista(IdArtista);
            return View();
        }
    }
}