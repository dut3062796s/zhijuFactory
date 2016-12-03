using Abp.Web.Mvc.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TY.Core;

namespace TY.Web.Framework
{
  
    /// <summary>
    /// 前台视图页面基类型
    /// </summary>
    public abstract class WebViewPageBase : WebViewPageBase<dynamic>
    {
       
    }

    /// <summary>
    /// 前台视图页面基类型
    /// </summary>
    public abstract class WebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WebViewPageBase()
        {
            LocalizationSourceName = ZjgcConsts.LocalizationSourceName;
        }

        public WebWorkContext WorkContext;

        /// <summary>
        /// 从配置文件中获取上传文件路径
        /// </summary>
        public static readonly String Folder = ConfigurationManager.AppSettings["upload"].Split(',')[0];
        public static readonly String DomainNmae = ConfigurationManager.AppSettings["upload"].Split(',')[1];
        /// <summary>
        /// 头像上传路径
        /// </summary>
        public static readonly String AvatarFolder = ConfigurationManager.AppSettings["AvatarUpload"].Split(',')[0];
        public static readonly String AvatarDomainNmae = ConfigurationManager.AppSettings["AvatarUpload"].Split(',')[1];

        public sealed override void InitHelpers()
        {
            base.InitHelpers();
            WorkContext = ((BaseWebController)(this.ViewContext.Controller)).WorkContext;
        }

        //public sealed override void Write(object value)
        //{
        //    //Output.Write(value);
        //}
    }

}
