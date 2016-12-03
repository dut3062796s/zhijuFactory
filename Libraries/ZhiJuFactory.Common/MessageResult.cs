using System.Collections.Generic;

namespace TY.Common
{
    /// <summary>
    /// Json消息结果类
    /// </summary>
    public class MessageResult
    {
        public MessageResult()
        {

        }
        /// <summary>
        /// 消息代码1;错误消息，0是成功，2
        /// </summary>
        public string code { get; set; }
        ///// <summary>
        ///// 带对象数组的消息
        ///// </summary>
        //public AjaxObjResult[] message1 { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 消息状态 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// URL链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object data { get; set; }
    }
    /// <summary>
    /// AJAX对象结果类
    /// </summary>
    public class AjaxObjResult {
        public AjaxObjResult()
        {

        }
        /// <summary>
        /// 对象名称
        /// </summary>
        public string objName { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

    }


    /// <summary>
    /// Json消息结果类
    /// </summary>
    public class MessageResults
    {
        public MessageResults()
        {

        }
        /// <summary>
        /// 消息代码1;错误消息，0是成功，2
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 带对象数组的消息
        /// </summary>
        public AjaxObjResult[] message { get; set; }

        ///// <summary>
        ///// 消息
        ///// </summary>
        //public string message { get; set; }
        /// <summary>
        /// 消息状态 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// URL链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// Json分页结果类
    /// </summary>
    public class PageResults<T> where T : class
    {
        public PageResults()
        {

        }
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 分页总条数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public List<T> Data { get; set; }
        
    }

    /// <summary>
    /// Validform验证结果
    /// </summary>
    public class ValidformResult
    {
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 状态：y成功，n失败.
        /// </summary>
        public string status { get; set; }
    }


}
