using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DropDownListExp
{
    public partial class DropDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             ddlOptions.DataSource = GetData("spGetOption", null);
             ddlOptions.DataBind();
                ListItem liOption = new ListItem("Select Option", "-1");
                ddlOptions.Items.Insert(0, liOption);

                ListItem liPolicy = new ListItem("Select Policy", "-1");
                ddlPolicy.Items.Insert(0, liPolicy);

                ddlPolicy.Enabled = false;

            }
        }

        private DataSet GetData(string SpName, SqlParameter SpParameter)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["ConnStringTestDb"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnString);
            SqlDataAdapter da = new SqlDataAdapter(SpName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (SpParameter != null)
            {
                da.SelectCommand.Parameters.Add(SpParameter);
            }
            DataSet DS = new DataSet();
            da.Fill(DS);
            return DS;

        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOptions.SelectedIndex !=0)
            {
                ddlPolicy.Enabled = true;
                SqlParameter parameter = new SqlParameter("@OptionId", ddlOptions.SelectedValue);
                DataSet DS =GetData("spGetPolicyByOptionId ", parameter);
                ddlPolicy.DataSource = DS;
                ddlPolicy.DataBind();
                ListItem liPolicy = new ListItem("Select Policy", "-1");
                ddlPolicy.Items.Insert(0, liPolicy);
            }
        }
    }
}