<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login_page.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.Login_page" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="Panel1" runat="server">
       
 <!-- Breadcrumb Section Begin -->
    <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Login Form</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->
			<!-- Register Section Begin -->

               <div class="container">
             <br />
        <table style="width: 60%; height: 376px;">
            <tr>
                <td align="center" 
                     
                    valign="top">
                    <br />
                    <table style="width: 58%; height: 300px;">
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: center; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px; font-size: small;">
                                <b>EmailId</b></td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:TextBox ID="txt_username" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 154px; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txt_username" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="login"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px; font-size: small;">
                                <b>Password</b></td>
                            <td style="text-align: left; width: 154px; font-size: small;">
                                &nbsp;</td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:TextBox ID="txt_password" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 154px; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txt_password" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="login"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                            <asp:Button ID="Button1" runat="server" Text="Login" onclick="btn_submit_Click"  ValidationGroup="login"/>
                              <!--  <asp:ImageButton ID="btn_submit" runat="server" ImageUrl="~/images/CAUVGTUR.jpg" 
                                    onclick="btn_submit_Click" ValidationGroup="login" /> -->
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtn_newuser" runat="server" Font-Bold="True" 
                                    onclick="lbtn_newuser_Click" ForeColor="#006699" style="font-size: small">New 
                                User ? Click here ..</asp:LinkButton>
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 407px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
       <!-- <marquee scrolldelay="150" behavior="alternate">
          <img src="../images/Clothes_1.jpg" width="300" height="180" alt="" /> &nbsp
          <img src="../images/Clothes_4.jpg" width="300" height="180" alt="" /> &nbsp
         <img src="../images/Clothes_3.jpg" width="300" height="180" alt="" /> &nbsp
          </marquee>-->
		<br />
	</div>

   
    </asp:Panel>


</asp:Content>
