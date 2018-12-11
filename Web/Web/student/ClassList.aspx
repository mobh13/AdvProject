<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/StudentMaster.Master" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="Web.student.ClassList"  %>
<%@import Namespace="DB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
	
		 <h3> All Classes</h3>
        <table class="table">
            <tr>
        <th class="tableHead">Course Id</th>
        <th class="tableHead">Section Id</th>
        <th  class="tableHead">Course Title</th>
        <th class="tableHead">Location</th>
        <th class="tableHead">Time</th>
        <th class="tableHead">Date</th>
        <th class="tableHead">Instructor Name</th>
        <th class="tableHead">Enroll</th>
				
				   <%
					   
					   foreach ( Schedule schedule in scheduleList.List )
					   {

						   sectionsList.Filter("SectionID", schedule.SectionID);
						   Section section = (Section)sectionsList.List.ElementAt(0);
						   
						   taughtList.Filter("TaughtCourseID", section.TaughtCourseID);
						   TaughtCourses taughtcourse = (TaughtCourses)taughtList.List.ElementAt(0);
						   taughtList.Populate(taughtcourse);
						   courseList.Filter("CourseID", taughtcourse.CourseID);
						   Course course = (Course)courseList.List.ElementAt(0);
						   courseList.Populate(course);
						   locationList.Filter("LocationID", schedule.LocationID);
						   Location location = (Location)locationList.List.ElementAt(0);
						   locationList.Populate(location);
						   instructorList.Filter("InstructorID", section.InstructorID);
						   Instructor instructor = (Instructor)instructorList.List.ElementAt(0);
						   instructorList.Populate(instructor);


						  
        %>
        <tr>
            <td><% Response.Write(taughtcourse.CourseID);  %></td>
            <td><%  Response.Write(section.getID());  %></td>
            <td><%  Response.Write(course.Title);  %></td>
            <td><%  Response.Write(location.Name);  %></td>
            <td><%  Response.Write(schedule.Time);  %></td>
            <td><%  Response.Write(schedule.Day);  %></td>
            <td><%  Response.Write(instructor.FirstName + " " + instructor.LastName);  %></td>
            <td> <a href="?Enr=<%  Response.Write(schedule.SectionID);  %>">Enroll Me</a></td>
        </tr>
        <%}
			%>
       
        </table>
</asp:Content>
