using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class addupdatedelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        submit.Visible = true;
        Label4.Visible = false;
        TextBox7.Visible = false;
        Button5.Visible = false;
        iD.Visible = false;
        TextBox1.Visible = false;
        Button3.Visible = false;
        submit.Text = "Add";
        form2.Visible = true;
        Button6.Text = "Registration Form";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        submit.Visible = true;
        Label4.Visible = false;
        TextBox7.Visible = false;
        Button5.Visible = false;
        iD.Visible = true;
        TextBox1.Visible = true;
        Button3.Visible = true;
        form2.Visible = false;
        Button6.Text = "Update Information";
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        string str;
        SqlCommand com;
        if (submit.Text == "Add")
        {
            str = "insert into info (Name,Department,Sem,Contact,City) values (@name,@dept,@sem,@contact,@city)";
            com = new SqlCommand(str, conn);
            com.Parameters.AddWithValue("@name", TextBox2.Text);
            com.Parameters.AddWithValue("@dept", TextBox3.Text);
            com.Parameters.AddWithValue("@sem", TextBox4.Text);
            com.Parameters.AddWithValue("@contact", TextBox5.Text);
            com.Parameters.AddWithValue("@city", TextBox6.Text);
            com.ExecuteNonQuery();
            Response.Redirect("addupdatedelete.aspx");
        }
        else if (submit.Text == "Update")
        {
            com = new SqlCommand();
            com.CommandText = "update info set Name='" + TextBox2.Text + "',Department='" + TextBox3.Text + "',Sem='" + TextBox4.Text + "',Contact='" + TextBox5.Text + "',City='" + TextBox4.Text + "' where id='" + TextBox1.Text + "' ";
            com.Connection = conn;
            com.ExecuteNonQuery();
            Response.Redirect("addupdatedelete.aspx");
        }
        else if (submit.Text == "Delete")
        {
            str = "delete from info where id=@id AND penalty=0 AND @id NOT IN (select id from issuebook)";
            com = new SqlCommand(str, conn);
            com.Parameters.AddWithValue("@id", TextBox7.Text);

            com.ExecuteNonQuery();
            Response.Redirect("addupdatedelete.aspx");
        }
        conn.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        form2.Visible = true;
        submit.Text = "Update";
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            String str = "select * from info where id=@id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", TextBox1.Text);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox2.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0]["Sem"].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                TextBox6.Text = ds.Tables[0].Rows[0]["CIty"].ToString();
            }
            else
            {
                Response.Redirect("addupdatedelete.aspx");
                Response.Write("No record found");
            }
            con.Close();
        }
        catch (Exception err)
        {

            Console.WriteLine("error in retrieve bt " + err);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        form2.Visible = true;
        TextBox2.ReadOnly = true;
        TextBox3.ReadOnly = true;
        TextBox4.ReadOnly = true;
        TextBox5.ReadOnly = true;
        TextBox6.ReadOnly = true;
        submit.Text = "Delete";
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            String str = "select * from info where id=@id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", TextBox7.Text);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox2.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0]["Sem"].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                TextBox6.Text = ds.Tables[0].Rows[0]["CIty"].ToString();
            }
            else
            {
                Response.Redirect("addupdatedelete.aspx");
                Response.Write("No record found");
            }
            con.Close();
        }
        catch (Exception err)
        {

            Console.WriteLine("error in retrieve bt " + err);
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        submit.Visible = true;
        Label4.Visible = true;
        TextBox7.Visible = true;
        Button5.Visible = true;
        iD.Visible = false;
        TextBox1.Visible = false;
        Button3.Visible = false;
        Button6.Text = "Deletion Form";
        form2.Visible = false;
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("infoadmin.aspx");
    }
}