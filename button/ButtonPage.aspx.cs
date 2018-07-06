using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace button
{
    public partial class ButtonPage : System.Web.UI.Page
    {
        int clicks = 0;
        int total = 0;
        SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:buttonserver.database.windows.net,1433;Initial Catalog=buttonDatabase;Integrated Security=False;User Id=oops@buttonserver;Password=oops;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True;");


        protected void Page_Load(object sender, EventArgs e)
        {
            //lblCount.Text = hfID.Value;
            if (!IsPostBack)
            {
                updateTotal();
                fillGridView();
                resetCounter();
            }
        }

        public static int testy()
        {
            return 69;
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            //lblCount.Text = (++count).ToString();
            if(int.TryParse(btnAdd.Text, out clicks))
            {
                btnAdd.Text = (++clicks).ToString();
            }
            if (clicks > 0)
                btnUpload.Enabled = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("UploadClicks", sqlCon);
            SqlCommand sqlCmd = new SqlCommand("AddName", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@id", (hfID.Value == "" ? 0 : Convert.ToInt32(hfID.Value)));
            //sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(hfID.Value).ToString());
            sqlCmd.Parameters.AddWithValue("@name", txtName.Text);
            //sqlCmd.Parameters.AddWithValue("@clicks", Convert.ToInt32(lblCount.Text));
            sqlCmd.Parameters.AddWithValue("@clicks", Convert.ToInt32(btnAdd.Text));
            sqlCmd.ExecuteNonQuery();
            updateTotal();
            sqlCon.Close();
            resetCounter();
            fillGridView();
        }

        public void updateTotal()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ClickSum", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            object yeet = sqlCmd.ExecuteScalar();
            total = Convert.ToInt32(yeet.ToString());
            lblTotalCount.Text = total.ToString();
            sqlCon.Close();
        }

        public void resetCounter()
        {
            clicks = 0;
            btnAdd.Text = clicks.ToString();
            btnUpload.Enabled = false;
            //lblCount.Text = clicks.ToString();
        }
        void fillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewAll", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvScoreboard.DataSource = dtbl;
            gvScoreboard.DataBind();
        }
    }
}
