using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class Modelo 
	{
		public static List<Entidades.Modelo> Obtener(Entidades.Modelo a)
		{
			List<Entidades.Modelo> lista = new List<Entidades.Modelo>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Modelo),"M");
                    if (a.IdModelo != 0 && a.IdModelo.ToString() != "")
                        crit.Add(Restrictions.Eq("IdModelo", a.IdModelo));
				    if (a.IdMarca != -1 && a.IdMarca.ToString() != "")
						crit.Add(Restrictions.Eq("IdMarca", a.IdMarca));
					if (!string.IsNullOrEmpty(a.NombreModelo))
                        crit.Add(Restrictions.Like("NombreModelo", a.NombreModelo));

                    crit.AddOrder(Order.Asc("M.NombreModelo"));

                    lista = (List<Entidades.Modelo>)crit.List<Entidades.Modelo>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Modelo a)
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
		
		public static bool Actualizar(Entidades.Modelo a)
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
		
		public static bool Eliminar(Entidades.Modelo a)
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