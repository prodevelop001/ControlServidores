using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Inventarios
{
	public class Servidor 
	{
		public static List<Entidades.Servidor> Obtener(Entidades.Servidor a)
		{
			List<Entidades.Servidor> lista = new List<Entidades.Servidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Servidor));
                    if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Expression.Eq("IdServidor", a.IdServidor));
                   if (!string.IsNullOrEmpty(a.AliasServidor))
                        crit.Add(Expression.Like("AliasServidor", a.AliasServidor));
					if (a.IdModelo != 0 && a.IdModelo.ToString() != "")
                        crit.Add(Expression.Eq("IdMarca", a.IdModelo));
					if (a.IdEspecificacion != 0 && a.IdEspecificacion.ToString() != "")
                        crit.Add(Expression.Eq("IdEspecificacion", a.IdEspecificacion));
					if (a.IdTipoServidor != 0 && a.IdTipoServidor.ToString() != "")
                        crit.Add(Expression.Eq("IdTipoServidor", a.IdTipoServidor));
					if (a.IdVirtualizador != 0 && a.IdVirtualizador.ToString() != "")
                        crit.Add(Expression.Eq("IdVirtualizador", a.IdVirtualizador));
					if (!string.IsNullOrEmpty(a.DescripcionUso))
                        crit.Add(Expression.Like("DescripcionUso", a.DescripcionUso));
					
                    lista = (List<Entidades.Servidor>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Servidor a)
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
		
		public static bool Actualizar(Entidades.Servidor a)
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
		
		public static bool Eliminar(Entidades.Servidor a)
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