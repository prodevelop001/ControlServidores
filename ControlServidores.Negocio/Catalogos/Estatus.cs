using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Negocio.Catalogos
{
    public class Estatus
    {
        /// <summary>
        /// Obtiene registros de Estatus.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Estatus></returns>
        public static List<Entidades.Estatus> Obtener(Entidades.Estatus a)
        {
            return Datos.Catalogos.Estatus.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en Estatus.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Estatus a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Estatus> estatusL = new List<Entidades.Estatus>();
            estatusL = Datos.Catalogos.Estatus.Obtener(new Entidades.Estatus() { _Estatus = a._Estatus });
            if(estatusL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Y existe un estatus con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Estatus.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Estatus almacenado correctamente.";
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
        /// Actualiza un registro en Estatus.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Estatus a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Estatus> estatusL = new List<Entidades.Estatus>();
            estatusL = Datos.Catalogos.Estatus.Obtener(new Entidades.Estatus() { _Estatus = a._Estatus });
            var validarDatos = from l in estatusL
                               where l.IdEstatus != a.IdEstatus
                               select l;
            estatusL = validarDatos.ToList();
            if (estatusL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Y existe un estatus con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Estatus.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Estatus almacenado correctamente.";
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
        /// Elimina un registro de Estatus.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Estatus a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Storage> storageL = new List<Entidades.Storage>();
            storageL = Datos.Inventarios.Storage.Obtener(new Entidades.Storage() { IdEstatus = a.IdEstatus });
            if(storageL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Este estatus esta ligado con registros de Storage, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.Almacenamiento> almacenamientoL = new List<Entidades.Almacenamiento>();
            almacenamientoL = Datos.Inventarios.Almacenamiento.Obtener(new Entidades.Almacenamiento() { IdEstatus = a.IdEstatus });
            if (almacenamientoL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 4;
                error.descripcionCorta = "Este estatus esta ligado con registros de Almacenamiento, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.SOxServidor> sosL = new List<Entidades.SOxServidor>();
            sosL = Datos.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { IdEstatus = a.IdEstatus, Estatus = null , Servidor= null, SO= null });
            if (sosL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 5;
                error.descripcionCorta = "Este estatus esta ligado con registros de SO´s, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.Servidor> servsL = new List<Entidades.Servidor>();
            servsL = Datos.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdEstatus = a.IdEstatus, Especificacion= null, Modelo= null, Red = null, TipoServidor = null });
            if (servsL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 6;
                error.descripcionCorta = "Este estatus esta ligado con registros de Servidores, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.ConfRed> confRedL = new List<Entidades.ConfRed>();
            confRedL = Datos.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { Estatus= new Entidades.Estatus() { IdEstatus = a.IdEstatus }, Servidor = null });
            if (confRedL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 7;
                error.descripcionCorta = "Este estatus esta ligado con registros de Configuraciones de Red, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.Personas> personasL = new List<Entidades.Personas>();
            personasL = Datos.Seguridad.Personas.Obtener(new Entidades.Personas() { IdEstatus = a.IdEstatus });
            if (personasL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 8;
                error.descripcionCorta = "Este estatus esta ligado con registros de Personas, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            List<Entidades.BitacoraMantenimiento> bitL = new List<Entidades.BitacoraMantenimiento>();
            bitL = Datos.Bitacoras.BitacoraMantenimiento.Obtener(new Entidades.BitacoraMantenimiento() { IdEstatus = a.IdEstatus });
            if (bitL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 9;
                error.descripcionCorta = "Este estatus esta ligado con registros de Bitacora de mantenimiento, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Estatus.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Estatus eliminado.";
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
    }
}
