using MySqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhiJuFactory.Core.Dao
{
    /// <summary>
    ///数据访问层
    /// </summary>
    public class DbService : IDisposable
    {
        private SqlSugarClient _db;
        public DbService()
        {
            _db = DbConfig.GetDbInstance();
        }

        /// <summary>
        /// 将错误信息写入日志
        /// </summary>
        /// <param name="ex"></param>
        private static void WriteExMessage(Exception ex)
        {
            //PubMethod.WirteExp(ex);
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}
