using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Data.Common;
using System.Configuration;
using System.Web.Routing;
using System.Web.Security;
using TY.Core;
using TY.Common;
using Abp.Web.Mvc.Controllers;
using Abp.UI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Caching;

namespace TY.Web.Framework
{
    /// <summary>
    /// 前台基础控制器类
    /// </summary>
    public class BaseWebController : AbpController
    {
        public WebWorkContext WorkContext = new WebWorkContext();
        public Cache cache = HttpRuntime.Cache;
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
        protected BaseWebController()
        {
            LocalizationSourceName = ZjgcConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors()
        {
            
        }


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            HttpCookie authCookie = requestContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
      

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                string[] UserInfo = authTicket.UserData.Split('|');
      
                WorkContext.M_Id = UserInfo.Length > 3 ? int.Parse(UserInfo[0]) : 0;
                WorkContext.M_UpdateTime = UserInfo.Length > 3 ? UserInfo[2] : "";
                WorkContext.M_Mobile = UserInfo.Length > 3 ? UserInfo[1] : "";
                WorkContext.M_Email = UserInfo.Length > 3 ? UserInfo[3] : "";
            }

            WorkContext.ImgHost = ConfigurationManager.AppSettings["ImgHost"];
            WorkContext.Config.DefCity = "浙江|杭州";
            WorkContext.IP = WebHelper.GetIP();
            WorkContext.Url = WebHelper.GetUrl();
            WorkContext.UrlReferrer = WebHelper.GetUrlReferrer();



        }



        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        protected string GetRouteString(string key, string defaultValue)
        {
            object value = RouteData.Values[key];
            if (value != null)
                return value.ToString();
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected string GetRouteString(string key)
        {
            return GetRouteString(key, "");
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        protected int GetRouteInt(string key, int defaultValue)
        {
            return TypeHelper.ObjectToInt(RouteData.Values[key], defaultValue);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected int GetRouteInt(string key)
        {
            return GetRouteInt(key, 0);
        }

        /// <summary>
        /// 提示信息视图
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string message)
        {
            return View("prompt", new PromptModel(message));
        }

        /// <summary>
        /// 提示信息视图
        /// </summary>
        /// <param name="backUrl">返回地址</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string backUrl, string message)
        {
            return View("prompt", new PromptModel(backUrl, message));
        }

        /// <summary>
        /// ajax请求结果
        /// </summary>
        /// <param name="code">状态</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        protected async Task<ActionResult>  AjaxResult(string code, string message, string url = null)
        {
            MessageResult result = new MessageResult()
            {
                code = code,
                message = message,
                url = url
            };
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return Content(await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, jsetting)));
        }

        /// <summary>
        /// Validform实时验证结果
        /// </summary>
        /// <param name="code">状态</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        protected async Task<ActionResult> ValidformAjaxResult(string code, string message)
        {
            ValidformResult result = new ValidformResult()
            {
                 info=message,
                 status=code
            };
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return Content(await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, jsetting)));
        }
        /// <summary>
        /// ajax请求结果
        /// </summary>
        /// <param name="code">状态</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        protected async Task<ActionResult> AjaxResult(string code, AjaxObjResult [] message, string url = null)
        {
            MessageResults result = new MessageResults()
            {
                code = code,
                message = message,
                url = url
            };
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return Content(await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, jsetting)));
        }
        protected async Task<string> AjaxObjResult(string objName, string msg)
        {

            AjaxObjResult[] result = new AjaxObjResult[] { new AjaxObjResult { objName = objName, msg = msg } };

            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result));

        }
        /// <summary>
        /// 分页索引:默认1
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { this.pageIndex = value; }
        }
        /// <summary>
        /// 每页多少条：默认20
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { this.pageSize = value; }
        }
        public int pageIndex = 1;
        public int pageSize = 20;//20
        ///// <summary>
        ///// ajax请求结果
        ///// </summary>
        ///// <param name="state">状态</param>
        ///// <param name="content">内容</param>
        ///// <returns></returns>
        //protected ActionResult AjaxResult(string state, string content, string url = "")
        //{
        //    return Json(new MessageResult() { code = state, message = content, url = url });
        //    //return Content("{\"code\":\"" + state + "\",\"message\":\"" + content + "\",\"url\":\"" + url + "\"}");
        //}

        ///// <summary>
        ///// ajax请求结果
        ///// </summary>
        ///// <param name="state">状态</param>
        ///// <param name="content">内容</param>
        ///// <param name="isObject">是否为对象</param>
        ///// <returns></returns>
        //protected ActionResult AjaxResult(string state, string content)  //bool isObject
        //{
        //    return Json(new MessageResult() { code = state, message = content });
        //    //return Content(string.Format("{0}\"code\":\"{1}\",\"message\":{2}{3}{4}{5}", "{", state, isObject ? "" : "\"", content, isObject ? "" : "\"", "}"));
        //}
    }
}
