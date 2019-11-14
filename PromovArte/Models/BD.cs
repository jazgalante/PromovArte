using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PromovArte.Models
{
    public static class BD
    {
        public static string connectionString = "Server= A-CAM-03;Database=PromovArte;User Id= alumno; Password= alumno;";
        public static SqlConnection Conectar()
        {
            SqlConnection a = new SqlConnection(connectionString);
            a.Open();
            return a;
        }
        public static void Desconectar(SqlConnection conexion)
        {
            conexion.Close();
        }




        public static Artista TraerUnArtista(int IdArtista)
        {
            Artista art = new Artista();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From Artistas WHERE IdArtista=" + IdArtista;
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                art.IdArtista = Convert.ToInt32(dataReader1["IdArtista"]);
                art.Nombre = dataReader1["Nombre"].ToString();
                art.Apellido = dataReader1["Apellido"].ToString();
                art.NombreUsuario = dataReader1["NombreUsuario"].ToString();
                art.Contraseña = dataReader1["Contraseña"].ToString();
                art.Destacado = Convert.ToBoolean(dataReader1["Destacado"]);
                art.Descripcion = dataReader1["Descripcion"].ToString();
                art.NombreFoto = dataReader1["Foto"].ToString();
            }
            Desconectar(Conexion);
            return art;

        }
        public static Evento TraerUnEvento(int IdEvento)
        {
            Evento ev = new Evento();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From Eventos WHERE IdEvento=" + IdEvento;
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                ev.IdEvento = Convert.ToInt32(dataReader1["IdEvento"]);
                ev.Tipo = Convert.ToInt32(dataReader1["Tipo"]);
                ev.Descripcion = dataReader1["Descripcion"].ToString();
                ev.Titulo = dataReader1["Titulo"].ToString();
                ev.Artista = Convert.ToInt32(dataReader1["Artista"]);
                ev.NombreImagen = dataReader1["Foto"].ToString();
                ev.Destacado = Convert.ToBoolean(dataReader1["Destacado"]);
                ev.Fecha = Convert.ToDateTime(dataReader1["Fecha"]);
            }
            Desconectar(Conexion);
            return ev;

        }

        public static Evento TraerEventoDestacado()
        {
            Evento even = new Evento();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From Eventos WHERE Destacado=1 ";
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                even.IdEvento = Convert.ToInt32(dataReader1["IdEvento"]);
                even.Tipo = Convert.ToInt32(dataReader1["Tipo"]);
                even.Descripcion = dataReader1["Descripcion"].ToString();
                even.Titulo = dataReader1["Titulo"].ToString();
                even.Artista = Convert.ToInt32(dataReader1["Artista"]);
                even.NombreImagen = dataReader1["Foto"].ToString();
                even.Destacado = Convert.ToBoolean(dataReader1["Destacado"]);
                even.Fecha = Convert.ToDateTime(dataReader1["Fecha"]);

            }
            Desconectar(Conexion);
            return even;

        }
        public static Artista TraerArtistaDestacado()
        {
            Artista ar = new Artista();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From Artistas WHERE Destacado=1";
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                ar.IdArtista = Convert.ToInt32(dataReader1["IdArtista"]);
                ar.NombreUsuario = dataReader1["NombreUsuario"].ToString();
                ar.Nombre = dataReader1["Nombre"].ToString();
                ar.Apellido = dataReader1["Apellido"].ToString();
                ar.Contraseña = dataReader1["Contraseña"].ToString();
                ar.Destacado = Convert.ToBoolean(dataReader1["Destacado"]);
                ar.Descripcion = dataReader1["Descripcion"].ToString();
                ar.NombreFoto = dataReader1["Foto"].ToString();
            }
            Desconectar(Conexion);
            return ar;
        }
        // BUSCAR OTROS DESTACADOS Y DES-DESTACAR

        public static void DestacarEvento(int IdEvento)
        {
            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Eventos SET Destacado = 1 WHERE IdEvento = " + IdEvento;
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);
        }
        public static void DestacarArtista (int IdArtista)
        {
            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Artistas SET Destacado = 0 UPDATE Artistas SET Destacado = 1 WHERE IdEvento = " + IdArtista;
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);
        }




        public static List<TipoEvento> ListarTipoEventos()
        {
            List<TipoEvento> ListaTipoEvento = new List<TipoEvento>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From TipoEventos";
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                TipoEvento tpe = new TipoEvento();
                tpe.IdTipoEvento = Convert.ToInt32(dataReader1["IdTipoEvento"]);
                tpe.Nombre = dataReader1["Nombre"].ToString();
                ListaTipoEvento.Add(tpe);
            }
            Desconectar(Conexion);
            return ListaTipoEvento;

        }
        public static List<Evento> ListarEventosXTipo(int Tipo)
        {
            List<Evento> ListaEventosTipo = new List<Evento>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From Eventos WHERE Tipo = " + Tipo.ToString();
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                Evento evento = new Evento();
                evento.IdEvento = Convert.ToInt32(dataReader1["IdEvento"]);
                evento.Tipo = Convert.ToInt32(dataReader1["Tipo"]);
                evento.Descripcion = dataReader1["Descripcion"].ToString();
                evento.Titulo = dataReader1["Titulo"].ToString();
                evento.Artista = Convert.ToInt32(dataReader1["Artista"]);
                evento.NombreImagen = dataReader1["Foto"].ToString();
                evento.Destacado = Convert.ToBoolean(dataReader1["Destacado"]);
                evento.Fecha = Convert.ToDateTime(dataReader1["Fecha"]);
                ListaEventosTipo.Add(evento);
            }
            Desconectar(Conexion);
            return ListaEventosTipo;

        }
        public static List<Evento> ListarEventosXArtista(int Artista)
        {
            List<Evento> ListaEventosArt = new List<Evento>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta1 = Conexion.CreateCommand();
            Consulta1.CommandType = System.Data.CommandType.Text;
            Consulta1.CommandText = "SELECT * From Evento WHERE Artista = " + Artista.ToString();
            SqlDataReader dataReader1 = Consulta1.ExecuteReader();
            while (dataReader1.Read())
            {
                Evento evento = new Evento();
                evento.IdEvento = Convert.ToInt32(dataReader1["IdEvento"]);
                evento.Tipo = Convert.ToInt32(dataReader1["Tipo"]);
                evento.Descripcion = dataReader1["Descripcion"].ToString();
                evento.Titulo = dataReader1["Titulo"].ToString();
                evento.Artista = Convert.ToInt32(dataReader1["Artista"]);
                evento.NombreImagen = dataReader1["Foto"].ToString();
                evento.Destacado = Convert.ToBoolean(dataReader1["Destacado"]);
                evento.Fecha = Convert.ToDateTime(dataReader1["Fecha"]);

                ListaEventosArt.Add(evento);
            }
            Desconectar(Conexion);
            return ListaEventosArt;

        }
        public static List<Evento> ListarTodosEventos()
        {
            List<Evento> ListaEventos = new List<Evento>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * FROM Eventos";

            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int ide = Convert.ToInt32(Lector["IdEvento"]);
                int idte = Convert.ToInt32(Lector["Tipo"]);
                string des = Lector["Descripcion"].ToString();
                string tit = Lector["Titulo"].ToString();
                int art = Convert.ToInt32(Lector["Artista"]);
                string nima = Lector["Foto"].ToString();
                bool dest = Convert.ToBoolean(Lector["Destacado"]);
                DateTime fec = Convert.ToDateTime(Lector["Fecha"]);
                Evento eve = new Evento(ide, idte, tit, nima, des, dest, fec, art);
                ListaEventos.Add(eve);
            }
            Desconectar(Conn);
            return ListaEventos;
        }


 

        public static void CrearEvento(Evento eve)
        {

            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "INSERT INTO Eventos (Tipo, Descripcion, Titulo, Artista, Foto, Destacado, Fecha) VALUES (" + eve.Tipo + ", '" + eve.Descripcion + "', '" + eve.Titulo + "', '" + eve.Artista + "', '" + eve.Foto + "','" + 0 + "', '" + eve.Fecha + "')";
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);

        }
        public static void BorrarEvento(int IdEvento)
        {
            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "DELETE FROM Eventos WHERE IdEvento = " + IdEvento;
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);
        }
        public static void EditarEvento(Evento ev)
        {

            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Eventos SET Titulo = '" + ev.Titulo + "', Foto = '" + ev.NombreImagen + "', Descripcion = '" + ev.Descripcion + "' WHERE " + "IdEvento = " + ev.IdEvento;
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);

        }
        
        public static void CrearArtista(Artista arti)
        {

            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "INSERT INTO Artistas (Nombre, Apellido, NombreUsuario, Contraseña, Destacado, Descripcion) VALUES (" + arti.Nombre + ", '" + arti.Apellido + "', '" + arti.NombreUsuario + "', '" + arti.Contraseña + "', '" + 0 + "', '" + arti.Descripcion + arti.NombreFoto + ")";
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);
        }
        public static void BorrarArtista(int IdArtista)
        {
            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "DELETE FROM Artistas WHERE IdArtista = " + IdArtista;
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);
        }
        public static void EditarArtista(Artista ar)
        {

            SqlConnection Conec = Conectar();
            SqlCommand Consulta = Conec.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Artistas SET Nombre = '" + ar.Nombre + "', Apellido = '" + ar.Apellido + "', NombreUsuario = '" + ar.NombreUsuario + "', Contraseña = '" + ar.Contraseña + "', Foto = '" + ar.NombreFoto + "', Destacado = '" + 0 + "', Descripcion = '" + ar.Descripcion + "' WHERE " + "IdArtista = " + ar.IdArtista;
            Consulta.ExecuteNonQuery();
            Desconectar(Conec);

        }

        public static bool ExisteUsuario(Artista art)
        {
            bool devolver = false;
            List<Artista> ListaArtistas = new List<Artista>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * FROM Artistas WHERE NombreUsuario='" + art.NombreUsuario + "'AND Contraseña='" + art.Contraseña + "'";

            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                devolver = true;
            }
            Desconectar(Conn);
            return devolver;
        }
    }
}