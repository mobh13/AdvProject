<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/InstructorMaster.Master" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="Web.instructor.ClassList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
		<form class="form-inline">

  <div class="form-group">
	 <label for="" style="margin-right:20px;">Wich CLasses To show ?</label>
	   <input type="Radio"id="MyClasses" name="ClaseesType">
    <label for="MyClasses">My Classes</label>
   <input type="Radio" id="AllCLasses" name="ClaseesType">
	   <label for="AllClasses">All Classes</label>
    
  </div>
  
</form>
	 <h3> My Classes</h3>
        <table class="table">
            <tr>
        <th class="tableHead">Course Id</th>
        <th class="tableHead">Section Id</th>
        <th  class="tableHead">Course Name</th>
        <th class="tableHead">Location</th>
        <th class="tableHead">Time</th>
        <th class="tableHead">Date</th>
        <th class="tableHead">Instructor Name</th>
        <th class="tableHead">Mark</th>
        <tr>
            <td>54545</td>
            <td>323</td>
            <td> Web Devlpment</td>
            <td>36.22</td>
            <td>17:00</td>
            <td>20/10/2018</td>
            <td>Mohamed Mada</td>
            <td>Mark</td>
            </tr>
              <tr>
            <td class="diffrentColor">33434</td>
            <td class="diffrentColor">434</td>
            <td class="diffrentColor"> Asp.net</td>
            <td class="diffrentColor">19.22</td>
            <td class="diffrentColor">15:00</td>
            <td class="diffrentColor">10/10/2018</td>
            <td class="diffrentColor">Abdullah Khalil</td>
            <td class="diffrentColor">Mark</td>
           
            </tr>
               <tr>
            <td>54545</td>
            <td>545</td>
            <td> Web Devlpment</td>
            <td>36.22</td>
            <td>17:00</td>
            <td>20/10/2018</td>
            <td>Mohamed Mada</td>
            <td>Mark</td>
            </tr>
        </table>
	 <h3> All Classes</h3>
        <table class="table">
            <tr>
        <th class="tableHead">Course Id</th>
        <th class="tableHead">Section Id</th>
        <th  class="tableHead">Course Name</th>
        <th class="tableHead">Location</th>
        <th class="tableHead">Time</th>
        <th class="tableHead">Date</th>
        <th class="tableHead">Instructor Name</th>

        <tr>
            <td>54545</td>
            <td>323</td>
            <td> Web Devlpment</td>
            <td>36.22</td>
            <td>17:00</td>
            <td>20/10/2018</td>
            <td>Mohamed Mada</td>
       
            </tr>
              <tr>
            <td class="diffrentColor">33434</td>
            <td class="diffrentColor">434</td>
            <td class="diffrentColor"> Asp.net</td>
            <td class="diffrentColor">19.22</td>
            <td class="diffrentColor">15:00</td>
            <td class="diffrentColor">10/10/2018</td>
            <td class="diffrentColor">Abdullah Khalil</td>
    
           
            </tr>
               <tr>
            <td>54545</td>
            <td>545</td>
            <td> Web Devlpment</td>
            <td>36.22</td>
            <td>17:00</td>
            <td>20/10/2018</td>
            <td>Mohamed Mada</td>
 
            </tr>
        </table>
</asp:Content>
