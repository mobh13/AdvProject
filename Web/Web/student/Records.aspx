<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/StudentMaster.Master" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="Web.student.Records" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	 <h3> My Records(Marks)</h3>
        <asp:GridView ID="MarksGrid" runat="server" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Vertical" 
       ></asp:GridView>
</asp:Content>
