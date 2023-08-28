<%@ Page Title="" Language="C#" MasterPageFile="~/adminmenu.master" AutoEventWireup="true" CodeFile="frm_naivebayes.aspx.cs" Inherits="frm_naivebayes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style2
        {
            text-align: center;
            font-weight: 700;
            color: #000000;
            font-size: large;
            background-color: #FFFF66;
        }
        .style3
        {
        }
        .style4
        {
            color: #000000;
        }
        .style5
        {
            width: 219px;
            height: 33px;
        }
        .style6
        {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> Naive Bayes Classifier</h2>
<table class="style1">
    <tr>
        <td class="style2" colspan="4">
            <strong style="background-color: #FFFF66">INPUT</strong></td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
            Age Group</td>
        <td>
            <asp:DropDownList ID="drop_agegroup" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
            Gender</td>
        <td>
            <asp:DropDownList ID="drop_gender" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
            Locality</td>
        <td>
            <asp:DropDownList ID="drop_locality" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
            Season</td>
        <td>
            <asp:DropDownList ID="drop_season" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            </td>
        <td class="style6">
            </td>
        <td class="style6">
            <asp:Button ID="btn_predict" runat="server" Text="Predict Price Range" 
                onclick="btn_predict_Click" />
        </td>
        <td class="style6">
            </td>
    </tr>
    <tr>
        <td class="style3">
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
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="925px">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            <strong>Naive Bayes Classifier Result </strong></td>
        <td colspan="3">
            <asp:TextBox ID="txt_inter" runat="server" Height="135px" Width="736px" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
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

