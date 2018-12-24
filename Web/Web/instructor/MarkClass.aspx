<%@ Page Title="ACEM-Mark Class" Language="C#" MasterPageFile="~/Masters/InstructorMaster.Master" AutoEventWireup="true" CodeBehind="MarkClass.aspx.cs" Inherits="Web.instructor.MarkClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3> Mark Class</h3>

	<p><b>Section ID:</b> <asp:Label ID="SectionIdLbl" runat="server" ></asp:Label></p>
	<p><b>Course ID:</b> <asp:Label ID="CourseID" runat="server" ></asp:Label> </p>
	<p><b>Course Name:</b><asp:Label ID="CourseName" runat="server" ></asp:Label>  
    </p>
  <asp:GridView ID="detailsGridView" runat="server" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="10" GridLines="Vertical"     onselectedindexchanged="DetailsGridView_SelectedIndexChanged"
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
	<asp:TextBox runat="server" ID="Mark"> </asp:TextBox>
					 <asp:Button runat="server" CssClass="btn btn-primary " ID="submitMarks" UseSubmitBehavior="true"   Text="Submit Mark" OnClick="SubmitMarks_Click"/>

</asp:Content>
