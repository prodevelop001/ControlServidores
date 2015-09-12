using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Inventarios
{
	public class Almacenamiento 
	{
		public static List<Entidades.Almacenamiento> Obtener(Entidades.Almacenamiento a)
		{
			List<Entidades.Almacenamiento> lista = new List<Entidades.Almacenamiento>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Almacenamiento));
                    if (a.IdAlmacenamiento != 0 && a.IdAlmacenamiento.ToString() != "")
                        crit.Add(Expression.Eq("IdAlmacenamiento", a.IdAlmacenamiento));
                   if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Expression.Eq("IdServidor", a.IdServidor));
					if (a.IdTipoMemoria != 0 && a.IdTipoMemoria.ToString() != "")
                        crit.Add(Expression.Eq("IdTipoMemoria", a.IdTipoMemoria));
					if (!string.IsNullOrEmpty(a.Capacidad))
                        crit.Add(Expression.Like("Capacidad", a.Capacidad));
                    lista = (List<Entidades.Almacenamiento>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Almacenamiento a)
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
		
		public static bool Actualizar(Entidades.Almacenamiento a)
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
		
		public static bool Eliminar(Entidades.Almacenamiento a)
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