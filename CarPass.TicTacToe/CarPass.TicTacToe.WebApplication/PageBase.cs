using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPass.TicTacToe.WebApplication
{
    public abstract class PageBase : System.Web.UI.Page
    {
        public virtual string Prefix
        {
            get
            {
                string prefix = DateTime.Now.Ticks.ToString();
                if (Request.QueryString["sp"] != null)
                {
                    prefix = Request.QueryString["sp"];
                }
                return prefix;
            }
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            SetNoCache();
        }

        private void SetNoCache()
        {
            //Response.Buffer = true;
            //Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            //Response.Expires = -1500;
            Response.CacheControl = "no-cache"; // for IE
            Response.Cache.SetNoStore(); // for firefox and chrome
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            BindModel();
        }

        protected abstract void BindModel();
    }
}