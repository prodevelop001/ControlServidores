using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Seguridad
{
	public class RolUsuario 
	{
		public static List<Entidades.RolUsuario> Obtener(Entidades.RolUsuario a)
		{
			List<Entidades.RolUsuario> lista = new List<Entidades.RolUsuario>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.RolUsuario));
                    if (a.IdRol != 0 && a.IdRol.ToString() != "")
                        crit.Add(Expression.Eq("IdRol", a.IdRol));
                   if (!string.IsNullOrEmpty(a.NombreRol))
                        crit.Add(Expression.Eq("NombreRol", a.NombreRol));
					
					//crit.Add(Expression.Eq("C", a.C));
					//crit.Add(Expression.Eq("R", a.R));
					//crit.Add(Expression.Eq("U", a.U));
					//crit.Add(Expression.Eq("D", a.D));
                    
					lista = (List<Entidades.RolUsuario>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.RolUsuario a)
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
		
		public static bool Actualizar(Entidades.RolUsuario a)
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
		
		public static bool Eliminar(Entidades.RolUsuario a)
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