﻿using MySqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace ZhiJuFactory.Core.Dao
{
    public class DbConfig
    {
        public static string ConnectionString =  GetConnectionString("DefaultConnection");
        public static Dictionary<string, Func<KeyValueObj>> DefaultFilter = new Dictionary<string, Func<KeyValueObj>>() {
            //单表查询
            { "FalseDelte",()=>{return new KeyValueObj(){ Key=" (isdeleted=0  or isdeleted is null )"};} },
            //多表查询
            { "FalseDelteJoin",()=>{return new KeyValueObj(){ Key=" (m.isdeleted=0  or m.isdeleted is null )"};} } };
        public static SqlSugarClient GetDbInstance()
        {
            try
            {
                var reval = new SqlSugarClient(ConnectionString);
                reval.SetFilterItems(DefaultFilter);//给查询添加默认过滤器 （所有查询加上 isdeleted=0 or null）
                reval.AddDisableUpdateColumns("CreateTime", "Creator");//添加禁止更新列
                reval.CurrentFilterKey = "FalseDelte";
                reval.IsEnableLogEvent = true;
                reval.LogEventStarting = (sql, pars) =>
                {//在这儿打段点可以查看生成的SQL语句
                    Trace.WriteLine(sql);
                };
                return reval;
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库出错，请检查您的连接字符串，和网络。 ex:"+ex.Message);
            }
        }
    }
}
