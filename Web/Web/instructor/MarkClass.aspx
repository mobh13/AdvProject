<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/InstructorMaster.Master" AutoEventWireup="true" CodeBehind="MarkClass.aspx.cs" Inherits="Web.instructor.MarkClass" %>
<%@import Namespace="DB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h3> Mark Class</h3>

	<p><b>Section ID:</b> <% Response.Write(section.getID()); %> </p>
	<p><b>Course ID:</b> <% Response.Write(taughtCourses.CourseID); %>  </p>
	<p><b>Course Name:</b>  <% Response.Write(course.Title); %> </p>
	   <table class="table">
            <tr>
        <th class="tableHead">Student ID</th>
        <th  class="tableHead">Student Name</th>
        <th class="tableHead">Mark</th>
        
				<%
					foreach (SectionStudent sectionStudent in sectionStudentList.List)
					{
						Student student = new Student(sectionStudent.StudentID);
						studentList.Populate(student);

					%>
			  <tr>
            <td> <% Response.Write(sectionStudent.StudentID); %></td>
            <td> <% Response.Write(student.FirstName + " " +student.LastName); %></td>
 

            <td> <input type="text"  id="<% Response.Write(sectionStudent.StudentID); %>" name=" <% Response.Write(sectionStudent.StudentID); %>"class="input" placeholder="Mark" />
			</td>
            
            </tr>
		   <%} %>
		   </table>
					 <asp:Button runat="server" CssClass="btn btn-primary " ID="submitMarks" UseSubmitBehavior="true"   Text="Submit Marks" OnClick="submitMarks_Click"/>

	<%--<button name="submitMarks" type="submit" class="btn btn-active">Submit Marks</button>--%>
</asp:Content>
