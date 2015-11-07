using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Catalogos
{
	public class SO 
	{
		public static List<Entidades.SO> Obtener(Entidades.SO a)
		{
			List<Entidades.SO> lista = new List<Entidades.SO>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.SO));
                    if (a.IdSO != 0 && a.IdSO.ToString() != "")
                        crit.Add(Restrictions.Eq("IdSO", a.IdSO));
                   if (!string.IsNullOrEmpty(a.NombreSO))
                        crit.Add(Restrictions.Like("NombreSO", a.NombreSO));

                    crit.AddOrder(Order.Asc("NombreSO"));

                    lista = (List<Entidades.SO>)crit.List<Entidades.SO>();
                }
            }
            catch(Exception err)
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.SO a)
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
		
		public static bool Actualizar(Entidades.SO a)
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
		
		public static bool Eliminar(Entidades.SO a)
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