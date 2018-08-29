using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace university.Web.ueditor1_4_2_utf8
{
    public partial class editor_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.divouput.InnerHtml = this.hidEditorCnt.Value;
        }
    }
}