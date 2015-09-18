using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

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
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Storage));
                    if (a.IdStorage != 0 && a.IdStorage.ToString() != "")
                        crit.Add(Restrictions.Eq("IdStorage", a.IdStorage));
					if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdServidor", a.IdServidor));
					if (a.IdTipoStorage != 0 && a.IdTipoStorage.ToString() != "")
                        crit.Add(Restrictions.Eq("IdTipoStorage", a.IdTipoStorage));
					if (!string.IsNullOrEmpty(a.CapacidadAsignada))
                        crit.Add(Restrictions.Like("CapacidadAsignada", a.CapacidadAsignada));
                    if (a.IdEstatus != 0 && a.IdEstatus.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEstatus", a.IdEstatus));

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