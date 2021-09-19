using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Conexion
{
    public class ArticuloConexion
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, b.Descripcion as Marca, a.IdCategoria, c.Descripcion as Categoria, ImagenUrl, Precio from articulos a join Marcas b on a.IdMarca = b.Id join Categorias c on a.IdCategoria = c.Id");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Marca = new Marca(datos.Lector.GetInt32(4), (string)datos.Lector["Marca"]);
                    aux.Categoria = new Categoria(datos.Lector.GetInt32(6), (string)datos.Lector["Categoria"]);
                    aux.UrlImagen = datos.Lector.GetString(8);
                    aux.Precio = datos.Lector.GetDecimal(9);
                    lista.Add(aux);
                }
                return lista;
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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @urlImagen, @precio)");
                
                datos.agregarParametro("@nombre", nuevo.Nombre);
                datos.agregarParametro("@codigo", nuevo.Codigo);
                datos.agregarParametro("@descripcion", nuevo.Descripcion);
                datos.agregarParametro("@idMarca", nuevo.Marca.Id);
                datos.agregarParametro("@idCategoria", nuevo.Categoria.Id);
                datos.agregarParametro("@urlImagen", nuevo.UrlImagen);
                datos.agregarParametro("@precio", nuevo.Precio);

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
        public void eliminar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.agregarParametro("@id", articulo.Id);
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, idMarca=@idMarca, idCategoria=@idCategoria, ImagenUrl=@imagenUrl, Precio=@precio where Id=@id");
                datos.agregarParametro("@codigo", articulo.Codigo);
                datos.agregarParametro("@nombre",articulo.Nombre);
                datos.agregarParametro("@descripcion",articulo.Descripcion);
                datos.agregarParametro("@idMarca",articulo.Marca.Id);
                datos.agregarParametro("@idCategoria",articulo.Categoria.Id);
                datos.agregarParametro("@imagenUrl",articulo.UrlImagen);
                datos.agregarParametro("@precio",articulo.Precio);
                datos.agregarParametro("@id ", articulo.Id);

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
