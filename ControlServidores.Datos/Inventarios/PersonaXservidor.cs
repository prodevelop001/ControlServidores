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
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.PersonaXservidor), "pes");

                    if (a.Personas != null)
                    {
                        crit.CreateAlias("pes.Personas", "idPersona", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.IdPersona != 0 && a.IdPersona.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idPersona.IdPersona", a.Personas.IdPersona)));
                    }
                    if (a.Servidor != null)
                    {
                        crit.CreateAlias("pes.Servidor", "idServidor", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.Servidor.IdServidor != 0 && a.Servidor.IdServidor.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idServidor.IdServidor", a.Servidor.IdServidor)));
                    }
                    if (a.Bitacora != null)
                    {
                        crit.CreateAlias("pes.Bitacora", "idBitacora", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (a.IdBitacora != 0 && a.IdBitacora.ToString() != "")
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("idBitacora.IdBitacora", a.Bitacora.IdBitacora)));
                    }

                    if (a.IdPersonaServidor != 0 && a.IdPersonaServidor.ToString() != "")
                        crit.Add(Restrictions.Eq("IdPersonaServidor", a.IdPersonaServidor));

                    lista = (List<Entidades.PersonaXservidor>)crit.List<Entidades.PersonaXservidor>();
                }
            }
            catch (Exception err)
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

        public static bool Eliminar(List<Entidades.PersonaXservidor> a)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    a.ForEach(delegate (Entidades.PersonaXservidor b)
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