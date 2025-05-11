<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="BrowseItems.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.BrowseItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
     
        <!-- Breadcrumb Section Begin -->
     <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Browse Products </h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->

   
   <!-- Register Section Begin -->
    
        <div class="container">
            <strong>Logged in as :
            <asp:Label ID="emailid" runat="server"></asp:Label>
            </strong>&nbsp;<br />
    <br />       
			
             <table style="width: 100%;">
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: left; width: 115px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 115px">
                                <b>Item Category</b></td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 115px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: left; width: 182px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 201px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 182px">
                                <b>Item SubCategory</b></td>
                            <td style="text-align: left; width: 201px">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" 
                                    AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 182px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 201px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                    </table>
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
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <table style="width: 86%;">
            <tr>
                <td style="text-align: left">
                    <asp:Button ID="Button1" runat="server" 
                        onclick="ImageButton1_Click" Text="Prev"/>
                </td>
                <td>
                    <asp:Label ID="LblMsg" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="Button2" runat="server" 
                         onclick="ImageButton2_Click" Text="Next" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="Button3" runat="server" 
                         onclick="ImageButton3_Click" Text="Back"/>
                </td>
            </tr>
        </table>
        <br />
     
        

	
	</div>
     
    </asp:Panel>
</asp:Content>
