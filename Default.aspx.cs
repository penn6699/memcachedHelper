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
            MemcachedHelper mch = new MemcachedHelper();

            string key= Request["key"] ?? "a";
            string value = Request["value"] ?? "a08888";
            Response.Write(string.Format("key:{0}, value: {1}<br/>",key,value));


            if (mch.Set(key,value))
                Response.Write("保存成功1<br/>");
           
            Response.Write(mch.Get(key)+ "<br/>");

            //if (mch.Set(key + "test", value+"_d",30))
            //    Response.Write("保存成功2<br/>");
            //Response.Write(mch.Get<string>(key+ "test"));
        }
    }
}