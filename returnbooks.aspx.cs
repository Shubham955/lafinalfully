using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class returnbooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        String str2 = "SELECT CONVERT (date, SYSDATETIME())";
        SqlCommand cmd2 = new SqlCommand(str2, con);
        cmd2.ExecuteNonQuery();
        SqlDataAdapter da2 = new SqlDataAdapter();
        da2.SelectCommand = cmd2;
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        String presentdate = ds2.Tables[0].Rows[0][0].ToString();

        String str = "select id,issuedate from issuebook where accessionno=@accno";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        String issuedate = ds.Tables[0].Rows[0]["issuedate"].ToString();
        String stu_id = ds.Tables[0].Rows[0]["id"].ToString();

        String str3 = "SELECT DATEDIFF(day,@startdate,@enddate)";
        SqlCommand cmd3 = new SqlCommand(str3, con);
        cmd3.Parameters.AddWithValue("@startdate",issuedate);
        cmd3.Parameters.AddWithValue("@enddate", presentdate);
        cmd3.ExecuteNonQuery();
        SqlDataAdapter da3 = new SqlDataAdapter();
        da3.SelectCommand = cmd3;
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);

        int diff = Convert.ToInt32(ds3.Tables[0].Rows[0][0].ToString());

        String str4 = "select time_limit,daily_fine from card_rules"; 
        SqlCommand cmd4 = new SqlCommand(str4, con);
        
        cmd4.ExecuteNonQuery();
        SqlDataAdapter da4 = new SqlDataAdapter();
        da4.SelectCommand = cmd4;
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        int tl = Convert.ToInt32(ds4.Tables[0].Rows[0]["time_limit"].ToString());
        int df = Convert.ToInt32(ds4.Tables[0].Rows[0]["daily_fine"].ToString());
        

        int fine;
        String str7 = "select penalty from info where id='" + stu_id + "'";
        SqlCommand cmd7 = new SqlCommand(str7, con);
        cmd7.ExecuteNonQuery();
        SqlDataAdapter da7 = new SqlDataAdapter();
        da7.SelectCommand = cmd7;
        DataSet ds7 = new DataSet();
        da7.Fill(ds7);
        fine = Convert.ToInt32(ds7.Tables[0].Rows[0]["penalty"].ToString());

        if(diff>tl)
        {
            fine =fine+ ((diff - tl) * df);
        }

        String str6 = "update info set penalty='" + fine + "' where id='" + stu_id + "'";
        SqlCommand cmd6 = new SqlCommand(str6, con);
        int j=cmd6.ExecuteNonQuery();
        if (j == 1)
        {
            String str5 = "delete from issuebook where accessionno=@accno";
            SqlCommand cmd5 = new SqlCommand(str5, con);
            cmd5.Parameters.AddWithValue("@accno", TextBox1.Text);
            int i = cmd5.ExecuteNonQuery();
            if (i == 1)
            {
                Label3.Text = "Book returned and Total fine(till date):" + fine + " Rupees";
            }
        }
        con.Close();
    }
}