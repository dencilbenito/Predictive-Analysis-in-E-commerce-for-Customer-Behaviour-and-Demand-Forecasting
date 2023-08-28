<%@ Page Title="" Language="C#" MasterPageFile="~/adminmenu.master" AutoEventWireup="true" CodeFile="Frm_Rankinganalysis.aspx.cs" Inherits="Frm_Rankinganalysis" %>

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
            width: 152px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> Mean Ranking Analysis</h2>
    <table class="style1">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
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
            <td class="style4">
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
            <td class="style4">
                &nbsp;</td>
            <td>
                Criteria</td>
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
                    <asp:ListItem>Rating</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Rank Analysis" 
                    onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td class="style3" colspan="4">
                <asp:Chart ID="Chart1" runat="server" Height="456px" Width="933px">
                    <Series>
                        <asp:Series ChartType="Bar" Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX>
                                <MajorGrid Enabled="False" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style2" colspan="4">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" Width="934px" style="text-align: center">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
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

