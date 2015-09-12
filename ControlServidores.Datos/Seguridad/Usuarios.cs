using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ControlServidores.Datos.Seguridad
{
    public class Usuarios
    {
        /// <summary>
        /// Metodo que devuelve a todos o un usuario especificado.
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public static List<Entidades.Usuarios> obtenerUsuarios(Entidades.Usuarios us)
        {
            List<Entidades.Usuarios> lista = new List<Entidades.Usuarios>();
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    //Option
                    ICriteria crit = session.CreateCriteria(typeof(Entidades.Usuarios));
                    if (us.IdUsuario != 0 && us.IdUsuario.ToString() != "")
                        crit.Add(Expression.Eq("IdUsuario", us.IdUsuario));
                    if (us.IdPersona != 0 && us.IdPersona.ToString() != "")
                        crit.Add(Expression.Eq("IdPersona", us.IdPersona));
                    if (!string.IsNullOrEmpty(us.Usuario))
                        crit.Add(Expression.Eq("Usuario", us.Usuario));
                    if (!string.IsNullOrEmpty(us.Pwd))
                        crit.Add(Expression.Eq("Pwd", us.Pwd));
                    if (us.IdRol != 0 && us.IdRol.ToString() != "")
                        crit.Add(Expression.Eq("IdRol", us.IdRol));

                    lista = (List<Entidades.Usuarios>)crit.List();
                }
            }
            catch
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
        public bool nuevo(Entidades.Usuarios us)
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
        public bool actualizar(Entidades.Usuarios us)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(us);
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

        /// <summary>
        /// Metodo para boorar un usuario.
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool eliminar(Entidades.Usuarios us)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(us);
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
