<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <div class="jumbotron">
        <h1>ACEM College</h1>
        <p class="lead">Welcome to the ACEM Managment System</p>
        
    </div>

    <div class="row">
        
     <div class="col-lg-4 center-block text-center loginBox" >
		<form id="login-form" >
            <h3>Login</h3>
             <div class="login-form-main-message"></div>
             <div class="main-login-form">
                 <div class="login-group">
                     <div class="form-group ">
                         <label for="lg_username" class="sr-only">Username</label>
                         <input type="text" class="form-control center-block" id="lg_username" name="lg_username" placeholder="username">
                     </div>
                     <div class="form-group">
                         <label for="lg_password" class="sr-only">Password</label>
                         <input type="password" class="form-control center-block" id="lg_password" name="lg_password" placeholder="password">
                     </div>
                     <div class="form-group login-group-checkbox">
                         <input type="checkbox" id="lg_remember" name="lg_remember">
                         <label for="lg_remember">remember me ?</label>
                      
                     </div>
                       <div class="form-group">
                     <h4>Account Type</h4>
                         <input type="radio" name="accountType" id="studentAccount" />
                         <label for="studentAccount" > Student</label>
                         <input type="radio" name="accountType" id="instructorAccount" />
                         <label for="instructorAccount" > Instructor</label>
                     </div>
                    
                 </div>
                 <button type="submit" class="btn btn-primary ">Login</button>
             </div>
            
         </form>
	</div>
    </div>

</asp:Content>
