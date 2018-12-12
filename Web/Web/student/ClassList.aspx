<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/StudentMaster.Master" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="Web.student.ClassList"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
	
		 <h3> All Classes</h3>
      <asp:GridView ID="classListGrid" runat="server" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Vertical" 
       ></asp:GridView>
</asp:Content>
