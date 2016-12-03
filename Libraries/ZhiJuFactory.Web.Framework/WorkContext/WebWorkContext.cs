using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TY.Web.Framework
{
    /// <summary>
    /// 系统前台工作上下文类
    /// </summary>
    public class WebWorkContext
    {
        public ConfigInfo Config = new ConfigInfo();

        public bool IsHttpAjax;//是否ajax提交

        public string IP;//用户ip

        public string Url;//当前url

        public string UrlReferrer;//上一次访问的url

        public DateTime GetTime = DateTime.Now;

        public string ImgHost="";//图片服务器;

        #region 登录信息


        public int M_Type = -1;//用户类型

        public int M_Id = -1;//用户id

        public string M_UserName;//用户名

        public string M_Email;//用户邮箱

        public string M_Mobile;//用户手机号

        public string M_Name;//姓名

        public string M_UpdateTime ;//最后登录时间

        public string M_Fax;//传真

        public string M_Tel;//电话

        public string M_Role;//权限

        public string Type;//身份类型 0=前台用户，1=后台



        #endregion

       

       






    }
}
