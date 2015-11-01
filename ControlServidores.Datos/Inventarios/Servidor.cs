using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Inventarios
{
    public class Servidor
    {
        public static List<Entidades.Servidor> Obtener(Entidades.Servidor a)
        {
            List<Entidades.Servidor> lista = new List<Entidades.Servidor>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Servidor), "s");

                    if (a.Modelo != null)
                    {
                        crit.CreateAlias("s.Modelo", "idModelo", NHibernate.SqlCommand.JoinType.InnerJoin);                        
                        if (a.Modelo.IdModelo != 0 && a.Modelo.IdModelo.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idModelo.IdModelo", a.Modelo.IdModelo)));
                    }
                    if(a.Especificacion != null)
                    {
                        crit.CreateAlias("s.Especificacion", "idEspecificacion", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Especificacion.IdEspecificacion != 0 && a.Especificacion.IdEspecificacion.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idEspecificacion.IdEspecificacion", a.Especificacion.IdEspecificacion)));
                    }
                    if(a.TipoServidor != null)
                    {
                        crit.CreateAlias("s.TipoServidor", "idTipoServidor", NHibernate.SqlCommand.JoinType.LeftOuterJoin);
                        if (a.TipoServidor.IdTipoServidor != 0 && a.TipoServidor.IdTipoServidor.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idTipoServidor.IdTipoServidor", a.TipoServidor.IdTipoServidor)));
                    }

                    if (a.IdServidor != 0 && a.IdServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdServidor", a.IdServidor));
                    if (!string.IsNullOrEmpty(a.AliasServidor))
                        crit.Add(Restrictions.Like("AliasServidor", a.AliasServidor));         
                    if (a.IdVirtualizador != -1 && a.IdVirtualizador.ToString() != "")
                        crit.Add(Restrictions.Eq("IdVirtualizador", a.IdVirtualizador));
                    if (!string.IsNullOrEmpty(a.DescripcionUso))
                        crit.Add(Restrictions.Like("DescripcionUso", a.DescripcionUso));
                    if (a.IdEstatus != 0 && a.IdEstatus.ToString() != "")
                        crit.Add(Restrictions.Eq("IdEstatus", a.IdEstatus));

                    lista = (List<Entidades.Servidor>)crit.List<Entidades.Servidor>();
                }
            }
            catch
            {
                return lista;
            }

            return lista;
        }

        public static bool Nuevo(Entidades.Servidor a)
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
            catch (Exception err)
            {
                return false;
            }

            return true;
        }

        public static bool Actualizar(Entidades.Servidor a)
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

        public static bool Eliminar(Entidades.Servidor a)
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

        public static bool Eliminar(List<Entidades.Servidor> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.Servidor b)
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