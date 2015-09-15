using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Inventarios
{
	public class PersonaXservidor 
	{
		public static List<Entidades.PersonaXservidor> Obtener(Entidades.PersonaXservidor a)
		{
			List<Entidades.PersonaXservidor> lista = new List<Entidades.PersonaXservidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.PersonaXservidor));
                    if (a.IdPersonaServidor != 0 && a.IdPersonaServidor.ToString() != "")
                        crit.Add(Expression.Eq("IdPersonaServidor", a.IdPersonaServidor));
					if (a.IdPersona != 0 && a.IdPersona.ToString() != "")
                        crit.Add(Expression.Eq("IdPersona", a.IdPersona));
					if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Expression.Eq("IdServidor", a.IdServidor));
					if (a.IdBitacora != 0 && a.IdBitacora.ToString() != "")
                        crit.Add(Expression.Eq("IdBitacora", a.IdBitacora));
                   
                    lista = (List<Entidades.PersonaXservidor>)crit.List<Entidades.PersonaXservidor>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.PersonaXservidor a)
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
		
		public static bool Actualizar(Entidades.PersonaXservidor a)
		{
			try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Update(a);
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
		
		public static bool Eliminar(Entidades.PersonaXservidor a)
		{
			try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {                   
                    session.Delete(a);
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
		
	}
}