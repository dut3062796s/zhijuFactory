using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TY.Web.Framework
{
    public class ConfigInfo
    {
        #region 站点信息

        private string _shopname = "智居恩洛";//商城名称
        private string _siteurl = "http://www.59599.com";//网站网址
        private string _sitetitle = "智居恩洛";//网站标题
        private string _seokeyword = "";//seo关键字
        private string _seodescription = "";//seo描述
        private string _icp = "浙江";//备案编号
        private string _script = "";//脚本
        private int _islicensed = 1;//是否显示版权(0代表不显示，1代表显示)
        private string _defcity = "浙江|杭州";



        /// <summary>
        /// 商城名称
        /// </summary>
        public string ShopName
        {
            get { return _shopname; }
            set { _shopname = value; }
        }
        /// <summary>
        /// 网站网址
        /// </summary>
        public string SiteUrl
        {
            get { return _siteurl; }
            set { _siteurl = value; }
        }
        /// <summary>
        /// 网站标题
        /// </summary>
        public string SiteTitle
        {
            get { return _sitetitle; }
            set { _sitetitle = value; }
        }
        /// <summary>
        /// seo关键字
        /// </summary>
        public string SEOKeyword
        {
            get { return _seokeyword; }
            set { _seokeyword = value; }
        }
        /// <summary>
        /// seo描述
        /// </summary>
        public string SEODescription
        {
            get { return _seodescription; }
            set { _seodescription = value; }
        }
        /// <summary>
        /// 备案编号
        /// </summary>
        public string ICP
        {
            get { return _icp; }
            set { _icp = value; }
        }
        /// <summary>
        /// 脚本
        /// </summary>
        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }
        /// <summary>
        /// 是否显示版权(0代表不显示，1代表显示)
        /// </summary>
        public int IsLicensed
        {
            get { return _islicensed; }
            set { _islicensed = value; }
        }

        /// <summary>
        /// 默认城市  浙江|杭州
        /// </summary>
        public string DefCity
        {
            get { return _defcity; }
            set { _defcity= value; }
        }

        #endregion
    }
}
