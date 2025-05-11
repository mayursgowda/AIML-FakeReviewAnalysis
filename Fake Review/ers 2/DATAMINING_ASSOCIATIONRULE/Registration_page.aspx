<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registration_page.aspx.cs" Inherits="DATAMINING_ASSOCIATIONRULE.Registration_page" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="Panel1" runat="server">
       
<!-- Breadcrumb Section Begin -->
    <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Register Form for New Users</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
    <!-- Breadcrumb Form Section Begin -->
			<!-- Register Section Begin -->


			 <div class="container">
             <br />

<table style="width: 98%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <p style="text-align: justify; width: 928px; margin-top: 0; margin-bottom: 0; line-height: 150%;">
                        </span></span></b><span style="color: #000000">Please provide details and register here.</span></p>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <div style="text-align: left">
        </div>
        <table style="width: 940px; height: 630px;">
            <tr>
                <td align="center" 
                    width: 490px;" 
                    valign="top">
                    <div style="text-align: left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #006699; font-weight: bold">&nbsp;&nbsp;
                        <span style="font-size: small">What is your e-mail address ?</span></span></div>
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
                        <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #006699; font-size: small;"> Enter Name and 
                        Password</span></b><br />
                    </div>
                    <table style="width: 80%;">
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; font-size: small;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>Enter Password</b></td>
                            <td style="text-align: left; width: 151px">
                                <span style="font-size: small">
                                <asp:TextBox ID="txt_password" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                </span>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txt_password" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="registration">Enter Password</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>Confirm Password</b></td>
                            <td style="text-align: left; width: 151px">
                                <span style="font-size: small">
                                <asp:TextBox ID="txt_confirm" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <span style="font-size: small">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txt_confirm" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="registration">Enter Confirm Password</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="txt_password" ControlToValidate="txt_confirm" 
                                    ErrorMessage="*" ToolTip="mismatch" ValidationGroup="registration">Mismatch</asp:CompareValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; font-size: small;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>Enter Your Name</b></td>
                            <td style="text-align: left; width: 151px">
                                <span style="font-size: small">
                                <asp:TextBox ID="txt_Name" runat="server" Width="200px"></asp:TextBox>
                                </span>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txt_Name" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="registration">Enter Name</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small; height: 26px;">
                                <strong>Gender</strong></td>
                            <td style="text-align: left; width: 151px; font-size: small; height: 26px;">
                                <asp:DropDownList ID="dropdownlistGender" runat="server" Width="205px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left; font-size: small; height: 26px;">
                                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                    ControlToValidate="dropdownlistGender" ErrorMessage="*" Operator="NotEqual" 
                                    ToolTip="Select Gender" ValidationGroup="registration" ValueToCompare="Select">Select Gender</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>Marital Status</b></td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                <asp:DropDownList ID="dropdownlistMartialstatus" runat="server" Width="205px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Single</asp:ListItem>
                                    <asp:ListItem>Married</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:CompareValidator ID="CompareValidator4" runat="server" 
                                    ControlToValidate="dropdownlistMartialstatus" ErrorMessage="*" 
                                    Operator="NotEqual" ToolTip="Select Martial Status" 
                                    ValidationGroup="registration" ValueToCompare="Select">Select Marital Status</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>Address</b></td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txt_address" ErrorMessage="*" ToolTip="field required" 
                                    ValidationGroup="registration">Enter Address</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>ContactNo</b></td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                <asp:TextBox ID="txt_contactNo" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txt_contactNo" ErrorMessage="*" ToolTip="filed required" 
                                    ValidationGroup="registration">Enter ContactNo</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txt_contactNo" ErrorMessage="*" 
                                    ValidationExpression="\d{10}" ValidationGroup="registration" 
                                    ToolTip="only numbers">Only 10 Numbers</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small; font-weight: 700;">
                                Landmark</td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="TextBox1" ErrorMessage="*" ToolTip="filed required" 
                                    ValidationGroup="registration">Enter Landmark</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 140px; font-size: small;">
                                <b>Country</b></td>
                            <td style="text-align: left; width: 151px; font-size: small;">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: left; font-size: small;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="TextBox2" ErrorMessage="*" ToolTip="filed required" 
                                    ValidationGroup="registration">Enter Country</asp:RequiredFieldValidator>
                            </td>
                        </tr>
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
                    </table>

                       
            <div class="form-group">
            <p>Age</p>
                <asp:DropDownList ID="ddlAge" runat="server">
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>51</asp:ListItem>
                    <asp:ListItem>52</asp:ListItem>
                    <asp:ListItem>53</asp:ListItem>
                    <asp:ListItem>54</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem>56</asp:ListItem>
                    <asp:ListItem>57</asp:ListItem>
                    <asp:ListItem>58</asp:ListItem>
                    <asp:ListItem>59</asp:ListItem>
                    <asp:ListItem>60</asp:ListItem>
                    <asp:ListItem>61</asp:ListItem>
                    <asp:ListItem>62</asp:ListItem>
                    <asp:ListItem>63</asp:ListItem>
                    <asp:ListItem>64</asp:ListItem>
                    <asp:ListItem>65</asp:ListItem>
                    <asp:ListItem>66</asp:ListItem>
                    <asp:ListItem>67</asp:ListItem>
                    <asp:ListItem>68</asp:ListItem>
                    <asp:ListItem>69</asp:ListItem>
                    <asp:ListItem>70</asp:ListItem>
                    <asp:ListItem>71</asp:ListItem>
                    <asp:ListItem>72</asp:ListItem>
                    <asp:ListItem>73</asp:ListItem>
                    <asp:ListItem>74</asp:ListItem>
                    <asp:ListItem>75</asp:ListItem>
                    <asp:ListItem>76</asp:ListItem>
                    <asp:ListItem>77</asp:ListItem>
                    <asp:ListItem>78</asp:ListItem>
                    <asp:ListItem>79</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>81</asp:ListItem>
                    <asp:ListItem>82</asp:ListItem>
                    <asp:ListItem>83</asp:ListItem>
                    <asp:ListItem>84</asp:ListItem>
                    <asp:ListItem>85</asp:ListItem>
                    <asp:ListItem>86</asp:ListItem>
                    <asp:ListItem>87</asp:ListItem>
                </asp:DropDownList>           
           				
			</div>


             <div class="form-group">
             <p>Screen Time</p>
                <asp:DropDownList ID="ddlExperience" runat="server">
                  <asp:ListItem>0</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                      <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                       <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                         <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                           <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                             <asp:ListItem>10</asp:ListItem>
                              <asp:ListItem>11</asp:ListItem>
                               <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                 <asp:ListItem>14</asp:ListItem>
                                 <asp:ListItem>15</asp:ListItem>
                                  <asp:ListItem>16</asp:ListItem>
                                   <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>

                                     <asp:ListItem>19</asp:ListItem>
                                      <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                         <asp:ListItem>22</asp:ListItem>
                                         <asp:ListItem>23</asp:ListItem>
                                         <asp:ListItem>24</asp:ListItem>
                                       <asp:ListItem>25</asp:ListItem>

                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>65</asp:ListItem>
                    <asp:ListItem>70</asp:ListItem>
<asp:ListItem>75</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>85</asp:ListItem>
                </asp:DropDownList>     
                
                       <div class="form-group">
                       <p>TotalPosts</p>
                <asp:DropDownList ID="ddlTotalPosts" runat="server">
                  <asp:ListItem>0</asp:ListItem>
                  <asp:ListItem>5</asp:ListItem>
                  <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>51</asp:ListItem>
                    <asp:ListItem>52</asp:ListItem>
                    <asp:ListItem>53</asp:ListItem>
                    <asp:ListItem>54</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem>56</asp:ListItem>
                    <asp:ListItem>57</asp:ListItem>
                    <asp:ListItem>58</asp:ListItem>
                    <asp:ListItem>59</asp:ListItem>
                    <asp:ListItem>60</asp:ListItem>
                    <asp:ListItem>61</asp:ListItem>
                    <asp:ListItem>62</asp:ListItem>
                    <asp:ListItem>63</asp:ListItem>
                    <asp:ListItem>64</asp:ListItem>
                    <asp:ListItem>65</asp:ListItem>
                    <asp:ListItem>66</asp:ListItem>
                    <asp:ListItem>67</asp:ListItem>
                    <asp:ListItem>68</asp:ListItem>
                    <asp:ListItem>69</asp:ListItem>
                    <asp:ListItem>70</asp:ListItem>
                    <asp:ListItem>71</asp:ListItem>
                    <asp:ListItem>72</asp:ListItem>
                    <asp:ListItem>73</asp:ListItem>
                    <asp:ListItem>74</asp:ListItem>
                    <asp:ListItem>75</asp:ListItem>
                    <asp:ListItem>76</asp:ListItem>
                    <asp:ListItem>77</asp:ListItem>
                    <asp:ListItem>78</asp:ListItem>
                    <asp:ListItem>79</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>81</asp:ListItem>
                    <asp:ListItem>82</asp:ListItem>
                    <asp:ListItem>83</asp:ListItem>
                    <asp:ListItem>84</asp:ListItem>
                    <asp:ListItem>85</asp:ListItem>
                    <asp:ListItem>86</asp:ListItem>
                    <asp:ListItem>87</asp:ListItem>
                    <asp:ListItem>90</asp:ListItem>
                    <asp:ListItem>100</asp:ListItem>
                    <asp:ListItem>120</asp:ListItem>
                    <asp:ListItem>150</asp:ListItem>
                    <asp:ListItem>180</asp:ListItem>
                    <asp:ListItem>200</asp:ListItem>
                </asp:DropDownList>           
           				
			</div>

             <div class="form-group">
             <p>HowOften</p>
                <asp:DropDownList ID="ddlHowoften" runat="server">
                <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Daily</asp:ListItem>
                    <asp:ListItem>Weekly</asp:ListItem>
                    <asp:ListItem>Monthly</asp:ListItem>
                </asp:DropDownList>           
           				
			</div>

             <div class="form-group">
             <p>Location</p>
                <asp:DropDownList ID="ddlLocation" runat="server">
                    <asp:ListItem>Shimoga</asp:ListItem>
                    <asp:ListItem>Bengaluru</asp:ListItem>
                     <asp:ListItem>Mysuru</asp:ListItem>
                      <asp:ListItem>Mandya</asp:ListItem>
                </asp:DropDownList>           
           				
			</div>
           				
			
			<div class="row">
				<div class="col-xs-12 col-md-6">
                <asp:Button ID="Button1" runat="server" Text="Register" onclick="btn_registration_Click"/>
                </div>

                       
				
			</div>
		
	

</div>
                    <br />
                   
                    <br style="font-size: small" />
                </td>
                <td align="center" valign="middle">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
         <!--<marquee scrolldelay="150" behavior="alternate">
          <img src="../images/cat_11.jpg" width="300" height="180" alt="" /> &nbsp
          <img src="../images/cat_14.jpg" width="300" height="180" alt="" /> &nbsp
         <img src="../images/cat_15.jpg" width="300" height="180" alt="" /> &nbsp
          </marquee>
		<br />-->
	</div>



        
              
    </asp:Panel>
    

</asp:Content>
