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
        if (IsPostBack) {
            MemcachedHelper mch = new MemcachedHelper();

            string key= Request["key"] ?? "a";
            string value = Request["value"] ?? "0";
            if (mch.Set(key, value))
                Response.Write("保存成功");

            Response.Write(mch.Get<string>(key));
        }
    }
}