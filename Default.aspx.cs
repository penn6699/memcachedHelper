using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            

            string key= Request["key"] ?? "a";
            string value = Request["value"] ?? "a08888";
            Response.Write(string.Format("key:{0}, value: {1}<br/>",key,value));


            if (MemcachedHelper.Set(key,value))
                Response.Write("保存成功1<br/>");
           
            Response.Write(MemcachedHelper.Get(key)+ "<br/>");

            if (MemcachedHelper.Set(key + "test", value+ "_test", 3))
                Response.Write("保存成功2<br/>");
            Response.Write(MemcachedHelper.Get(key + "test"));
            Response.Write("<br/>"+DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
        }
    }
}