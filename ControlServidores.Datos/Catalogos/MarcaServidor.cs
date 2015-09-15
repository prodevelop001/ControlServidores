using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Catalogos
{
    public class MarcaServidor
    {
        public static List<Entidades.MarcaServidor> ObtenerMarcaServidor(Entidades.MarcaServidor ms)
        {
            List<Entidades.MarcaServidor> lista = new List<Entidades.MarcaServidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.MarcaServidor));
                    if (ms.IdMarca != 0 && ms.IdMarca.ToString() != "")
                        crit.Add(Restrictions.Eq("IdMarcas", ms.IdMarca));
                    if (!string.IsNullOrEmpty(ms.NombreMarca))
                        crit.Add(Restrictions.Like("Nombrerca", ms.NombreMarca));

                    lista = (List<Entidades.MarcaServidor>)crit.List<Entidades.MarcaServidor>();
                }
            }
            catch(Exception err)
            {
                return lista;
            }

            return lista;

        }

        public static bool Nuevo(Entidades.MarcaServidor a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Save(a);
                    session.Flush();
                    session.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool Actualizar(Entidades.MarcaServidor a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Update(a);
                    session.Flush();
                    session.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool Eliminar(Entidades.MarcaServidor a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Delete(a);
                    session.Flush();
                    session.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
