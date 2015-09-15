using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Catalogos
{
	public class TipoArregloDisco 
	{
		public static List<Entidades.TipoArregloDisco> Obtener(Entidades.TipoArregloDisco a)
		{
			List<Entidades.TipoArregloDisco> lista = new List<Entidades.TipoArregloDisco>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.TipoArregloDisco));
                    if (a.IdTipoArreglo != 0 && a.IdTipoArreglo.ToString() != "")
                        crit.Add(Restrictions.Eq("IdTipoArreglo", a.IdTipoArreglo));
                   if (!string.IsNullOrEmpty(a.Tipo))
                        crit.Add(Restrictions.Like("Tipo", a.Tipo));
					if (!string.IsNullOrEmpty(a.Descripcion))
                        crit.Add(Restrictions.Like("Descripcion", a.Descripcion));
					
                    lista = (List<Entidades.TipoArregloDisco>)crit.List<Entidades.TipoArregloDisco>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.TipoArregloDisco a)
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
		
		public static bool Actualizar(Entidades.TipoArregloDisco a)
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
		
		public static bool Eliminar(Entidades.TipoArregloDisco a)
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