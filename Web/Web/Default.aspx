<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <div class="jumbotron">
        <h1>ACEM College</h1>
        <p class="lead">Welcome to the ACEM Managment System</p>
        
    </div>

    <div class="row">
		
     <div class="col-lg-4 center-block text-center loginBox" >
		 
		<form id="login-form" method="post" name="LoginForm" role="form" target="_self" >
            <h3>Login</h3>
			
			<asp:panel runat="server" id="meassgaePanel" visible="false">
				<div class="alert alert-danger"><asp:Literal runat="server" id="errormsg" /></div>
    
</asp:panel>
             
             <div class="main-login-form">
                 <div class="login-group">
                     <div class="form-group ">
                         <label for="lg_username" class="sr-only">UserId</label>
                         <%--<input type="text" class="" id="lg_username" name="lg_username" placeholder="username">--%>
						         <asp:TextBox runat="server" ID="lg_username"  CssClass="form-control center-block" placeholder="UserId"></asp:TextBox>

                     </div>
                     <div class="form-group">
                         <label for="lg_password" class="sr-only">Password</label>
                         <%--<input type="password" class="form-control center-block" id="lg_password" name="lg_password" placeholder="password">--%>
						 <asp:TextBox runat="server" ID="lg_password"  CssClass="form-control center-block" placeholder="password" TextMode="Password"></asp:TextBox>

                     </div>
                     <div class="form-group login-group-checkbox">
						 <asp:CheckBox  runat="server" id="lg_remembe" />
                         <%--<input type="checkbox" id="lg_remember" name="lg_remember">--%>
                         <label for="lg_remember">remember me ?</label>
                      
                     </div>
                       <div class="form-group">
                     <h4>Account Type</h4>
						   <asp:RadioButton  runat="server" id="studentAccount" GroupName="accountType" />
                         <%--<input type="radio" name="accountType" id="studentAccount" />--%>
                         <label for="studentAccount" > Student</label>
						   <asp:RadioButton  runat="server" id="instructorAccount" GroupName="accountType" />
                         <%--<input type="radio" name="accountType" id="instructorAccount" />--%>
                         <label for="instructorAccount" > Instructor</label>
                     </div>
                    
                 </div>
				 <asp:Button runat="server" CssClass="btn btn-primary " ID="LoginButton"  Text="Login" OnClick="LoginButton_Click"/>
                 <%--<button type="submit" class="btn btn-primary "  name="LoginButton" id="LoginButton" >Login</button>--%>
             </div>
            
         </form>
	</div>
    </div>

</asp:Content>
