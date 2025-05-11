<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Homepage.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.Admin_Homepage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Panel ID="Panel1" runat="server" >
    
  
        <!-- Breadcrumb Section Begin -->
    <div class="breacrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcrumb-text">
                        <h2><span>Welcome to Admin</span> Home</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumb Form Section Begin -->
			<div class="container">
           
               <br />

            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
        <br />
      
                   <table style="width: 97%;">
            <tr>
                <td valign="top">
                    <br />
                     <div id="popup">
                    <asp:Table ID="Table1" runat="server" Height="17px">
                    
                    </asp:Table>
                    </div>
                    <br />
                </td>
            </tr>
        </table>
                
    <br />

   	</div>


        
        
</asp:Panel>


</asp:Content>
