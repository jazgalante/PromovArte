using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromovArte.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public int Tipo { get; set; }
        public string Titulo { get; set; }
        public HttpPostedFileBase Foto { get; set; }
        public string NombreImagen { get; set; }
        public string Descripcion { get; set; }
        public bool Destacado { get; set; }
        public DateTime Fecha { get; set; }
        public int Artista { get; set; }


        public Evento()
        {

        }

        public Evento(int idEvento, int tipo, string titulo, HttpPostedFileBase foto, string nombreImagen, string descripcion, bool destacado, DateTime fecha, int artista)
        {
            IdEvento = idEvento;
            Tipo = tipo;
            Titulo = titulo;
            Foto = foto;
            NombreImagen = nombreImagen;
            Descripcion = descripcion;
            Destacado = destacado;
            Fecha = fecha;
            Artista = artista;
        }
    }
}