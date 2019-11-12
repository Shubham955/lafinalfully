using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class bookissue : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label8.Text = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();

        String str2 = "select accessionno from issuebook where accessionno=@accessno";
        SqlCommand cmd2 = new SqlCommand(str2, con);
        cmd2.Parameters.AddWithValue("@accessno", TextBox1.Text);
        cmd2.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd2;

        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Label8.Text = "Book Already Issued";
        }
        else
        {

            String str = "select title,author_name from books where accessionno=@accno";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter();
            da2.SelectCommand = cmd;

            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            if(ds2.Tables[0].Rows.Count>0)
            {
                TextBox8.Text = ds2.Tables[0].Rows[0]["title"].ToString();
                TextBox2.Text = ds2.Tables[0].Rows[0]["author_name"].ToString();
            }
            else
            {
                Label8.Text = "Book does not exists";
            }

        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        String stu_name,dept;
        Label8.Text = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();

        String str2 = "select id,name,department from info where id=@id";
        SqlCommand cmd2 = new SqlCommand(str2, con);
        cmd2.Parameters.AddWithValue("@id", TextBox3.Text);
        cmd2.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd2;

        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
                stu_name=ds.Tables[0].Rows[0]["name"].ToString();
                dept=ds.Tables[0].Rows[0]["department"].ToString();
                
                String str="select count(id) from issuebook where id=@id";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", TextBox3.Text);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = cmd;

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                int bookcount = Convert.ToInt32(ds2.Tables[0].Rows[0][0].ToString());

                String str3 = "select * from card_rules";
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();
                
                SqlDataAdapter da3 = new SqlDataAdapter();
                da3.SelectCommand = cmd3;
                
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);

                
                int issuerule = Convert.ToInt32(ds3.Tables[0].Rows[0]["max_books"].ToString());
                
                

                if(bookcount<issuerule)
                {
                    TextBox7.Text = stu_name;
                    TextBox4.Text = dept;
                }
                else
                {
                    Label8.Text = "Reached Maximum Limit of Books to be issued";
                }
        }
        else
        {
            Label8.Text = "Student does not exists";
        }
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label8.Text = "";
        if(TextBox2.Equals("") || TextBox4.Equals("") || TextBox7.Equals("") || TextBox8.Equals(""))
        {
            //do nothing as either student or book has failed some criteria
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            String str3 = "select * from card_rules";
            SqlCommand cmd3 = new SqlCommand(str3, con);
            cmd3.ExecuteNonQuery();

            SqlDataAdapter da3 = new SqlDataAdapter();
            da3.SelectCommand = cmd3;

            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            int tl = Convert.ToInt32(ds3.Tables[0].Rows[0]["time_limit"].ToString());
            int df = Convert.ToInt32(ds3.Tables[0].Rows[0]["daily_fine"].ToString());
            String str2="SELECT CONVERT (date, SYSDATETIME())";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd2;
            DataSet ds = new DataSet();
            da.Fill(ds);
            String issuedate = ds.Tables[0].Rows[0][0].ToString();
            
            

            String str = "insert into issuebook values('" + TextBox1.Text + "','" + TextBox3.Text+"','"+TextBox8.Text+"','"+issuedate+"')";
            SqlCommand cmd = new SqlCommand(str, con);
            //cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            //cmd.Parameters.AddWithValue("@id", TextBox3.Text);
            //cmd.Parameters.AddWithValue("@bname", TextBox8.Text);
            //cmd.Parameters.AddWithValue("@issuedate", issuedate);
            int i=cmd.ExecuteNonQuery();

            if(i==1)
            {
                Label8.Text = "Book with Accession No: " + TextBox1.Text + " assigned to " + TextBox3.Text + " and you have to return in " + tl + " days otherwise penalty per day: " + df + " Rupees"; 
            }
            con.Close();
        }
        
    }
}