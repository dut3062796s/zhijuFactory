using System;
using System.Collections;

namespace TY.Common
{
    public class Basis
    {

        #region  订单状态
        public static Hashtable OrderState()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0", "未付款/");
            ht.Add("1", "审核中/am-badge-primary");
            ht.Add("2", "装修准备中/am-badge-secondary");
            ht.Add("3", "装修中/am-badge-success");
            ht.Add("4", "装修完毕/am-badge-warning");
            return ht;
        }

        public static string GetOrderState(string t)
        {
            string key;
            Hashtable ht = OrderState();
            if (ht.ContainsKey(t))
            {
                string[] KeySplit = ht[t].ToString().Split(new char[] { '/' });
                key = KeySplit[0];
            }
            else
            {
                key = t;
            }
            return key;
        }

        public static Hashtable ActivityType()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0", "海尔活动");
            ht.Add("1", "团购惠");
            return ht;
        }

        public static string GetActivityType(string t)
        {
            string key;
            Hashtable ht = ActivityType();
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

        /// <summary>
        /// 用户类型
        /// </summary>
        /// <returns></returns>
        public static Hashtable DiyType()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0", "设计师");
            ht.Add("1", "普通用户");
            return ht;
        }

        public static string GetDiyType(string t)
        {
            string key;
            Hashtable ht = DiyType();
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


        /// <summary>
        /// 云设计流程
        /// </summary>
        /// <returns></returns>
        public static Hashtable DecoratingType()
        {
            Hashtable ht = new Hashtable();
            ht.Add("true", "装修阶段/primary");
            ht.Add("false", "户型阶段/default");
            return ht;
        }

        public static string GetDecoratingType(string t)
        {
            string key;
            Hashtable ht = DecoratingType();
            if (ht.ContainsKey(t))
            {
                string[] KeySplit = ht[t].ToString().Split(new char[] { '/' });
                key = KeySplit[0];
            }
            else
            {
                key = t;
            }
            return key;
        }
        public static string GetDecoratingTypeHtml(string t)
        {
            string key;
            Hashtable ht = DecoratingType();
            if (ht.ContainsKey(t))
            {
                string[] KeySplit = ht[t].ToString().Split(new char[] { '/' });
                key = "<label class=\"label label-" + KeySplit[1] + "\">" + KeySplit[0] + "</label>";
            }
            else
            {
                key = t;
            }
            return key;
        }

        public static string GetOrderStateHtml(string t)
        {
            string key;
            Hashtable ht = OrderState();
            if (ht.ContainsKey(t))
            {
                string[] KeySplit = ht[t].ToString().Split(new char[] { '/' });
                key = "<font class=\"am-badge " + KeySplit[1] + "\">" + KeySplit[0] + "</font>";
            }
            else
            {
                key = t;
            }
            return key;
        }

        /// <summary>
        /// 账务类型
        /// </summary>
        /// <returns></returns>
        public static Hashtable PayOperate()
        {
            Hashtable ht = new Hashtable();
            ht.Add("1", "消费");
            ht.Add("2", "消费");
            ht.Add("3", "充值");
            return ht;
        }

        public static string GetPayOperate(string t)
        {
            string key;
            Hashtable ht = PayOperate();
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

        /// <summary>
        /// 支付状态
        /// </summary>
        /// <returns></returns>
        public static Hashtable PayState()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0","已付款");
            ht.Add("1", "待付款");
            ht.Add("2", "已取消");
            return ht;
        }

        public static string GetPayState(string t)
        {
            string key;
            Hashtable ht = PayState();
            if (ht.ContainsKey(t))
            {
                key=ht[t].ToString();
            }
            else {
                key = t;
            }
            return key;
        }

        /// <summary>
        /// 支付类型
        /// </summary>
        /// <returns></returns>
        public static Hashtable PayType()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0","余额");
            ht.Add("1", "支付宝");
            ht.Add("2", "微信");
            return ht;
        }

        public static string GetPayType(string t) {
            string key;
            Hashtable ht = PayType();
            if (ht.ContainsKey(t))
            {
                key=ht[t].ToString();
            }
            else {
                key = t;
            }
            return key;
        }

        public static decimal GetKBFee(long kb)
        {
            decimal fee = 0;
            if (kb <= 100)
            {
                fee = kb / 10 * 1;
            }
            else if (kb > 100 && kb <= 1000)
            {
                fee = Convert.ToDecimal(kb / 10 * 0.9);
            }
            else if (kb > 10000 && kb <= 20000)
            {
                fee = Convert.ToDecimal(kb / 10 * 0.8);
            }
            else if (kb > 20000)
            {
                fee = Convert.ToDecimal(kb / 10 * 0.7);
            }
            return fee;

        }
        #endregion

    }
}
