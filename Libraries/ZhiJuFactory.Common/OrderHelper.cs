using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TY.Common
{
    public class OrderHelper
    {
        #region 生成单据号
        /// <summary>
        /// 生成单据号
        /// </summary>
        /// <param name="pFromType"></param>
        /// <returns></returns>
        public static string GetFormCode(string formcode)
        {

            formcode += DateTime.Now.Year.ToString();
            formcode += DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            formcode += DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            formcode += DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
            formcode += DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
            formcode += DateTime.Now.Second.ToString().Length == 1 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
            if (DateTime.Now.Millisecond.ToString().Length == 1)
            {
                formcode += "00" + DateTime.Now.Millisecond.ToString();
            }
            else if (DateTime.Now.Millisecond.ToString().Length == 2)
            {
                formcode += "0" + DateTime.Now.Millisecond.ToString();
            }
            else
            {
                formcode += DateTime.Now.Millisecond.ToString();
            }
            return formcode;
        }
        #endregion

        #region 装修状态转换
        public static Hashtable OrderStatus()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0", "等待支付");
            ht.Add("1", "支付完成");
            ht.Add("2", "装修准备中");
            ht.Add("3", "装修中");
            ht.Add("4", "装修完毕");
            ht.Add("-1", "订单取消");
            return ht;
        }

        public static string GetOrderStatus(string t)
        {
            string key = "";
            Hashtable ht = OrderStatus();
            if (ht.ContainsKey(t))
            {
                key = ht[t].ToString();
            }
            else
            {
                key = t;
            }
            return key;
        }
        #endregion

        #region 装修情况
        public static Hashtable DecorationStatus()
        {
            Hashtable ht = new Hashtable();
            ht.Add("毛胚", "0");
            ht.Add("已装", "1");
            return ht;
        }

        public static string GetDecorationStatus(string t)
        {
            string key = "";
            foreach (DictionaryEntry de in DecorationStatus())
            {
                if (de.Value.ToString() == t)
                {
                    key = de.Key.ToString();
                }
            }
            return key;
        }
        #endregion

        #region 预约状态
        /// <summary>

        /// </summary>
        /// <returns></returns>
        public static Hashtable SubscribeStatus()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0", "未量房/default");
            ht.Add("1", "量房中/default");
            ht.Add("3", "完成/success");
            ht.Add("2", "预约失败/danger");
            return ht;
        }

        public static string GetSubscribeStatus(string t, bool html, bool isweb)
        {
            string key = "";
            Hashtable ht = SubscribeStatus();
            if (ht.ContainsKey(t))
            {
                string[] KeySplit = ht[t].ToString().Split(new char[] { '/' });
                if (html)
                {
                    if (isweb)
                    {
                        key = "<span class=\"am-badge am-badge-" + KeySplit[1] + "\">" + KeySplit[0] + "</span>";
                    }
                    else
                    {
                        key = "<span class=\"label label-" + KeySplit[1] + "\">" + KeySplit[0] + "</span>";
                    }
                }
                else
                {
                    key = KeySplit[0].ToString();
                }

            }
            else
            {
                key = t;
            }
            return key;
        }
        #endregion

    }
}
