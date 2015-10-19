using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

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
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.SOxServidor),"sos");

                    if(a.Servidor != null)
                    {
                        crit.CreateAlias("sos.Servidor", "idServidor", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Servidor.IdServidor != 0 && a.Servidor.IdServidor.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idServidor.IdServidor", a.SO.IdSO)));
                    }
                    if(a.SO != null)
                    {
                        crit.CreateAlias("sos.SO", "idSO", NHibernate.SqlCommand.JoinType.InnerJoin);
                        crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idSO.IdSO", a.SO.IdSO)));
                    }
                    if(a.Estatus != null)
                    {
                        crit.CreateAlias("sos.Estatus", "idEstatus", NHibernate.SqlCommand.JoinType.InnerJoin);
                        crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idEstatus.IdEstatus", a.Estatus.IdEstatus)));
                    }
                    
                    if (a.IdSOxServidor != 0 && a.IdSOxServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdSOxServidor", a.IdSOxServidor));

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

        public static bool Eliminar(List<Entidades.SOxServidor> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.SOxServidor b)
                    {
                        session.Delete(b);
                        session.Flush();
                    });
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