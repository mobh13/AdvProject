﻿<%@ Page Title="ACEM-Instructor TimeTable" Language="C#" MasterPageFile="~/Masters/InstructorMaster.Master" AutoEventWireup="true" CodeBehind="TimeTable.aspx.cs" Inherits="Web.instructor.TimeTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h3> My Time Table</h3>
       <asp:GridView ID="timeTableGridView" runat="server" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="10" GridLines="Vertical"
      >
        <AlternatingRowStyle BackColor="#DCDCDC" />
      
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
</asp:Content>