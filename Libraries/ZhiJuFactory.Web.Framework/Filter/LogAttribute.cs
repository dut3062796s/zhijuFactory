using Abp.Dependency;
using Abp.Domain.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TY.Appliaction.AdminCpApp;
using TY.Appliaction.LogOperationApp;
using TY.Core.Entities;
using TY.EntityFramework.EntityFramework.Repositories;

namespace TY.Web.Framework.Filter
{
    /// <summary>
    /// 日志过滤器
    /// </summary>
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //new InsertLog(_ILogOperationAppService)._DoInsertLog(filterContext);
            _DoInsertLog(filterContext);
        }

        public void _DoInsertLog(ActionExecutedContext filterContext)
        {
            var _ILogOperationAppService = IocManager.Instance.Resolve<LogOperationAppService>();
            string ControllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
            string ActionName = filterContext.RouteData.Values["action"].ToString().ToLower();
            LogOperation data = new LogOperation
            {
                OperationName = filterContext.HttpContext.User.Identity.Name,
                OperationTime = DateTime.Now,
                TableName = ControllerName
            };
            
            if (!string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name))
            {

                if (ActionName == "create" && filterContext.HttpContext.Request.HttpMethod=="POST")
                {
                    JObject job = JObject.Parse(((ContentResult)filterContext.Result).Content);
                    if (job.GetValue("code").ToString()  == "0")
                    {
                        data.OperationType = 1;
                        data.Content = filterContext.HttpContext.User.Identity.Name + ":成功添加了[" + ControllerName + "]一条记录";
                        _ILogOperationAppService.CreateLogOperation_Sync(data);
                    }
                    
                }
                else if (ActionName == "edit" && filterContext.HttpContext.Request.HttpMethod == "POST")
                {
                    JObject job = JObject.Parse(((ContentResult)filterContext.Result).Content);
                    if (job.GetValue("code").ToString() == "0")
                    {
                        data.OperationType = 2;
                        data.Content = filterContext.HttpContext.User.Identity.Name + ":成功修改了[" + ControllerName + "]一条记录";
                        _ILogOperationAppService.CreateLogOperation_Sync(data);
                    }
                        
                }
                else if (ActionName == "delete" && filterContext.HttpContext.Request.HttpMethod == "POST")
                {
                    JObject job = JObject.Parse(((ContentResult)filterContext.Result).Content);
                    if (job.GetValue("code").ToString() == "0")
                    {
                        data.OperationType = 3;
                        data.Content = filterContext.HttpContext.User.Identity.Name + ":成功添加了[" + ControllerName + "]一条记录";
                        _ILogOperationAppService.CreateLogOperation_Sync(data);
                    }
                        
                }

                else if (ControllerName == "passport" && ActionName == "logout")
                {
                    data.OperationType = 5;
                    data.Content = filterContext.HttpContext.User.Identity.Name + ":退出登陆";
                    _ILogOperationAppService.CreateLogOperation_Sync(data);

                }
            }
            else
            {
                if (ControllerName == "passport" && ActionName == "logindo" && filterContext.HttpContext.Request.HttpMethod == "POST")
                {
                    JObject job = JObject.Parse(((ContentResult)filterContext.Result).Content);
                    if (job.GetValue("code").ToString() == "0")
                    {
                        data.OperationType = 4;
                        data.Content = filterContext.HttpContext.User.Identity.Name + ":登陆成功。";
                        _ILogOperationAppService.CreateLogOperation_Sync(data);
                    }
                }
            }
            
        }
    }

    public class InsertLog
    {
        private readonly ILogOperationAppService _ILogOperationAppService;
        public InsertLog(ILogOperationAppService ILogOperationAppService)
        {
            _ILogOperationAppService = ILogOperationAppService;
        }
       
    }


}