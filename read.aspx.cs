using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class read : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            string key = Request["key"] ?? "a";
           
            Response.Write(string.Format("key:{0}<br/>", key));
            
            Response.Write(MemcachedHelper.Get(key));
            Response.Write("<br/>");
            Response.Write(MemcachedHelper.Get(key + "test"));
        }

    }
}