<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ResultAnalysis.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.ResultAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

<section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Naive Bayes Algorithm Results</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    
<div class="container">
<br />



			
		<br />

         <table style="width: 100%;">
             <tr>
                 <td>
                    
                     <asp:Table ID="Table1" runat="server">
                     </asp:Table>
                    
                 </td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
           
         </table>
            <br />
            <br />
		
	

</div>

<br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
<br />

</asp:Panel>

</asp:Content>
