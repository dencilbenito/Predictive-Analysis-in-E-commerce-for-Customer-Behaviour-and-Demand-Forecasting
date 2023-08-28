<%@ Page Title="" Language="C#" MasterPageFile="~/adminmenu.master" AutoEventWireup="true" CodeFile="frm_knn.aspx.cs" Inherits="frm_knn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            font-size: large;
            font-weight: bold;
        }
        .style5
        {
            font-size: medium;
            color: #000000;
            text-align: center;
            background-color: #CCFF66;
        }
        .style6
        {
            color: #000000;
        }
        .style7
        {
            font-size: large;
            text-align: center;
            color: #000000;
            background-color: #FFFF66;
        }
        .style8
        {
            background-color: #FF9900;
        }
        .style9
        {
            font-weight: bold;
            background-color: #FF9900;
        }
        .style10
        {
            font-size: large;
            font-weight: bold;
            background-color: #FFFFFF;
        }
        .style11
        {
            width: 158px;
        }
        .style12
        {
            width: 158px;
            background-color: #FF9900;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> K-Nearest Neighbour Classifier</h2>
    <table class="style1">
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                Enter Age
            </td>
            <td>
                <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                Select Gender</td>
            <td>
                <asp:DropDownList ID="drop_gender" runat="server">
                    <asp:ListItem Selected="True">&lt;--- Select ---&gt;</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                K-Input</td>
            <td>
                <asp:DropDownList ID="drop_criteria" runat="server">
                    <asp:ListItem>MainCategory_name</asp:ListItem>
                    <asp:ListItem>SubCategory_name</asp:ListItem>
                    <asp:ListItem>Brand_name</asp:ListItem>
                    <asp:ListItem>Product_name</asp:ListItem>
                    <asp:ListItem>Color_Name</asp:ListItem>
                    <asp:ListItem>Festival_name</asp:ListItem>
                    <asp:ListItem>Size_name</asp:ListItem>
                    <asp:ListItem>Gender</asp:ListItem>
                    <asp:ListItem>Locality_Purchased</asp:ListItem>
                    <asp:ListItem>Age_Group</asp:ListItem>
                    <asp:ListItem>Month</asp:ListItem>
                    <asp:ListItem>Season</asp:ListItem>
                    <asp:ListItem>Price_Group</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                From Date</td>
            <td>
                <asp:TextBox ID="txt_from" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                To Date</td>
            <td>
                <asp:TextBox ID="txt_to" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_ec" runat="server" Text="Calculate Euclidean Distance" 
                    onclick="btn_ec_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <span class="style6"></td>
            <td class="style10">
                K-Value</span></td>
            <td class="style9">
                <asp:Label ID="lbl_kvalue" runat="server" Text="-" 
                    style="font-size: large; color: #000000"></asp:Label>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7" colspan="4">
                <strong>Top k-value Euclidean distance Values (Shortest Distance)</strong></td>
        </tr>
        <tr>
            <td class="style2" colspan="4">
                <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                    GridLines="None" Width="933px">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
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
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="3">
                <strong>Finalized K-Nearest Neighbour Result</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" colspan="4">
                <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" 
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                    GridLines="None" Width="933px">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
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
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <strong>Inference</strong></td>
            <td colspan="3">
                <asp:TextBox ID="txt_inference" runat="server" Height="78px" Width="703px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

