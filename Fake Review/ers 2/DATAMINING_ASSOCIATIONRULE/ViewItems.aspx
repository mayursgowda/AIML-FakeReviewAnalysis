<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewItems.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.ViewItems" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">

    <!-- Breadcrumb Section Begin -->
    <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Browse Products</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->

   
   <!-- Register Section Begin -->
    
        <div class="container">
    <br />       
               

                     
        <table style="width: 100%;">
            <tr>
                <td>
                    <table style="width: 99%;">
                        
                        <tr>
                            <td style="text-align: left; width: 115px">
                                <b>Category</b></td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="width: 88%;">
                        
                        <tr>
                            <td style="text-align: left; " class="style1">
                                <b>SubCategory</b></td>
                            <td style="text-align: left; " class="style2">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" 
                                    AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left" class="style3">
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>

              <tr>
                <td>
                   
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Table ID="Table1" runat="server" Width="1200px">
                    </asp:Table>
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%;">
            <tr>
                <td style="text-align: left">
                    <asp:Button ID="Button1" runat="server" onclick="ImageButton1_Click" 
                        Text="PREV" />
                </td>
                <td>
                    <asp:Label ID="LblMsg" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="Button2" runat="server" 
                        onclick="ImageButton2_Click" Text="NEXT" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="Button3" runat="server" onclick="ImageButton3_Click" 
                        Text="BACK" />
                </td>
            </tr>
        </table>
        <br />


            
       
    </div>
    <!-- Register Form Section End -->
    
          
			
      

		
	
    
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    
</asp:Content>

