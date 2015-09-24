using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class ConceptoEstatus
    {
        /// <summary>
        /// Consulta todos lo elementos de ConceptoEstatus
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.ConceptoEstatus></returns>
        public static List<Entidades.ConceptoEstatus> Obtener(Entidades.ConceptoEstatus a)
        {
            return Datos.Catalogos.ConceptoEstatus.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en  ConceptoEstatus. 
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.ConceptoEstatus a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.ConceptoEstatus> conceptosL = new List<Entidades.ConceptoEstatus>();
            conceptosL = Datos.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus() { Concepto = a.Concepto });

            if(conceptosL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un concepto con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.ConceptoEstatus.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Concepto almacenado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "El proceso no se completo.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza un registo existente en ConceptoEstatus
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.ConceptoEstatus a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.ConceptoEstatus> conceptosL = new List<Entidades.ConceptoEstatus>();
            conceptosL = Datos.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus() { Concepto = a.Concepto });
            var validarDatos = from l in conceptosL
                               where l.IdConceptoEstatus != a.IdConceptoEstatus
                               select l;
            conceptosL = validarDatos.ToList();
            if (conceptosL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un concepto con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.ConceptoEstatus.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Concepto actualizado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "El proceso no se completo.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Elimina un registo de ConceptoEstatus
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.ConceptoEstatus a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Estatus> estatusL = new List<Entidades.Estatus>();
            estatusL = Datos.Catalogos.Estatus.Obtener(new Entidades.Estatus() { IdConceptoEstatus = a.IdConceptoEstatus });
            if (estatusL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Existe un estatus con este concepto, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.ConceptoEstatus.Eliminar(a);
                if(resultado.resultado ==  true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Concepto eliminado.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "El proceso no se completo.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }
    }
}
