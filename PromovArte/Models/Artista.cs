﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PromovArte.Models
{
    public class Artista
    {
        public int IdArtista { get; set; }
        [Required(ErrorMessage = "Ingresá un nombre de usuario válido")]
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingresá una contraseña válida")]
        public string Contraseña { get; set; }
        public HttpPostedFileBase Foto { get; set; }
        public string NombreFoto { get; set; }
        public bool Destacado { get; set; }
        public string Descripcion { get; set; }



        public Artista()
        {

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