<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/InstructorMaster.Master" AutoEventWireup="true" CodeBehind="MarkClass.aspx.cs" Inherits="Web.instructor.MarkClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h3> Mark Class</h3>

	<p><b>Section ID:</b> 5555 </p>
	   <table class="table">
            <tr>
        <th class="tableHead">Course Id</th>
        <th class="tableHead">Student ID</th>
        <th  class="tableHead">Student Name</th>
        <th class="tableHead">Mark</th>
        
        <tr>
            <td>54545</td>
            <td>323</td>
            <td> Mohamed Madan </td>
            <td><input class="input" type="text" /></td>
            
            </tr>
		   </table>
	<button name="submitMarks" type="submit" class="btn btn-active">Submit Marks</button>
</asp:Content>
