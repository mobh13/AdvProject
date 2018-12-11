<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/StudentMaster.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="Web.student.Records" %>
<%@import Namespace="DB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	 <h3> My Records(Marks)</h3>
        <table class="table">
            <tr>
        <th class="tableHead">Course Id</th>
        <th class="tableHead">Section Id</th>
        <th  class="tableHead">Course Name</th>
				 <th class="tableHead">Instructor Name</th>
        <th class="tableHead">Mark</th>
				<%
					foreach (SectionStudent sectionStudent in sectionStudentList.List)
					{
						section = new Section(sectionStudent.SectionID);
						sectionList.Populate(section);
						instructor = new Instructor(section.InstructorID);
						instructorList.Populate(instructor);
						taughtCourses = new TaughtCourses(section.TaughtCourseID);
						taughtCoursesList.Populate(taughtCourses);
						course = new Course(taughtCourses.CourseID);
						courseList.Populate(course);
					%>
       
        <tr>
            <td><%Response.Write(course.getID()); %></td>
            <td><%Response.Write(section.getID()); %></td>
            <td><%Response.Write(course.Title); %></td>
            <td><%Response.Write(instructor.FirstName + " " + instructor.LastName); %></td>
            <td><%Response.Write(sectionStudent.Grade); %></td>
           
            </tr>
        <%} %>
        </table>
</asp:Content>
