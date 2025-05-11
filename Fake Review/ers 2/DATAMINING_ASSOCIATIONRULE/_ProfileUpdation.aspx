<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="_ProfileUpdation.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE._ProfileUpdation" %>
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
                     <h3>Update AOI</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->

   
   <!-- Register Section Begin -->
    
        <div class="container">
    <br />       
			
        <div style="text-align: left">
        </div>
        <table style="width: 940px; height: 630px;">
            <tr>
                <td align="center" 
                    width: 490px;" 
                    valign="top">
                    <div style="text-align: left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #006699; font-weight: bold">&nbsp;&nbsp;<span style="font-size: small">Your 
                        e-mail address ?</span></span></div>
                    <table style="width: 80%;">
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 200px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; font-size: small;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>My Email Address</b></td>
                            <td style="text-align: left; width: 200px">
                              
                                <asp:TextBox ID="txt_EmailID" runat="server" Width="200px"></asp:TextBox>
                                
                            </td>
                            <td style="text-align: left">
                               
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txt_EmailID" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="registration">Enter EmailId</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txt_EmailID" ErrorMessage="*" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="registration" ToolTip="Invalid Format">Invalid Format</asp:RegularExpressionValidator>
                               
                            </td>
                        </tr>
                    </table>
                    <div style="text-align: left">
                        <br />
                        <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #006699; font-size: small;"> 
                        Enter Details</span></b><br />
                    </div>
                    <table style="width: 80%;">
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <strong>AOI</strong></td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                <asp:DropDownList ID="DropDownListAOI" runat="server" Width="205px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                    Text="Update AOI" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                   
                    <br style="font-size: small" />
                </td>
                <td align="center" valign="middle">
                    &nbsp;</td>
            </tr>
        </table>
        <br />

		
	</div>



        
              
    </asp:Panel>

</asp:Content>
