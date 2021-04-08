using Dapper;
using Microsoft.Extensions.Options;
using Model.Appsettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DbLogic
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IOptions<ConnectionConfig> connectionConfig)
        {
            _connectionConfig = connectionConfig.Value;
        }

        private readonly ConnectionConfig _connectionConfig;


        /// <summary>
        /// 取得一筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public T QueryFrist<T>(string sql, IDictionary<string, object> parameter)
        {
            using var _defaultConn = new SqlConnection(_connectionConfig.Default);
            return _defaultConn.Query<T>(sql, parameter).FirstOrDefault();
        }

        /// <summary>
        /// 取得多筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, IDictionary<string, object> parameter)
        {
            using var _defaultConn = new SqlConnection(_connectionConfig.Default);
            return _defaultConn.Query<T>(sql, parameter);
        }

        /// <summary>
        /// 執行Sql語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Excute(string sql, IDictionary<string, object> parameter)
        {
            var dbTime = GetDbTime();
            parameter.Add("DbTime", dbTime);

            using var _defaultConn = new SqlConnection(_connectionConfig.Default);
            _defaultConn.Open();
            using var trans = _defaultConn.BeginTransaction();
            var result = _defaultConn.Execute(sql, parameter, transaction: trans);

            try
            {
                trans.Commit();
                return result;
            }
            catch
            {
                trans.Rollback();
                throw;
            }

        }

        /// <summary>
        /// 取得DB時間
        /// </summary>
        /// <returns></returns>
        public DateTime GetDbTime()
        {
            return this.Query<DateTime>("SELECT GETDATE()", null).First();
        }
    }
}
