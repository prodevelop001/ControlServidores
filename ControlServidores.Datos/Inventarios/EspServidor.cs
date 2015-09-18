using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Inventarios
{
	public class EspServidor 
	{
		public static List<Entidades.EspServidor> Obtener(Entidades.EspServidor a)
		{
			List<Entidades.EspServidor> lista = new List<Entidades.EspServidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.EspServidor));
                    if (a.IdEspecificacion != 0 && a.IdEspecificacion.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEspecificacion", a.IdEspecificacion));
					if (a.IdProcesador != 0 && a.IdProcesador.ToString() != "")
                        crit.Add(Restrictions.Eq("IdProcesador", a.IdProcesador));
                   if (a.NumProcesadores != 0 && a.NumProcesadores.ToString() != "")
                        crit.Add(Restrictions.Eq("NumProcesadores", a.NumProcesadores));
					if (!string.IsNullOrEmpty(a.CapacidadRAM))
                        crit.Add(Restrictions.Like("CapacidadRam", a.CapacidadRAM));
					if (a.IdTipoArreglo != 0 && a.IdTipoArreglo.ToString() != "") 
                        crit.Add(Restrictions.Eq("IdTipoArreglo", a.IdTipoArreglo));
					if (!string.IsNullOrEmpty(a.NumSerie))
                        crit.Add(Restrictions.Like("NumSerie", a.NumSerie));
					
                    lista = (List<Entidades.EspServidor>)crit.List<Entidades.EspServidor>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.EspServidor a)
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
		
		public static bool Actualizar(Entidades.EspServidor a)
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
		
		public static bool Eliminar(Entidades.EspServidor a)
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

        public static bool Eliminar(List<Entidades.EspServidor> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.EspServidor b)
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