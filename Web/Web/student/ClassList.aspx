<%@ Page Title="ACEM-Classes List" Language="C#" MasterPageFile="~/Masters/StudentMaster.Master" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="Web.student.ClassList"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
	
		 <h3> All Classes</h3>
  
	<asp:GridView ID="classListGrid" runat="server" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="10" GridLines="Vertical"     
      >
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" />
        </Columns>
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
							 <asp:Button runat="server" CssClass="btn btn-primary " ID="enrollMebBtn" UseSubmitBehavior="true"   Text="Enroll Me" OnClick="EnrollMeBtn_Click"/>

</asp:Content>
