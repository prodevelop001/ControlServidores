using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class TipoStorage 
	{
		public static List<Entidades.TipoStorage> Obtener(Entidades.TipoStorage a)
		{
			List<Entidades.TipoStorage> lista = new List<Entidades.TipoStorage>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.TipoStorage));
                    if (a.IdTipoStorage != 0 && a.IdTipoStorage.ToString() != "")
                        crit.Add(Expression.Eq("IdTipoStorage", a.IdTipoStorage));
					if (!string.IsNullOrEmpty(a.Tipo))
                        crit.Add(Expression.Like("Tipo", a.Tipo));
			
                    lista = (List<Entidades.TipoStorage>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.TipoStorage a)
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
		
		public static bool Actualizar(Entidades.TipoStorage a)
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
		
		public static bool Eliminar(Entidades.TipoStorage a)
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