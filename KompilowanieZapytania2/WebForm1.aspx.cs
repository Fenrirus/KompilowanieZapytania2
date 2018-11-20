using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KompilowanieZapytania2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var compiled = CompiledQuery.Compile((SampleDataContext dataContext, int id) => from s in dataContext.Students
                                                                                            where s.ID == id
                                                                                            select s);

            using (SampleDataContext sdc = new SampleDataContext())
            {
                GridView1.DataSource = compiled(sdc, 2);
                GridView1.DataBind();
            }
        }
    }
}