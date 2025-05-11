<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="_MemberSearch.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE._MemberSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
   <!-- Breadcrumb Section Begin -->
    <div class="breacrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcrumb-text">
                        <h2><span>Search</span> Products</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumb Form Section Begin -->

   
   <!-- Register Section Begin -->
    
        <div class="container">
    <br />       
         <marquee scrolldelay="150" behavior="alternate">
          <img src="../images/103.cms.jpeg" width="300" height="180" alt="" /> &nbsp
          <img src="../images/108.cms.jpg" width="300" height="180" alt="" /> &nbsp
         <img src="../images/109.cms.jpeg" width="300" height="180" alt="" /> &nbsp
          </marquee>
          <br />
        <table style="width: 60%;" align="center">
            <tr>
                <td>
                    <strong>Search</strong></td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtSearch" runat="server" Width="550px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtSearch" ErrorMessage="*" 
                        ToolTip="Enter Category/Subcategory/ItemName" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                        Text="Search" ValidationGroup="a" />
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 90%;" align="center">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Table ID="Table1" runat="server">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        
        </div>
    
    </asp:Panel>

</asp:Content>
