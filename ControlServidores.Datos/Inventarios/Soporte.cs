using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Inventarios
{
	public class Soporte 
	{
		public static List<Entidades.Soporte> Obtener(Entidades.Soporte a)
		{
			List<Entidades.Soporte> lista = new List<Entidades.Soporte>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Soporte),"s");
                    if (a.IdSoporte != 0 && a.IdSoporte.ToString() != "")
                        crit.Add(Restrictions.Eq("IdSoporte", a.IdSoporte));
                    if(a.Empresa != null)
                    {
                        crit.CreateAlias("s.Empresa", "idEmpresa", NHibernate.SqlCommand.JoinType.LeftOuterJoin);
                        if (a.Empresa.IdEmpresa != 0 && a.Empresa.IdEmpresa.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idEmpresa.IdEmpresa", a.Empresa.IdEmpresa)));
                    }
                    if (a.Modelo != null)
                    {
                        crit.CreateAlias("s.Modelo", "idModelo", NHibernate.SqlCommand.JoinType.LeftOuterJoin);
                        if (a.Modelo.IdModelo != 0 && a.Modelo.IdModelo.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idModelo.IdModelo", a.Modelo.IdModelo)));
                    }

                    lista = (List<Entidades.Soporte>)crit.List<Entidades.Soporte>();
                }
            }
            catch(Exception err)
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.Soporte a)
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
		
		public static bool Actualizar(Entidades.Soporte a)
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
		
		public static bool Eliminar(Entidades.Soporte a)
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

        public static bool Eliminar(List<Entidades.Soporte> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.Soporte b)
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