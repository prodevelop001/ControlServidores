using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class TipoServidor 
	{
		public static List<Entidades.TipoServidor> Obtener(Entidades.TipoServidor a)
		{
			List<Entidades.TipoServidor> lista = new List<Entidades.TipoServidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.TipoServidor));
                    if (a.IdTipoServidor != 0 && a.IdTipoServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdTipoServidor", a.IdTipoServidor));
                   if (!string.IsNullOrEmpty(a.Tipo))
                        crit.Add(Restrictions.Like("Tipo", a.Tipo));
					if (!string.IsNullOrEmpty(a.Descripcion))
                        crit.Add(Restrictions.Like("Descripcion", a.Descripcion));
					
                    lista = (List<Entidades.TipoServidor>)crit.List<Entidades.TipoServidor>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.TipoServidor a)
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
		
		public static bool Actualizar(Entidades.TipoServidor a)
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
		
		public static bool Eliminar(Entidades.TipoServidor a)
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