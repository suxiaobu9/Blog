using System;
using System.Collections.Generic;
using System.Text;

namespace DbLogic
{
    public interface IDataAccess
    {
        /// <summary>
        /// 取得一筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public T QueryFrist<T>(string sql, IDictionary<string, object> parameter);

        /// <summary>
        /// 取得多筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, IDictionary<string, object> parameter);

        /// <summary>
        /// 執行Sql語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Excute(string sql, IDictionary<string, object> parameter);

        /// <summary>
        /// 取得DB時間
        /// </summary>
        /// <returns></returns>
        public DateTime GetDbTime();
    }
}
