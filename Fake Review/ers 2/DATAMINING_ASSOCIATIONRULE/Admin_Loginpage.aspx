<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Admin_Loginpage.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.Admin_Loginpage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               
<!-- Breadcrumb Section Begin -->
    <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Admin Login Form</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->
			<!-- Register Section Begin -->
            <div class="container">

                <table style="width: 34%;">
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left; width: 127px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            <strong><span style="font-size: small">Admin Id</span></strong></td>
                        <td style="font-size: small; text-align: left; width: 127px">
                            <span style="font-size: small">
                            <asp:TextBox ID="tb_uname" runat="server" CssClass="text" Width="200px"></asp:TextBox>
                            </span>
                        </td>
                        <td style="font-size: small; text-align: left">
                            <span style="font-size: small">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_uname"
                                CssClass="text" ErrorMessage="*" ToolTip="field required" 
                                ValidationGroup="Adminlogin"></asp:RequiredFieldValidator></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left; width: 127px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            <strong><span style="font-size: small">Password</span></strong></td>
                        <td style="font-size: small; text-align: left; width: 127px">
                            <span style="font-size: small">
                            <asp:TextBox ID="tb_pass" runat="server" CssClass="text" TextMode="Password" 
                                Width="200px"></asp:TextBox>
                            </span>
                        </td>
                        <td style="font-size: small; text-align: left">
                            <span style="font-size: small">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_pass"
                                CssClass="text" ErrorMessage="*" ToolTip="field required" 
                                ValidationGroup="Adminlogin"></asp:RequiredFieldValidator></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left; width: 127px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: right; ">
                           <asp:Button ID="submit" runat="server" 
                                    onclick="btn_submit_Click" ValidationGroup="Adminlogin" Text="Login" />
                         </td>
                        <td style="font-size: small; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left; width: 127px">
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        <td style="font-size: small; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="font-size: small; text-align: left; width: 85px">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: right; ">
                            &nbsp;</td>
                        <td style="font-size: small; text-align: left">
                            &nbsp;</td>
                    </tr>
                </table>
                
               
                
                <br />
          		<br />
	 </div>
        
</asp:Content>
