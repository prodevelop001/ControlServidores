using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Inventarios
{
	public class ConfRed 
	{
		public static List<Entidades.ConfRed> Obtener(Entidades.ConfRed a)
		{
			List<Entidades.ConfRed> lista = new List<Entidades.ConfRed>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.MenuXrol));
                    if (a.IdConfRed != 0 && a.IdConfRed.ToString() != "")
                        crit.Add(Expression.Eq("IdConfRed", a.IdConfRed));
                   if (a.IdServidor != 0 && a.IdServidor.ToString()  != "")
                        crit.Add(Expression.Eq("IdServidor", a.IdServidor));
					if (!string.IsNullOrEmpty(a.InterfazRed))
                        crit.Add(Expression.Like("InterfazRed", a.InterfazRed));
					if (!string.IsNullOrEmpty(a.DirMac))
                        crit.Add(Expression.Eq("DirMac", a.DirMac));
					if (!string.IsNullOrEmpty(a.DirIP))
                        crit.Add(Expression.Like("DirIP", a.DirIP));
					if (!string.IsNullOrEmpty(a.MascaraSubRed))
                        crit.Add(Expression.Like("MascaraSubRed", a.MascaraSubRed));
					if (!string.IsNullOrEmpty(a.Gateway))
                        crit.Add(Expression.Like("Gateway", a.Gateway));
					if (!string.IsNullOrEmpty(a.DNS))
                        crit.Add(Expression.Like("DNS", a.DNS));
					if (!string.IsNullOrEmpty(a.VLAN))
                        crit.Add(Expression.Like("VLAN", a.VLAN));
					
                    lista = (List<Entidades.ConfRed>)crit.List();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.ConfRed a)
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
		
		public static bool Actualizar(Entidades.ConfRed a)
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
		
		public static bool Eliminar(Entidades.ConfRed a)
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