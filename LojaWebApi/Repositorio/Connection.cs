using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace LojaWebApi.Repositorio
{
    public class Connection
    {
        public static IEnumerable<T> Query<T>(string query)
        {
            IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            db.Open();
            try
            {
                var obj = db.Query<T>(query);
                return obj;
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                db.Close();
            }
        }

        public static dynamic Query(string query)
        {
            IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            db.Open();
            try
            {
                var obj = db.Query(query);
                return obj;
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                db.Close();
            }
        }

        public static bool Update<T>(T entity) where T : class
        {
            IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            db.Open();
            try
            {
                var obj = db.Update<T>(entity);
                if (obj)
                {
                    return true;
                }
                throw new Exception("Erro em atualizar dado");
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                db.Close();
            }
        }

        public static dynamic Insert<T>(T entity) where T : class
        {
            IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            db.Open();
            try
            {
                var obj = db.Insert<T>(entity);
                if (obj > 0)
                {
                    return obj;
                }
                throw new Exception("Erro em inserir dado");
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                db.Close();
            }
        }

        public static dynamic Insert<T>(List<T> entity) where T : class
        {
            IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            db.Open();
            using (var transaction = db.BeginTransaction())
            {
                try
                {
                    foreach (var item in entity)
                    {
                        db.Insert(item, transaction);
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception x)
                {
                    transaction.Rollback();
                    throw x;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public static dynamic Delete<T>(T entity) where T : class
        {
            IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            db.Open();
            try
            {
                var obj = db.Delete<T>(entity);
                if (obj)
                {
                    return true;
                }
                throw new Exception("Erro em deletar dado");
            }
            catch (MySqlException x)
            {
                throw x;
            }
            finally
            {
                db.Close();
            }
        }
    }
}