using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Inventarios
{
	public class Almacenamiento 
	{
		public static List<Entidades.Almacenamiento> Obtener(Entidades.Almacenamiento a)
		{
			List<Entidades.Almacenamiento> lista = new List<Entidades.Almacenamiento>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Almacenamiento),"A");

                    crit.CreateAlias("A.TipoMemoria", "idTipoMemoria", NHibernate.SqlCommand.JoinType.InnerJoin);

                    if (a.IdAlmacenamiento != 0 && a.IdAlmacenamiento.ToString() != "")
                        crit.Add(Restrictions.Eq("IdAlmacenamiento", a.IdAlmacenamiento));
                   if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdServidor", a.IdServidor));
					if (a.IdTipoMemoria != 0 && a.IdTipoMemoria.ToString() != "")
                        crit.Add(Restrictions.Eq("IdTipoMemoria", a.IdTipoMemoria));
					if (!string.IsNullOrEmpty(a.Capacidad))
                        crit.Add(Restrictions.Like("Capacidad", a.Capacidad));
                    if (a.IdEstatus != 0 && a.IdEstatus.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEstatus", a.IdEstatus));

                    lista = (List<Entidades.Almacenamiento>)crit.List<Entidades.Almacenamiento>();
                }
            }
            catch(Exception err)
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Almacenamiento a)
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
		
		public static bool Actualizar(Entidades.Almacenamiento a)
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
		
		public static bool Eliminar(Entidades.Almacenamiento a)
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

        public static bool Eliminar(List<Entidades.Almacenamiento> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate(Entidades.Almacenamiento b) 
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