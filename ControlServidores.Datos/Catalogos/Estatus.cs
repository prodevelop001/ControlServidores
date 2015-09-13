using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class Estatus 
	{
		public static List<Entidades.Estatus> Obtener(Entidades.Estatus a)
		{
			List<Entidades.Estatus> lista = new List<Entidades.Estatus>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Estatus));
                    if (a.IdEstatus != 0 && a.IdEstatus.ToString() != "")
                        crit.Add(Expression.Eq("IdEstatus", a.IdEstatus));
                    if (a.IdConceptoEstatus != 0 && a.IdConceptoEstatus.ToString() != "")
                        crit.Add(Expression.Eq("IdConceptoEstatus", a.IdConceptoEstatus));
					if (!string.IsNullOrEmpty(a._Estatus))
                        crit.Add(Expression.Like("Estatus", a._Estatus));					
					
                    lista = (List<Entidades.Estatus>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Estatus a)
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
		
		public static bool Actualizar(Entidades.Estatus a)
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
		
		public static bool Eliminar(Entidades.Estatus a)
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