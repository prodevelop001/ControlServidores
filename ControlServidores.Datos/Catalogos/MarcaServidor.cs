using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
    public class MarcaServidor
    {
        public static List<Entidades.MarcaServidor> obtenerMarcaServidor(Entidades.MarcaServidor ms)
        {
            List<Entidades.MarcaServidor> lista = new List<Entidades.MarcaServidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.MarcaServidor));
                    if (ms.IdMarca != 0 && ms.IdMarca.ToString() != "")
                        crit.Add(Expression.Eq("IdMarcas", ms.IdMarca));
                    if (!string.IsNullOrEmpty(ms.NombreMarca))
                        crit.Add(Expression.Eq("Nombrerca", ms.NombreMarca));

                    lista = (List<Entidades.MarcaServidor>)crit.List<Entidades.MarcaServidor>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;

        }
    }
}
