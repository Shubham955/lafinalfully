<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="add books.aspx.cs" Inherits="add_books"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <style>

   .button{
	display: inline-block;
	color: #666;
	background-color: #eee;
	text-transform: uppercase;
	letter-spacing: 2px;
	font-size: 12px;
	padding: 10px 30px;
	border-radius: 5px;
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
	border: 1px solid rgba(0,0,0,0.3);
	border-bottom-width: 3px;
}

	.button:hover {
		background-color: #e3e3e3;
		border-color: rgba(0,0,0,0.5);
	}
	
	
    .abc {
        text-align:center;
        margin-top:20px;
    }
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 85px;
        }
        .auto-style3 {
            height: 26px;
            width: 85px;
        }
    </style>
    
   <div class ="abc">
<asp:Button CssClass="button" ID="Button1" runat="server" Text="add" OnClick="Button1_Click" />
<asp:Button CssClass="button" ID="Button2" runat="server" Text="update" OnClick="Button2_Click"  />
<asp:Button CssClass="button" ID="Button3" runat="server" Text="delete" OnClick="Button3_Click" />
       </div>


<%--<form id="form1" action="#">--%>
            
               <h1 style="text-align:center; color:black">
                   <asp:Label ID="Labelheading" runat="server" Text="Add New Books" Visible="False"></asp:Label>
&nbsp;</h1>
       
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
     <table align="center" >
         <tr>
             <td class="auto-style2"> <asp:Label ID="Labelacc" runat="server" Text="Accession no:" Visible="False"></asp:Label> </td>
             <td>    <asp:TextBox ID="TextBox4" runat="server" Width="156px" CssClass="txt" Visible="False"></asp:TextBox> </td>
         </tr>

            <tr>
                <td>
                    <asp:Button CssClass="button" ID="Button5" runat="server" Text="Retrive Info" OnClick="Button5_Click" Visible="False" />

                </td>
                </tr>

                <td class="auto-style2"><asp:Label ID="Labelname" runat="server" Text="Book Name:" Visible="False"></asp:Label></td>
                 
                <td>    <asp:TextBox ID="txtbook_name" runat="server" Width="156px" CssClass="txt" Visible="False"></asp:TextBox></td>
            
            <tr>
                <td class="auto-style3"><asp:Label ID="Labelauthor" runat="server" Text="Book Author:" Visible="False"></asp:Label> </td>
                
                <td style="height: 26px">
                    <asp:TextBox ID="txtbook_author" runat="server" Width="156px" CssClass="txt" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Labelpub" runat="server" Text="Publisher:" Visible="False"></asp:Label> </td>
               
                <td>
                    <asp:TextBox ID="txtbook_publi" runat="server" Width="156px" CssClass="txt" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Labelcat" runat="server" Text="Categor:y" Visible="False"></asp:Label> </td>
               
                <td>
                    <asp:DropDownList ID="ddlbook_type" runat="server" Width="156px" Visible="False" >
                        <asp:ListItem>Choose One</asp:ListItem>
                        <asp:ListItem>Computer Science</asp:ListItem>
                        <asp:ListItem>Literarure</asp:ListItem>
                        <asp:ListItem>History</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                   <asp:Label ID="Labelcop" runat="server" Text="Copies:" Visible="False"></asp:Label>                 </td>
                
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox1" runat="server" Width="156px" CssClass="txt" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                   <asp:Label ID="Labellang" runat="server" Text="Language:" Visible="False"></asp:Label>
                </td>
                
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="156px" CssClass="txt" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style2">
                    <asp:Button ID="btnadd_book" runat="server" Text="Add Book" CssClass="btn" OnClick="btnadd_book_Click" Visible="False" />
                </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbladd_book" runat="server" 
                        Font-Bold="True" ForeColor="Lime"></asp:Label>
                </td>
            </tr>
            </table>
       
    <%-- </form>--%>
 

</asp:Content>

