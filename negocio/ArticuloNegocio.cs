using System;
using System.Collections.Generic;
using GestorArt.Dominio;

namespace GestorArt.Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull)) aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull)) aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull)) aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull)) aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
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

            // Cargar imagenes
            foreach (Articulo art in lista)
            {
                AccesoDatos datosImg = new AccesoDatos();
                try
                {
                    datosImg.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                    datosImg.setearParametro("@IdArticulo", art.Id);
                    datosImg.ejecutarLectura();
                    while (datosImg.Lector.Read())
                    {
                        Imagen img = new Imagen();
                        img.Id = (int)datosImg.Lector["Id"];
                        img.IdArticulo = (int)datosImg.Lector["IdArticulo"];
                        img.ImagenUrl = (string)datosImg.Lector["ImagenUrl"];
                        art.Imagenes.Add(img);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datosImg.cerrarConexion();
                }
            }

            return lista;
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) OUTPUT INSERTED.Id VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@precio", nuevo.Precio);
                
                int idGenerado = datos.ejecutarAccionScalar();

                foreach (Imagen img in nuevo.Imagenes)
                {
                    AccesoDatos datosImg = new AccesoDatos();
                    datosImg.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)");
                    datosImg.setearParametro("@idArticulo", idGenerado);
                    datosImg.setearParametro("@imagenUrl", img.ImagenUrl);
                    datosImg.ejecutarAccion();
                    datosImg.cerrarConexion();
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
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id");
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);
                datos.ejecutarAccion();

                // Para actualizar imagenes simplemente borramos las anteriores y metemos las nuevas, pero por ahora solo el requerimiento básico.
                // Podríamos requerir otra query para borrar y reinsertar las fotos.
                AccesoDatos datosBorrarImg = new AccesoDatos();
                datosBorrarImg.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datosBorrarImg.setearParametro("@idArticulo", art.Id);
                datosBorrarImg.ejecutarAccion();
                datosBorrarImg.cerrarConexion();

                foreach (Imagen img in art.Imagenes)
                {
                    AccesoDatos datosImg = new AccesoDatos();
                    datosImg.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)");
                    datosImg.setearParametro("@idArticulo", art.Id);
                    datosImg.setearParametro("@imagenUrl", img.ImagenUrl);
                    datosImg.ejecutarAccion();
                    datosImg.cerrarConexion();
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
        }

        public void eliminar(int id)
        {
            // Primero borrar la referencia en IMAGENES por foreign key (o hacerlo desde DB con on cascade)
            AccesoDatos datosImg = new AccesoDatos();
            try
            {
                datosImg.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datosImg.setearParametro("@idArticulo", id);
                datosImg.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosImg.cerrarConexion();
            }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            // Lógica para el filtro avanzado (Etapa 2)
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoría") // Agregado Categoria para más flexibilidad
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion LIKE '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull)) aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull)) aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull)) aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull)) aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
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

            // Cargar imágenes de la lista filtrada
            foreach (Articulo art in lista)
            {
                AccesoDatos datosImg = new AccesoDatos();
                try
                {
                    datosImg.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                    datosImg.setearParametro("@IdArticulo", art.Id);
                    datosImg.ejecutarLectura();
                    while (datosImg.Lector.Read())
                    {
                        Imagen img = new Imagen();
                        img.Id = (int)datosImg.Lector["Id"];
                        img.IdArticulo = (int)datosImg.Lector["IdArticulo"];
                        img.ImagenUrl = (string)datosImg.Lector["ImagenUrl"];
                        art.Imagenes.Add(img);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datosImg.cerrarConexion();
                }
            }
            return lista;
        }
    }
}

