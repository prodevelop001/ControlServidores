using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Catalogos
{
	public class ConceptoEstatus 
	{
		public static List<Entidades.ConceptoEstatus> Obtener(Entidades.ConceptoEstatus a)
		{
			List<Entidades.ConceptoEstatus> lista = new List<Entidades.ConceptoEstatus>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.ConceptoEstatus));
                    if (a.IdConceptoEstatus != 0 && a.IdConceptoEstatus.ToString() != "")
                        crit.Add(Restrictions.Eq("IdConceptoEstatus", a.IdConceptoEstatus));
                   if (!string.IsNullOrEmpty(a.Concepto))
                        crit.Add(Restrictions.Like("Concepto", a.Concepto));

                    crit.AddOrder(Order.Asc("Concepto"));

                    lista = (List<Entidades.ConceptoEstatus>)crit.List<Entidades.ConceptoEstatus>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
		}
		
		public static bool Nuevo(Entidades.ConceptoEstatus a)
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
		
		public static bool Actualizar(Entidades.ConceptoEstatus a)
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
		
		public static bool Eliminar(Entidades.ConceptoEstatus a)
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