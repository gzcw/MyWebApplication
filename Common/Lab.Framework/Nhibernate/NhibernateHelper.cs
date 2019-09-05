using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    /// <summary>
    /// Nhibernate辅助类
    /// </summary>
    public class NH
    {
        private static Dictionary<string, ISessionFactory> sessionFactoryDic = new Dictionary<string, ISessionFactory>();

        private static object _objLock = new object();

        /// <summary>
        /// 默认ISession
        /// </summary>
        public static ISession Session
        {
            get
            {
                return GetSession();
            }
        }
        private NH()
        {
        }

        /// <summary>
        /// 根据实体类所在的数据库获取ISession。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ISession GetSession<T>() where T : BaseEntity, new()
        {
            return GetSession();
        }

        /// <summary>
        /// 根据数据库名称创建ISessionFactory
        /// </summary>
        /// <returns></returns>
        public static ISessionFactory GetSessionFactory(string connectionName)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ToString();
            var providerName = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ProviderName;


            if (!sessionFactoryDic.ContainsKey(connectionName))
            {
                lock (_objLock)
                {
                    try
                    {
                        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetTypes().Where(y => y.BaseType == typeof(BaseEntity)).Count() > 0);

                        var configure = FluentNHibernate.Cfg.Fluently.Configure();
                        if (providerName.IndexOf("Oracle") >= 0)
                        {
                            var config = configure.Database(
                                FluentNHibernate.Cfg.Db.OracleManagedDataClientConfiguration.Oracle10.ConnectionString(connStr)
                             );
                            foreach (var assembly in assemblies)
                            {
                                config.Mappings(m => m.FluentMappings.AddFromAssembly(assembly));
                            }
                            var sessionFactory = config.BuildSessionFactory();
                            sessionFactoryDic.Add(connectionName, sessionFactory);
                        }
                        else
                        {
                            var config = configure.Database(
                                  FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012.ConnectionString(connStr)
                               );
                            foreach (var assembly in assemblies)
                            {
                                config.Mappings(m => m.FluentMappings.AddFromAssembly(assembly));
                            }
                            var sessionFactory = config.BuildSessionFactory();
                            sessionFactoryDic.Add(connectionName, sessionFactory);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DomainException(ex.Message + ex.InnerException.Message);
                    }
                }
            }
            return sessionFactoryDic[connectionName];
        }

        /// <summary>
        /// 根据数据库名称获取ISession
        /// </summary>
        /// <returns></returns>
        public static ISession GetSession(string connectionName = "DefaultConnection")
        {
            var context = HttpContext.Current;
            lock (_objLock)
            {
                if (context.Items[connectionName + "_Session"] == null)
                {
                    GetSessionFactory(connectionName);
                    context.Items[connectionName + "_Session"] = sessionFactoryDic[connectionName].OpenSession();
                }
            }
            return context.Items[connectionName + "_Session"] as ISession;
        }
    }
}