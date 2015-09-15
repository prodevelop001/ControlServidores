using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Seguridad
{
	public class Personas 
	{
		public static List<Entidades.Personas> Obtener(Entidades.Personas a)
		{
			List<Entidades.Personas> lista = new List<Entidades.Personas>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Personas));
                    if (a.IdPersona != 0 && a.IdPersona.ToString() != "")
                        crit.Add(Expression.Eq("IdPersona", a.IdPersona));
                   if (!string.IsNullOrEmpty(a.Nombre))
                        crit.Add(Expression.Like("Nombre", a.Nombre));
					if (!string.IsNullOrEmpty(a.Puesto))
                        crit.Add(Expression.Eq("Puesto", a.Puesto));
					if (!string.IsNullOrEmpty(a.Extension))
                        crit.Add(Expression.Eq("Extension", a.Extension));
					if (!string.IsNullOrEmpty(a.Correo))
                        crit.Add(Expression.Like("Correo", a.Correo));
					
                    lista = (List<Entidades.Personas>)crit.List<Entidades.Personas>();
                }
            }
            catch(Exception err)
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Personas a)
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
		
		public static bool Actualizar(Entidades.Personas a)
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
		
		public static bool Eliminar(Entidades.Personas a)
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
            catch(Exception err)
            {
                return false;
            }

            return true;
		}
	}
}