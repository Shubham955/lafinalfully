using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class add_books : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnadd_book_Click(object sender, EventArgs e)
    {
        lbladd_book.Text = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();

        if (btnadd_book.Text.Equals("Add Data"))
        {
            String str2 = "select accessionno from books order by accessionno desc";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter();
            da2.SelectCommand = cmd2;
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            int lastacc = Convert.ToInt32(ds2.Tables[0].Rows[0]["accessionno"].ToString());

            int g = Convert.ToInt32(TextBox1.Text);
            while (g > 0)
            {
                String str = "insert into books(title,author_name,publisher,booktype,booklanguage) values(@name,@author_name,@publisher,@booktype,@lang)";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@name", txtbook_name.Text);
                cmd.Parameters.AddWithValue("@author_name", txtbook_author.Text);
                cmd.Parameters.AddWithValue("@publisher", txtbook_publi.Text);
                cmd.Parameters.AddWithValue("@booktype", ddlbook_type.SelectedIndex.ToString());
                cmd.Parameters.AddWithValue("@lang", TextBox2.Text);
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select password from admin
                cmd.ExecuteNonQuery();
                g--;
            }

            if (Convert.ToInt32(TextBox1.Text) > 1)
            {
                lbladd_book.Text = "Book(s) with Accession Number(s) from" + (lastacc + 1) + " to " + (lastacc + Convert.ToInt32(TextBox1.Text)) + " have been added";
            }
            else
            {
                lbladd_book.Text = "Book with Accession Number " + (lastacc + 1) + " has been added";
            }
            

            
        }
        else if(btnadd_book.Text.Equals("Update Data"))
        {
            String str = "update books set title=@name,author_name=@author_name,publisher=@publisher,booktype=@booktype,booklanguage=@lang where accessionno=@accno";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@name", txtbook_name.Text);
            cmd.Parameters.AddWithValue("@author_name", txtbook_author.Text);
            cmd.Parameters.AddWithValue("@publisher", txtbook_publi.Text);
            cmd.Parameters.AddWithValue("@booktype", ddlbook_type.SelectedIndex.ToString());
            cmd.Parameters.AddWithValue("@lang", TextBox1.Text);
            cmd.Parameters.AddWithValue("@accno", TextBox4.Text);
            int i=cmd.ExecuteNonQuery();
            if(i==1)
            {
                lbladd_book.Text = "Data Updated";
            }
        }
        else if(btnadd_book.Text.Equals("Delete Data"))
        {
            String str = "delete from books where accessionno=@accno";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@accno", TextBox4.Text);
            int i=cmd.ExecuteNonQuery();
            if(i==1)
            {
                lbladd_book.Text = "Data Deleted";
            }
        }
        con.Close();
        //Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
      }


    protected void Button5_Click(object sender, EventArgs e)
    {
        lbladd_book.Text = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        String str = "select * from books where accessionno=@accesno";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@accesno", TextBox4.Text);
        cmd.ExecuteNonQuery();

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataSet ds = new DataSet();
        da.Fill(ds);

        if(ds.Tables[0].Rows.Count >0)
        {
            txtbook_name.Text = ds.Tables[0].Rows[0]["title"].ToString();
            txtbook_author.Text = ds.Tables[0].Rows[0]["author_name"].ToString();
            txtbook_publi.Text = ds.Tables[0].Rows[0]["publisher"].ToString();
            int ind=Convert.ToInt32(ds.Tables[0].Rows[0]["booktype"].ToString());
            ddlbook_type.SelectedIndex=ind;
            TextBox2.Text = ds.Tables[0].Rows[0]["booklanguage"].ToString();

        }
        else
        {
            lbladd_book.Text = "Wrong Accession No";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button5.Visible = false;
        Labelheading.Text = "Add Data";
        Labelacc.Visible = false;
        TextBox4.Visible = false;
        Labelheading.Visible = true;
        Labelname.Visible = true;
        Labelauthor.Visible = true;
        Labelpub.Visible = true;
        Labellang.Visible = true;
        Labelcat.Visible = true;
        Labelcop.Visible = true;
        txtbook_name.Visible = true;
        txtbook_author.Visible = true;
        txtbook_publi.Visible=true;
        ddlbook_type.Visible=true;
        TextBox1.Visible=true;
        TextBox2.Visible=true;
        btnadd_book.Visible=true;
        btnadd_book.Text = "Add Data";
        btnadd_book.Visible = true;
        txtbook_name.ReadOnly = false;
        txtbook_author.ReadOnly = false;
        txtbook_publi.ReadOnly = false;
        TextBox1.ReadOnly = false;
        TextBox2.ReadOnly = false;
        ddlbook_type.Enabled = true;
        

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        btnadd_book.Text = "Update Data";
        Labelheading.Text = "Update Data";
        Button5.Visible = true;
        Labelacc.Visible = true;
        TextBox4.Visible = true;
        Labelheading.Visible = true;
        Labelname.Visible = true;
        Labelauthor.Visible = true;
        Labelpub.Visible = true;
        Labelcat.Visible = true;
        Labelcop.Visible = false;
        txtbook_name.Visible = true;
        txtbook_author.Visible = true;
        txtbook_publi.Visible = true;
        ddlbook_type.Visible = true;
        Labellang.Visible = true;
        TextBox1.Visible =false;
        TextBox2.Visible = true;
        btnadd_book.Visible = true;
        txtbook_name.ReadOnly = false;
        txtbook_author.ReadOnly = false;
        txtbook_publi.ReadOnly = false;
        TextBox1.ReadOnly = false;
        TextBox2.ReadOnly = false;
        ddlbook_type.Enabled = true;
;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        btnadd_book.Text = "Delete Data";
        Labelheading.Text = "Delete Data";
        Labelacc.Visible = true;
        TextBox4.Visible = true;
        Labelheading.Visible = true;
        Labelname.Visible = true;
        Labelauthor.Visible = true;
        Labelpub.Visible = true;
        Labelcat.Visible = true;
        Labelcop.Visible = false;
        Labellang.Visible = true;
        txtbook_name.Visible = true;
        txtbook_author.Visible = true;
        txtbook_publi.Visible = true;
        ddlbook_type.Visible = true;
        TextBox1.Visible = false;
        TextBox2.Visible = true;
        btnadd_book.Visible = true;
        txtbook_name.ReadOnly = true;
        txtbook_author.ReadOnly = true;
        txtbook_publi.ReadOnly = true;
        TextBox1.ReadOnly = true;
        TextBox2.ReadOnly = true;
        ddlbook_type.Enabled = false;
        Button5.Visible = true;
    }
}