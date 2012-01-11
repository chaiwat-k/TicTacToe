using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarPass.TicTacToe.WebApplication
{
    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?sp="+Prefix);
        }

        protected override void BindModel()
        {
            
        }
    }
}
