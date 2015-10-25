using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Inventarios
{
	public class Storage 
	{
		public static List<Entidades.Storage> Obtener(Entidades.Storage a)
		{
			List<Entidades.Storage> lista = new List<Entidades.Storage>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Storage),"st");

                    if(a.TipoStorage != null)
                    {
                        crit.CreateAlias("st.TipoStorage", "idTipoStorage", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.TipoStorage.IdTipoStorage != 0 && a.TipoStorage.IdTipoStorage.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idTipoStorage.IdTipoStorage", a.TipoStorage.IdTipoStorage)));
                    }
                    if(a.Estatus != null)
                    {
                        crit.CreateAlias("st.Estatus", "idEstatus", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Estatus.IdEstatus != 0 && a.Estatus.IdEstatus.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idEstatus.IdEstatus", a.Estatus.IdEstatus)));
                    }
                    if(a.Servidor != null)
                    {
                        crit.CreateAlias("st.Servidor", "idServidor", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Servidor.IdServidor != 0 && a.Servidor.IdServidor.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idServidor.IdServidor", a.Servidor.IdServidor)));
                    }

                    if (a.IdStorage != 0 && a.IdStorage.ToString() != "")
                        crit.Add(Restrictions.Eq("IdStorage", a.IdStorage));					
					if (!string.IsNullOrEmpty(a.CapacidadAsignada))
                        crit.Add(Restrictions.Like("CapacidadAsignada", a.CapacidadAsignada));
                    
                    lista = (List<Entidades.Storage>)crit.List<Entidades.Storage>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Storage a)
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
		
		public static bool Actualizar(Entidades.Storage a)
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
		
		public static bool Eliminar(Entidades.Storage a)
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

        public static bool Eliminar(List<Entidades.Storage> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.Storage b)
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