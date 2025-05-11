<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="PostReviews.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.PostReviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

 <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Post Product Review</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    
<div class="container">
<br />

<h2>POST REVIEW</h2>
<hr class="colorgraph">


			
			 <div class="form-group">
                 <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
            
           				
			</div>

			<div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter Review" 
                    tabindex="4" ID="txtReview" runat="server" TextMode="MultiLine" Width=50% 
                    Height="200px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Enter Review" ControlToValidate="txtReview" 
                    CssClass="validation" ToolTip="Enter Review" ValidationGroup="a">Enter Review</asp:RequiredFieldValidator>

			</div>

                       
			
			
			<div class="row">
				<div class="col-xs-12 col-md-6">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        class="btn btn-primary btn-block btn-lg" Width=50% 
                        ValidationGroup="a" onclick="btnUpdate_Click" />
                    <br />
                    <asp:Label ID="lblPercentage" runat="server" Text=""></asp:Label>
                    &nbsp;<br /><asp:Label ID="Label1" runat="server"></asp:Label>
                    &nbsp;<br /> <asp:Label ID="Label2" runat="server"></asp:Label>
                    &nbsp;<br />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    &nbsp;<br />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    &nbsp;<br />
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    </div>
				
			</div>
		
	

</div>

    &nbsp;&nbsp;

<br />
<br />

</asp:Panel>

</asp:Content>
