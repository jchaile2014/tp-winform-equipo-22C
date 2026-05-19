using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listarPorArticulo(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, IdArticulo, ImagenUrl From IMAGENES Where IdArticulo = @idArticulo");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id = (int)datos.Lector["Id"];
                    img.IdArticulo = (int)datos.Lector["IdArticulo"];
                    img.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    lista.Add(img);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }

        public void agregar(int idArticulo, List<Imagen> imagenes)
        {
            foreach (Imagen img in imagenes)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("Insert into IMAGENES (IdArticulo, ImagenUrl) values (@idArticulo, @imagenUrl)");
                    datos.setearParametro("@idArticulo", idArticulo);
                    datos.setearParametro("@imagenUrl", img.ImagenUrl);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
        }

        public void eliminarPorArticulo(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from IMAGENES where IdArticulo = @idArticulo");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
