using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Negocio.Seguridad
{
    public class Personas
    {
        /// <summary>
        /// Obtiene las personas que estan registradas para el sistema.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static List<Entidades.Personas> Obtener(Entidades.Personas a)
        {
            return Datos.Seguridad.Personas.Obtener(a);
        }

        /// <summary>
        /// Método para agregar una persona.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo (Entidades.Personas a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Personas> perL = new List<Entidades.Personas>();
            perL = Datos.Seguridad.Personas.Obtener(new Entidades.Personas() { Nombre = a.Nombre });
            if (perL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya hay una persona con los mismos datos.";
                resultado.errores.Add(error);
            }

            if (perL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya hay una correo con los mismos datos.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Seguridad.Personas.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Persona agregada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 4;
                    error.descripcionCorta = "Proceso no compleatado, vuelva a intentar por favor.";
                    resultado.errores.Add(error);
                }
            }
            
            return resultado;
        }

        /// <summary>
        /// Método para actualizar los datos de una persona, no se permiten duplicados.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Personas a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Personas> perL = new List<Entidades.Personas>();
            perL = Datos.Seguridad.Personas.Obtener(new Entidades.Personas() { Nombre = a.Nombre });
            var validarDatos = from l in perL
                               where l.IdPersona != a.IdPersona
                               select l;
            perL = validarDatos.ToList();
            if (perL.Count > 0)
            {
                resultado.resultado = false;
            }

            perL = Datos.Seguridad.Personas.Obtener(new Entidades.Personas() { Correo = a.Correo });
            validarDatos = from l in perL
                           where l.IdPersona != a.IdPersona
                           select l;
            perL = validarDatos.ToList();
            if (perL.Count > 0)
            {
                resultado.resultado = false;
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Seguridad.Personas.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Persona actualizada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 3;
                    error.descripcionCorta = "Proceso no compleatado, vuelva a intentar por favor.";
                    resultado.errores.Add(error);
                }
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Persona y/o correo duplicado.";
                resultado.errores.Add(error);
            }

            return resultado;
        }

        /// <summary>
        /// Método para eliminar una persona del sistema, no puede eliminar si tiene registros ligados.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Personas a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            List<Entidades.PersonaXservidor> perSerL = new List<Entidades.PersonaXservidor>();
            perSerL = Datos.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { IdPersona = a.IdPersona });
            

            if(perSerL.Count == 0)
            {
                resultado.resultado = Datos.Seguridad.Personas.Eliminar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Persona eliminada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 3;
                    error.descripcionCorta = "Proceso no compleatado, vuelva a intentar por favor.";
                    resultado.errores.Add(error);
                }
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "No puede ser eliminada, hay registros ligados con esta persona.";
                resultado.errores.Add(error);
            }

            return resultado;
        }
    }
}
