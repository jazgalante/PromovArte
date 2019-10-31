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
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }



        public Artista()
        {

        }

        public Artista(int idArtista, string nombreUsuario, string descripcion, string nombre, string apellido, string contraseña)
        {
            IdArtista = idArtista;
            NombreUsuario = nombreUsuario;
            Descripcion = descripcion;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
        }
    }
}