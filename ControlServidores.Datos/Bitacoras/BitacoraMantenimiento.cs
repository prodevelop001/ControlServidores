using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Bitacoras
{
	public class BitacoraMantenimiento 
	{
		public static List<Entidades.BitacoraMantenimiento> Obtener(Entidades.BitacoraMantenimiento a)
		{
			List<Entidades.BitacoraMantenimiento> lista = new List<Entidades.BitacoraMantenimiento>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.BitacoraMantenimiento));
                    if (a.IdBitacora != 0 && a.IdBitacora.ToString() != "")
                        crit.Add(Restrictions.Eq("IdBitacora", a.IdBitacora));
					if (!string.IsNullOrEmpty(a.DescripcionMantenimiento))
                        crit.Add(Restrictions.Like("DescripcionMantenimiento", a.DescripcionMantenimiento));
					if (!string.IsNullOrEmpty(a.Observaciones))
                        crit.Add(Restrictions.Like("Observaciones", a.Observaciones));					
					if (!string.IsNullOrEmpty(a.fchCaptura_ini) && !string.IsNullOrEmpty(a.fchCaptura_fin) )
                        crit.Add(Restrictions.Between("FechaCaptura", a.fchCaptura_ini, a.fchCaptura_fin));
					if (!string.IsNullOrEmpty(a.fchMantenimiento_ini) && !string.IsNullOrEmpty(a.fchMantenimiento_fin) )
                        crit.Add(Restrictions.Between("FechaMantenimiento", a.fchMantenimiento_ini, a.fchMantenimiento_fin));
                    if (a.IdEstatus != 0 && a.IdEstatus.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEstatus", a.IdEstatus));

                    lista = (List<Entidades.BitacoraMantenimiento>)crit.List<Entidades.BitacoraMantenimiento>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.BitacoraMantenimiento a)
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
		
		public static bool Actualizar(Entidades.BitacoraMantenimiento a)
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
		
		public static bool Eliminar(Entidades.BitacoraMantenimiento a)
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