<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Subcategories.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.Subcategories" %>
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
                     <h3>Manage Product SubCategories</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->
     
     <div class="container">
           
               <br />
			
       <asp:Panel ID="Panel4" runat="server">
         
                                    <table style="width: 57%;">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <fieldset><legend style="color: #006699"><b>New SubCategory</b></legend>
                                                <table style="width: 83%;">
                                                    <tr>
                                                        <td style="text-align: left; width: 107px">
                                                            &nbsp;</td>
                                                        <td style="text-align: left; width: 205px">
                                                            &nbsp;</td>
                                                        <td style="text-align: left">
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left; width: 107px">
                                                            <b>Category</b></td>
                                                        <td style="text-align: left; width: 205px">
                                                            <b>
                                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="205px">
                                                            </asp:DropDownList>
                                                            </b>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <b>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                                ControlToValidate="DropDownList1" ErrorMessage="*" Operator="NotEqual" 
                                                                ToolTip="select category" ValidationGroup="subcategory" 
                                                                ValueToCompare="- All -" Font-Size="Small"></asp:CompareValidator>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left; width: 107px">
                                                            <b>SubCategory</b></td>
                                                        <td style="text-align: left; width: 205px">
                                                            <b>
                                                            <asp:TextBox ID="txt_newsubcategory" runat="server" Width="200px"></asp:TextBox>
                                                            </b>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <b>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                ControlToValidate="txt_newsubcategory" ErrorMessage="*" 
                                                                ToolTip="field required" ValidationGroup="subcategory"></asp:RequiredFieldValidator>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left; width: 107px">
                                                            <b>Description</b></td>
                                                        <td style="text-align: left; width: 205px">
                                                            <b>
                                                            <asp:TextBox ID="txt_description" runat="server" Height="50px" 
                                                                TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                            </b>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <b>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                ControlToValidate="txt_description" ErrorMessage="*" ToolTip="field required" 
                                                                ValidationGroup="subcategory"></asp:RequiredFieldValidator>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left; width: 107px">
                                                            &nbsp;</td>
                                                        <td style="text-align: left; width: 205px">
                                                            &nbsp;</td>
                                                        <td style="text-align: left">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left; width: 107px">
                                                           
                                                        </td>
                                                        <td style="text-align: right; width: 205px">
                                                            <b>
                                                            <asp:Button ID="btn_subcategory" runat="server" onclick="btn_subcategory_Click" 
                                                                Text="Submit" ValidationGroup="subcategory" />
                                                            </b>
                                                        </td>
                                                        <td style="text-align: left">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <br />
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                   
                                    <table style="width: 91%;">
                                        <tr>
                                            <td>
                                                <asp:Table ID="Table2" runat="server">
                                                </asp:Table>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                   
                                </asp:Panel>


		</div>
	
     
    </asp:Panel>



</asp:Content>
