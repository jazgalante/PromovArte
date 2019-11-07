using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromovArte.Models
{
    public class Artista
    {
        public int IdArtista { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public HttpPostedFileBase Foto { get; set; }
        public string NombreFoto { get; set; }
        public bool Destacado { get; set; }
        public string Descripcion { get; set; }



        public Artista()
        {
            Nombre = "Leo es crack!";
        }

        public Artista(int idArtista, string nombreUsuario, string nombre, string apellido, string contraseña, bool destacado, string descripcion, string nombreFoto)
        {
            IdArtista = idArtista;
            NombreUsuario = nombreUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Destacado = destacado;
            Descripcion = descripcion;
            NombreFoto = nombreFoto;
        }
    }
}