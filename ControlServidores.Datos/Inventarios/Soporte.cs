using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Inventarios
{
	public class Soporte 
	{
		public static List<Entidades.Soporte> Obtener(Entidades.Soporte a)
		{
			List<Entidades.Soporte> lista = new List<Entidades.Soporte>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Soporte));
                    if (a.IdSoporte != 0 && a.IdSoporte.ToString() != "")
                        crit.Add(Restrictions.Eq("IdSoporte", a.IdSoporte));
					if (a.IdEmpresa != 0 && a.IdEmpresa.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEmpresa", a.IdEmpresa));
					if (a.IdMarca != 0 && a.IdMarca.ToString() != "")
                        crit.Add(Restrictions.Eq("IdMarca", a.IdMarca));
                   				
                    lista = (List<Entidades.Soporte>)crit.List<Entidades.Soporte>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Soporte a)
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
		
		public static bool Actualizar(Entidades.Soporte a)
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
		
		public static bool Eliminar(Entidades.Soporte a)
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