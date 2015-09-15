using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Inventarios
{
	public class SOxServidor 
	{
		public static List<Entidades.SOxServidor> Obtener(Entidades.SOxServidor a)
		{
			List<Entidades.SOxServidor> lista = new List<Entidades.SOxServidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.SOxServidor));
                    if (a.IdSOxServidor != 0 && a.IdSOxServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdSOxServidor", a.IdSOxServidor));
                    if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdServidor", a.IdServidor));
					if (a.IdSO != 0 && a.IdSO.ToString() != "")
                        crit.Add(Restrictions.Eq("IdSO", a.IdSO));
                    if (a.IdEstatus != 0 && a.IdEstatus.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEstatus", a.IdEstatus));

                    lista = (List<Entidades.SOxServidor>)crit.List<Entidades.SOxServidor>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.SOxServidor a)
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
		
		public static bool Actualizar(Entidades.SOxServidor a)
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
		
		public static bool Eliminar(Entidades.SOxServidor a)
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