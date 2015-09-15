using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class Empresa 
	{
		public static List<Entidades.Empresa> Obtener(Entidades.Empresa a)
		{
			List<Entidades.Empresa> lista = new List<Entidades.Empresa>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Empresa));
                    if (a.IdEmpresa != 0 && a.IdEmpresa.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEmpresa", a.IdEmpresa));
                   if (!string.IsNullOrEmpty(a.Nombre))
                        crit.Add(Restrictions.Like("Nombre", a.Nombre));
					if (!string.IsNullOrEmpty(a.Telefono))
                        crit.Add(Restrictions.Like("Telefono", a.Telefono));
					if (!string.IsNullOrEmpty(a.Direccion))
                        crit.Add(Restrictions.Like("Direccion", a.Direccion));
					
                    lista = (List<Entidades.Empresa>)crit.List<Entidades.Empresa>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Empresa a)
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
		
		public static bool Actualizar(Entidades.Empresa a)
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
		
		public static bool Eliminar(Entidades.Empresa a)
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