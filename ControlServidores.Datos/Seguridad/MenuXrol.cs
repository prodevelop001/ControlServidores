using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Seguridad
{
    public class MenuXrol
    {
        public static List<Entidades.MenuXrol> Obtener(Entidades.MenuXrol a)
        {
            List<Entidades.MenuXrol> lista = new List<Entidades.MenuXrol>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.MenuXrol), "mr");
                    if (a.Id != 0 && a.Id.ToString() != "")
                        crit.Add(Restrictions.Eq("Id", a.Id));
                    crit.CreateAlias("mr.IdMenu", "idMenu", NHibernate.SqlCommand.JoinType.InnerJoin);
                    crit.CreateAlias("mr.IdRol", "idRol", NHibernate.SqlCommand.JoinType.InnerJoin);
                    if (a.IdMenu.IdMenu != 0 && a.IdMenu.IdMenu.ToString() != "")
                    {
                        crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idMenu.IdMenu", a.IdMenu.IdMenu)));
                    }                        
                    if (a.IdRol.IdRol != 0 && a.IdRol.IdRol.ToString() != "")
                    {
                        crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idRol.IdRol", a.IdRol.IdRol)));
                    }
                    lista = (List<Entidades.MenuXrol>)crit.List<Entidades.MenuXrol>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
        }

        public static bool Nuevo(List<Entidades.MenuXrol> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.MenuXrol menuRol)
                    {
                        Entidades.Menu m = session.Load<Entidades.Menu>(menuRol.IdMenu.IdMenu);
                        Entidades.MenuXrol c = new Entidades.MenuXrol();
                        c.IdMenu = m;
                        c.IdRol = menuRol.IdRol;
                        m.MenuXrol.Add(c);
                        session.Save(c);
                        session.Flush();
                    });
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool Actualizar(List<Entidades.MenuXrol> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.MenuXrol menuRol)
                    {
                        Entidades.Menu m = session.Load<Entidades.Menu>(menuRol.IdMenu.IdMenu);
                        Entidades.MenuXrol c = new Entidades.MenuXrol();
                        c.IdMenu = m;
                        c.IdRol = menuRol.IdRol;
                        m.MenuXrol.Add(c);
                        session.Update(c);
                        session.Flush();
                    });
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool Eliminar(List<Entidades.MenuXrol> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.MenuXrol menuRol)
                    {
                        session.Delete(menuRol);
                        session.Flush();
                    });
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