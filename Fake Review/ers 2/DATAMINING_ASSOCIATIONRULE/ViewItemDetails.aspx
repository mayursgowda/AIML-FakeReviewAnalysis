<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewItemDetails.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.ViewItemDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">

    <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>View Product Details</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
 <div class="container">
    <br />     
			
			
             <br />
     <table style="width:96%;">
        <tr>
            <td valign="top">
            <div id="popup">
                <asp:Table ID="TableBD" runat="server" style="text-align: left" 
                    HorizontalAlign="Left">
                </asp:Table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Lbl_Msg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    
        <br />
     <asp:Table ID="Table1" runat="server">
     </asp:Table>

        <br />

		
	</div>



    
    
    </asp:Panel>
</asp:Content>
