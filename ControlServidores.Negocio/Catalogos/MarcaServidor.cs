using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class MarcaServidor
    {
        /// <summary>
        /// Obtiene el o los registros de las marcas de los servidores que se utilizan.
        /// </summary>
        /// <param name="ms"></param>
        /// <returns>Lista</returns>
        public static List<Entidades.MarcaServidor> obtenerMarcaServidor(Entidades.MarcaServidor ms)
        {
            return Datos.Catalogos.MarcaServidor.ObtenerMarcaServidor(ms);
        }

        public static Entidades.Logica.Ejecucion Nuevo(Entidades.MarcaServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.MarcaServidor> marcaL = new List<Entidades.MarcaServidor>();
            marcaL = Datos.Catalogos.MarcaServidor.ObtenerMarcaServidor(new Entidades.MarcaServidor() { NombreMarca = a.NombreMarca });
            if(marcaL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Esta marca ya se encuentra en el catalogo.";
                resultado.errores.Add(error); 
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.MarcaServidor.Nuevo(a);
                if(resultado.resultado== true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Marca almacenada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Esta marca ya se encuentra en el catalogo.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        public static Entidades.Logica.Ejecucion Actualizar(Entidades.MarcaServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.MarcaServidor> marcaL = new List<Entidades.MarcaServidor>();
            marcaL = Datos.Catalogos.MarcaServidor.ObtenerMarcaServidor(new Entidades.MarcaServidor() { NombreMarca = a.NombreMarca });
            var validarDatos = from l in marcaL
                               where l.IdMarca != a.IdMarca
                               select l;
            marcaL = validarDatos.ToList();
            if (marcaL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Esta marca ya se encuentra en el catalogo.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.MarcaServidor.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Marca actualizada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Esta marca ya se encuentra en el catalogo.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }


        public static Entidades.Logica.Ejecucion Eliminar(Entidades.MarcaServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            //consultar idMarcaservidor en Soporte y Modelos.
            List<Entidades.Modelo> modeloL = new List<Entidades.Modelo>();
            modeloL = Datos.Catalogos.Modelo.Obtener(new Entidades.Modelo() { IdMarca = a.IdMarca });
            if(modeloL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Hay modelos ligados a esta marca, no se puede realizar esta acción.";
                resultado.errores.Add(error);
            }

            List<Entidades.Soporte> soporteL = new List<Entidades.Soporte>();
            soporteL = Datos.Inventarios.Soporte.Obtener(new Entidades.Soporte() { IdModelo = a.IdMarca });
            if(soporteL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 4;
                error.descripcionCorta = "Hay un soporte ligado a esta marca, no se puede realizar esta acción.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.MarcaServidor.Eliminar(a);
                if(resultado.resultado==true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Marca eliminada.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Error en la operacion, el proceso no pudo continuar.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }
    }
}
