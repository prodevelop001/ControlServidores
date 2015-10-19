using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Inventarios
{
    public class Servidor
    {
        /// <summary>
        /// Obtiene registros de Servidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Servidor></returns>
        public static List<Entidades.Servidor> Obtener(Entidades.Servidor a)
        {
            return Datos.Inventarios.Servidor.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en Servidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Servidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Servidor> servidorL = new List<Entidades.Servidor>();
            servidorL = Datos.Inventarios.Servidor.Obtener(new Entidades.Servidor() { AliasServidor = a.AliasServidor, Modelo= a.Modelo, Especificacion = a.Especificacion, TipoServidor = a.TipoServidor });
            if (servidorL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Ya existe este alias asociado a un servidor.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Inventarios.Servidor.Nuevo(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Servidor almacenado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }

            }

            return resultado;
        }

        /// <summary>
        /// Actualiza un registro en Servidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Servidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Servidor> servidorL = new List<Entidades.Servidor>();
            servidorL = Datos.Inventarios.Servidor.Obtener(new Entidades.Servidor() { AliasServidor = a.AliasServidor });
            var validarDatos = from l in servidorL
                               where l.IdServidor != a.IdServidor
                               select l;
            servidorL = validarDatos.ToList();
            if (servidorL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Ya existe este alias asociado a un servidor.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Inventarios.Servidor.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Servidor actualizado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }

            }

            return resultado;
        }

        /// <summary>
        /// Elimina un Servidor con sus caracteristicas siempre y cuando no se encuentre con registros en Bitacora de Mantenimiento.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Servidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Servidor> servidorL = new List<Entidades.Servidor>();
            servidorL = Datos.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = a.IdServidor });
            if (servidorL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 12;
                error.descripcionCorta = "Este virtualizador tiene VM's , no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.PersonaXservidor> perXserL = new List<Entidades.PersonaXservidor>();
            perXserL = Datos.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { IdServidor = a.IdServidor });
            if (perXserL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 13;
                error.descripcionCorta = "Hay registros de mantenimiento de este servidor, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                List<Entidades.ConfRed> confRedL = new List<Entidades.ConfRed>();
                confRedL = Datos.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { IdServidor = a.IdServidor });
                if (confRedL.Count > 0)
                {
                    resultado.resultado = Datos.Inventarios.ConfRed.Eliminar(confRedL);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 4;
                        error.descripcionCorta = "Configuraciones de red eliminadas.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 5;
                        error.descripcionCorta = "Las Configuraciones de red no han sido eliminadas. Proceso no completado.";
                        resultado.errores.Add(error);
                    }
                }

                List<Entidades.Almacenamiento> almacenamientoL = new List<Entidades.Almacenamiento>();
                almacenamientoL = Datos.Inventarios.Almacenamiento.Obtener(new Entidades.Almacenamiento() { IdServidor = a.IdServidor });
                if (almacenamientoL.Count > 0)
                {
                    resultado.resultado = Datos.Inventarios.Almacenamiento.Eliminar(almacenamientoL);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 6;
                        error.descripcionCorta = "Medios de Almacenamiento eliminados.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 7;
                        error.descripcionCorta = "Los Medios de Almacenamiento no han sido eliminadas. Proceso no completado.";
                        resultado.errores.Add(error);
                    }
                }

                List<Entidades.Storage> storageL = new List<Entidades.Storage>();
                storageL = Datos.Inventarios.Storage.Obtener(new Entidades.Storage() { IdServidor = a.IdServidor });
                if (storageL.Count > 0)
                {
                    resultado.resultado = Datos.Inventarios.Storage.Eliminar(storageL);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 8;
                        error.descripcionCorta = "Storage asignado eliminado.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 9;
                        error.descripcionCorta = "El Storage asignado no ha sido eliminado. Proceso no completado.";
                        resultado.errores.Add(error);
                    }
                }

                List<Entidades.SOxServidor> sosL = new List<Entidades.SOxServidor>();
                sosL = Datos.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { IdServidor = a.IdServidor });
                if (sosL.Count > 0)
                {
                    resultado.resultado = Datos.Inventarios.SOxServidor.Eliminar(sosL);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 10;
                        error.descripcionCorta = "SO's eliminados.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 11;
                        error.descripcionCorta = "Los SO's no ha sido eliminados. Proceso no completado.";
                        resultado.errores.Add(error);
                    }
                }

                resultado.resultado = Datos.Inventarios.Servidor.Eliminar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Servidor eliminado.";
                    resultado.errores.Add(error);

                    List<Entidades.EspServidor> especificacionL = new List<Entidades.EspServidor>();
                    especificacionL = Datos.Inventarios.EspServidor.Obtener(new Entidades.EspServidor() {  IdEspecificacion = a.Especificacion.IdEspecificacion });
                    if (especificacionL.Count > 0)
                    {
                        resultado.resultado = Datos.Inventarios.EspServidor.Eliminar(especificacionL);
                        if (resultado.resultado == true)
                        {
                            error = new Entidades.Logica.Error();
                            error.idError = 2;
                            error.descripcionCorta = "Especificación eliminada.";
                            resultado.errores.Add(error);
                        }
                        else
                        {
                            error = new Entidades.Logica.Error();
                            error.idError = 0;
                            error.descripcionCorta = "La Especificación no ha sido eliminada. Proceso no completado.";
                            resultado.errores.Add(error);
                        }
                    }
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 3;
                    error.descripcionCorta = "El Servidor no ha sido eliminado. Proceso no completado.";
                    resultado.errores.Add(error);
                }

            }

            return resultado;
        }
    }
}
