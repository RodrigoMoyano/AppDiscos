using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace discos
{
    internal class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, CantidadCanciones, E.Descripcion Estilo, UrlImagenTapa from DISCOS D, ESTILOS E where D.IdEstilo = E.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader(); 

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Estilos();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
    }
}
