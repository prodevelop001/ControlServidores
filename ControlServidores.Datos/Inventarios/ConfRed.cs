using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

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
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.ConfRed),"r");

                    if(a.Estatus != null)
                    { 
                        crit.CreateAlias("r.Estatus", "idEstatus", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Estatus.IdEstatus != 0 && a.Estatus.IdEstatus.ToString() != "")
                            crit.Add(Restrictions.Eq("IdEstatus", a.Estatus.IdEstatus));
                    }
                    if (a.Servidor != null)
                    { 
                        crit.CreateAlias("r.Servidor", "idServidor", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Servidor.IdServidor != 0 && a.Servidor.IdServidor.ToString() != "")
                            crit.Add(Restrictions.Eq("idServidor.IdServidor", a.Servidor.IdServidor));
                    }
                    if (a.IdConfRed != 0 && a.IdConfRed.ToString() != "")
                        crit.Add(Restrictions.Eq("IdConfRed", a.IdConfRed));                   
					if (!string.IsNullOrEmpty(a.InterfazRed))
                        crit.Add(Restrictions.Like("InterfazRed", a.InterfazRed));
					if (!string.IsNullOrEmpty(a.DirMac))
                        crit.Add(Restrictions.Eq("DirMac", a.DirMac));
                    if (!string.IsNullOrEmpty(a.DirIP))
                    {
                        crit.Add(Restrictions.Like("DirIP", a.DirIP));
                    }                        
					if (!string.IsNullOrEmpty(a.MascaraSubRed))
                        crit.Add(Restrictions.Like("MascaraSubRed", a.MascaraSubRed));
					if (!string.IsNullOrEmpty(a.Gateway))
                        crit.Add(Restrictions.Like("Gateway", a.Gateway));
					if (!string.IsNullOrEmpty(a.DNS))
                        crit.Add(Restrictions.Like("DNS", a.DNS));
					if (!string.IsNullOrEmpty(a.VLAN))
                        crit.Add(Restrictions.Like("VLAN", a.VLAN));
                    

                    lista = (List<Entidades.ConfRed>)crit.List<Entidades.ConfRed>();
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
            catch(Exception err)
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
            catch(Exception err)
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

        public static bool Eliminar(List<Entidades.ConfRed> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.ConfRed b)
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