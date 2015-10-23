using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace ControlServidores.Datos.Seguridad
{
    public class Usuarios
    {
        /// <summary>
        /// Metodo que devuelve a todos o un usuario especificado.
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public static List<Entidades.Usuarios> Obtener(Entidades.Usuarios us)
        {
            List<Entidades.Usuarios> lista = new List<Entidades.Usuarios>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Usuarios), "us");
                    if (us.IdUsuario != 0 && us.IdUsuario.ToString() != "")
                        crit.Add(Restrictions.Eq("IdUsuario", us.IdUsuario));

                    if(us.IdPersona!= null)
                    {
                        crit.CreateAlias("us.IdPersona", "IdPersona", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (us.IdPersona.IdPersona != 0 && us.IdPersona.IdPersona.ToString() != "")
                        {                            
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("IdPersona.IdPersona", us.IdPersona.IdPersona)));
                        }
                    }                    
                    if (!string.IsNullOrEmpty(us.Usuario))
                        crit.Add(Restrictions.Like("Usuario", us.Usuario));
                    if (!string.IsNullOrEmpty(us.Pwd))
                        crit.Add(Restrictions.Eq("Pwd", us.Pwd));
                    if(us.IdRol != null)
                    {
                        crit.CreateAlias("us.IdRol", "IdRol", NHibernate.SqlCommand.JoinType.InnerJoin);
                        if (us.IdRol.IdRol != 0 && us.IdRol.IdRol.ToString() != "")
                        {                            
                            crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("IdRol.IdRol", us.IdRol.IdRol)));
                        }
                    }                   

                    lista = (List<Entidades.Usuarios>)crit.List<Entidades.Usuarios>();
                }
            }
            //Ver Error
            catch(Exception err)
            {
                return lista;
            }

            return lista;
        }

        /// <summary>
        /// Metodo para nuevo usuario.
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public static bool nuevo(Entidades.Usuarios us)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Save(us);
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

        /// <summary>
        /// Metodo para actualizar usuario.
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public static bool actualizar(Entidades.Usuarios us)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Update(us);
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

        /// <summary>
        /// Metodo para boorar un usuario.
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public static bool eliminar(Entidades.Usuarios us)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.Delete(us);
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
