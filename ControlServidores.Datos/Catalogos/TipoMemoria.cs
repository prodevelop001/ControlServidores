using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class TipoMemoria 
	{
		public static List<Entidades.TipoMemoria> Obtener(Entidades.TipoMemoria a)
		{
			List<Entidades.TipoMemoria> lista = new List<Entidades.TipoMemoria>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.TipoMemoria));
                    if (a.IdTipoMemoria != 0 && a.IdTipoMemoria.ToString() != "")
                        crit.Add(Expression.Eq("IdTipoMemoria", a.IdTipoMemoria));
                   
					if (!string.IsNullOrEmpty(a.Tipo))
                        crit.Add(Expression.Like("Tipo", a.Tipo));
					
                    lista = (List<Entidades.TipoMemoria>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.TipoMemoria a)
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
		
		public static bool Actualizar(Entidades.TipoMemoria a)
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
		
		public static bool Eliminar(Entidades.TipoMemoria a)
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