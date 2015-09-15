using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Datos.Seguridad
{
    public class Menu
    {
        public static List<Entidades.Menu> obtener(Entidades.Menu mn)
        {
            List<Entidades.Menu> lista = new List<Entidades.Menu>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Menu));
                    if (mn.IdMenu != 0 && mn.IdMenu.ToString() != "")
                        crit.Add(Restrictions.Eq("IdMenu", mn.IdMenu));
                    if (!string.IsNullOrEmpty(mn.Nombre))
                        crit.Add(Restrictions.Eq("Nombre", mn.Nombre));
                    if (!string.IsNullOrEmpty(mn.Url))
                        crit.Add(Restrictions.Eq("Url", mn.Url));
                    if (mn.Nodo != 0 && mn.Nodo.ToString() != "")
                        crit.Add(Restrictions.Eq("NODO", mn.Nodo));
                    if (mn.Orden != 0 && mn.Orden.ToString() != "")
                        crit.Add(Restrictions.Eq("Orden", mn.Orden));

                    crit.Add(Restrictions.Eq("Sesion", mn.Sesion));

                    lista = (List<Entidades.Menu>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
        }

        public bool nuevo(Entidades.Menu mn)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Save(mn);
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

        public bool actualizar(Entidades.Menu mn)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(mn);
                        transaction.Commit();
                    }
                    session.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool eliminar(Entidades.Menu mn)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(mn);
                        transaction.Commit();
                    }
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
