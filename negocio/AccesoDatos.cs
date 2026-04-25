using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace GestorArt.Negocio
{
    public class AccesoDatos
    {
        // VARIABLES GLOBALES DE LA CLASE:
        // 'conexion': Objeto que representa el "cable" físico que nos conecta a la base de datos SQL Server.
        private SqlConnection conexion;
        // 'comando': Objeto que nos permite escribir y enviar instrucciones SQL (SELECT, INSERT, UPDATE, DELETE).
        private SqlCommand comando;
        // 'lector': Objeto tipo cursor que nos permite leer fila por fila los resultados que devuelve un SELECT.
        private SqlDataReader lector;

        // PROPIEDAD LECTOR:
        // Exponemos el lector hacia afuera para que otras clases (como ArticuloNegocio) 
        // puedan leer los datos una vez que se ejecutó la consulta, sin romper el encapsulamiento.
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            // CONSTRUCTOR: Se ejecuta cada vez que hacemos un "new AccesoDatos()".
            // MEJORA RESPECTO AL PROFESOR: 
            // El profesor escribió la ruta directamente en el código: new SqlConnection("server=...").
            // Nosotros usamos ConfigurationManager para leer la cadena de conexión desde el archivo App.config.
            // ¿Por qué es mejor? Si el día de mañana cambiamos de servidor o base de datos, 
            // solo cambiamos el texto en App.config sin tener que modificar ni recompilar este código.
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CatalogoDB"].ConnectionString);
            // Inicializamos el comando listo para ser usado.
            comando = new SqlCommand();
        }

        // Método para cargar la instrucción SQL que queremos ejecutar.
        public void setearConsulta(string consulta)
        {
            // Le decimos al comando que vamos a ejecutar texto plano (una query SQL).
            comando.CommandType = System.Data.CommandType.Text;
            // Le pasamos el texto de la consulta (ej: "SELECT * FROM ARTICULOS").
            comando.CommandText = consulta;
        }

        // Método para evitar Inyección SQL (una vulnerabilidad de seguridad grave).
        // En lugar de concatenar strings como "INSERT INTO ... VALUES ('" + valor + "')",
        // usamos parámetros (ej: "@nombre", "Lapicera"). SQL se encarga de limpiar caracteres extraños.
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        // Método para ejecutar consultas que DEVUELVEN resultados (exclusivamente para SELECT).
        public void ejecutarLectura()
        {
            // Enlazamos nuestro comando con la conexión actual.
            comando.Connection = conexion;
            try
            {
                // Abrimos el "cable" a la base de datos.
                conexion.Open();
                // ExecuteReader ejecuta el SELECT y guarda los resultados en nuestra variable 'lector'.
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Si la BD está caída o la query tiene error, atajamos la excepción y la relanzamos.
                throw ex;
            }
        }

        // Método para ejecutar consultas que NO devuelven tablas de resultados (INSERT, UPDATE, DELETE).
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                // ExecuteNonQuery ejecuta la acción y devuelve la cantidad de filas afectadas (no lo guardamos aquí).
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // MEJORA RESPECTO AL PROFESOR:
        // El profesor solo tenía 'ejecutarAccion' (que sirve para INSERT/UPDATE/DELETE pero no devuelve nada).
        // Nosotros agregamos 'ejecutarAccionScalar'. La función ExecuteScalar de SQL sirve para ejecutar 
        // una consulta y devolver la PRIMERA columna de la PRIMERA fila. 
        // Lo usamos para hacer el INSERT del Artículo y recuperar inmediatamente el "Id" que la base de datos le asignó.
        // Ese "Id" luego lo necesitamos para poder guardar las Imágenes asociadas a ese Artículo.
        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                // ExecuteScalar devuelve un 'object', lo pasamos a String y luego lo convertimos a entero (int).
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método crucial para no dejar conexiones "colgando" y saturar el servidor.
        public void cerrarConexion()
        {
            // Si el lector se usó y quedó abierto, lo cerramos.
            if (lector != null)
                lector.Close();
            // Finalmente cerramos la conexión a la base de datos.
            conexion.Close();
        }
    }
}
