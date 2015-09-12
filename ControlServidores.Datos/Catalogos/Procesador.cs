using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class Procesador 
	{
		public static List<Entidades.Procesador> Obtener(Entidades.Procesador a)
		{
			List<Entidades.Procesador> lista = new List<Entidades.Procesador>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Procesador));
                    if (a.IdProcesador != 0 && a.IdProcesador.ToString() != "")
                        crit.Add(Expression.Eq("IdProcesador", a.IdProcesador));
                   if (!string.IsNullOrEmpty(a.Nombre))
                        crit.Add(Expression.Like("Nombre", a.Nombre));
					if (a.NumCores != 0 && a.NumCores.ToString() != "")
                        crit.Add(Expression.Eq("NumCores", a.NumCores));
					if (!string.IsNullOrEmpty(a.Velocidad))
                        crit.Add(Expression.Like("Velocidad", a.Velocidad));
					if (!string.IsNullOrEmpty(a.Cache))
                        crit.Add(Expression.Like("Cache", a.Cache));
					if (!string.IsNullOrEmpty(a.TamanoPalabra))
                        crit.Add(Expression.Like("TamanoPalabra", a.TamanoPalabra));
					
                    lista = (List<Entidades.Procesador>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Procesador a)
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
		
		public static bool Actualizar(Entidades.Procesador a)
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
		
		public static bool Eliminar(Entidades.Procesador a)
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