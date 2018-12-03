<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/StudentMaster.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="Web.student.Records" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	 <h3> My Records(Marks)</h3>
        <table class="table">
            <tr>
        <th class="tableHead">Course Id</th>
        <th class="tableHead">Section Id</th>
        <th  class="tableHead">Course Name</th>

        <th class="tableHead">Instructor Name</th>
        <th class="tableHead">Mark</th>
        <tr>
            <td>54545</td>
            <td>323</td>
            <td> Web Devlpment</td>
            <td>Mohamed Mada</td>
            <td>15</td>
            </tr>
              <tr>
            <td class="diffrentColor">33434</td>
            <td class="diffrentColor">434</td>
            <td class="diffrentColor"> Asp.net</td>

            <td class="diffrentColor">Abdullah Khalil</td>
            <td class="diffrentColor">10</td>
           
            </tr>
               <tr>
            <td>54545</td>
            <td>545</td>
            <td> Web Devlpment</td>

            <td>Mohamed Mada</td>
            <td>20</td>
            </tr>
        </table>
</asp:Content>
