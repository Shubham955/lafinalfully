using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class cardrules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //Response.Write("2");
        con.Open();

        String str = "select * from card_rules";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds=new DataSet();
        da.Fill(ds);
        
        if(ds.Tables[0].Rows.Count >0)
        {
            TextBox1.Text = ds.Tables[0].Rows[0]["max_books"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["time_limit"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["daily_fine"].ToString();
        }
        else
        {
            Response.Write("4");
            Label5.Text = "No Rules Created till now";
        }
        //con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //Response.Write("2");
        con.Open();

        String str = "update card_rules set time_limit=@timelimit,daily_fine=@dailyfine,max_books=@maxbooks";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@timelimit", TextBox2.Text);
        cmd.Parameters.AddWithValue("@dailyfine", TextBox3.Text);
        cmd.Parameters.AddWithValue("@maxbooks", TextBox1.Text);
        int i=cmd.ExecuteNonQuery();
        if(i>0)
        {
            Label5.Text = "Rules Updated";
        }
    }
}