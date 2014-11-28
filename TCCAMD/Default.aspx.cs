using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCAMD
{
    public partial class _Default : Page
    {
        protected String getWelcome()
        {
            if (DateTime.Now.Hour < 18)
                return "Bonjour";
            else
                return "Bonsoir";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}