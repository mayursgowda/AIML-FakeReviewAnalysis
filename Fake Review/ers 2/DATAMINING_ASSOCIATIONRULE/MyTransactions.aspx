﻿<%@ Page Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="MyTransactions.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.MyTransactions" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
    
     <!-- Breadcrumb Section Begin -->
     <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>My Orders</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->

   
   <!-- Register Section Begin -->
    
        <div class="container">
    <br />       
			

            <br />
        <table style="width: 90%;">
            <tr>
                <td>
                    <table style="width: 94%;">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbtn_pending" runat="server" Font-Bold="True" 
                                    ForeColor="#006699" onclick="lbtn_pending_Click">Pending Transactions</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtn_All" runat="server" Font-Bold="True" 
                                    ForeColor="#006699" onclick="lbtn_All_Click">All Transactions</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtn_Dispatched" runat="server" Font-Bold="True" 
                                    ForeColor="#006699" onclick="lbtn_Dispatched_Click">Dispatched Transactions</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Table ID="Table1" runat="server">
                    </asp:Table>
                    <br />
                </td>
            </tr>
        </table>
        <br />
       

		
	</div>


        
    </asp:Panel>
</asp:Content>
