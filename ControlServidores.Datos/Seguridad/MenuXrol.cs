using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

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
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.MenuXrol));
                    if (a.Id != 0 && a.Id.ToString() != "")
                        crit.Add(Expression.Eq("Id", a.Id));
                   if (a.IdMenu != 0 && a.IdMenu.ToString()  != "")
                        crit.Add(Expression.Eq("IdMenu", a.IdMenu));
					if (a.IdRol != 0 && a.IdRol.ToString()  != "")
                        crit.Add(Expression.Eq("IdRol", a.IdRol));
                    lista = (List<Entidades.MenuXrol>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.MenuXrol a)
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
		
		public static bool Actualizar(Entidades.MenuXrol a)
		{
			try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(a);
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
		
		public static bool Eliminar(Entidades.MenuXrol a)
		{
			try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(a);
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