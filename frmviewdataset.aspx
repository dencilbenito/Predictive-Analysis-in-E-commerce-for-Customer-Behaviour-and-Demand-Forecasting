<%@ Page Title="" Language="C#" MasterPageFile="~/adminmenu.master" AutoEventWireup="true" CodeFile="frmviewdataset.aspx.cs" Inherits="frmviewdataset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> View Dataset</h2>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" DataSourceID="LinqDataSource1" ForeColor="Black" 
        GridLines="None" Width="914px">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="Sales_no" HeaderText="Sales no." ReadOnly="True" 
                SortExpression="Sales_no" />
            <asp:BoundField DataField="Sales_date" HeaderText="Sales Date" ReadOnly="True" 
                SortExpression="Sales_date" />
            <asp:BoundField DataField="MainCategory_name" HeaderText="MainCategory Name" 
                ReadOnly="True" SortExpression="MainCategory_name" />
            <asp:BoundField DataField="SubCategory_name" HeaderText="SubCategory Name" 
                ReadOnly="True" SortExpression="SubCategory_name" />
            <asp:BoundField DataField="Brand_name" HeaderText="Brand name" ReadOnly="True" 
                SortExpression="Brand_name" />
            <asp:BoundField DataField="Product_name" HeaderText="Product name" 
                ReadOnly="True" SortExpression="Product_name" />
            <asp:BoundField DataField="Qty_Purchased" HeaderText="Qty Purchased" 
                ReadOnly="True" SortExpression="Qty_Purchased" />
            <asp:BoundField DataField="Locality_Purchased" HeaderText="Locality" 
                ReadOnly="True" SortExpression="Locality_Purchased" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" 
                SortExpression="Gender" />
            <asp:BoundField DataField="Age_Group" HeaderText="Age Group" ReadOnly="True" 
                SortExpression="Age_Group" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="dbconnectDataContext" EntityTypeName="" 
        Select="new (Sales_no, Sales_date, MainCategory_name, SubCategory_name, Brand_name, Product_name, Qty_Purchased, Locality_Purchased, Gender, Age_Group)" 
        TableName="HistoricalDatasets">
    </asp:LinqDataSource>
</p>
</asp:Content>

