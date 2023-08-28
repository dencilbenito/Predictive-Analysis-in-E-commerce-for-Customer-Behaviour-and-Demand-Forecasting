<%@ Page Title="" Language="C#" MasterPageFile="~/adminmenu.master" AutoEventWireup="true" CodeFile="frmdataset.aspx.cs" Inherits="frmdataset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 13px;
        }
        .style3
        {
            height: 22px;
        }
        .style4
        {
            height: 21px;
        }
        .style5
        {
            height: 25px;
        }
    .style6
    {
        width: 162px;
    }
    .style7
    {
        height: 25px;
        width: 162px;
    }
    .style8
    {
        height: 21px;
        width: 162px;
    }
    .style9
    {
        height: 22px;
        width: 162px;
    }
    .style10
    {
        height: 13px;
        width: 162px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> Input Historical Dataset</h2>
    <table class="style1">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Sales Number</td>
            <td>
                <asp:TextBox ID="txt_salesno" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Sales Date</td>
            <td>
                <asp:TextBox ID="txt_salesdate" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Main Category 
            </td>
            <td>
                <asp:DropDownList ID="drop_maincategory" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Sub Category</td>
            <td>
                <asp:DropDownList ID="drop_subcategory" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Brand Name</td>
            <td>
                <asp:DropDownList ID="drop_brandname" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Product Name</td>
            <td>
                <asp:DropDownList ID="drop_productname" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Quantity Purchased</td>
            <td>
                <asp:TextBox ID="txt_qty" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Color Name</td>
            <td>
                <asp:DropDownList ID="drop_colorname" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Festival Flag</td>
            <td>
                <asp:DropDownList ID="drop_flag" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Festival Name</td>
            <td>
                <asp:DropDownList ID="drop_festivalname" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
            </td>
            <td class="style5">
                Size&nbsp; Name</td>
            <td class="style5">
                <asp:DropDownList ID="drop_size" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style5">
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Gender</td>
            <td>
                <asp:DropDownList ID="drop_gender" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
            </td>
            <td class="style4">
                Locality Purchased</td>
            <td class="style4">
                <asp:DropDownList ID="drop_locality" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                Age</td>
            <td class="style3">
                <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td class="style3">
                Age Group</td>
            <td class="style3">
                <asp:DropDownList ID="drop_agegroup" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Month</td>
            <td>
                <asp:DropDownList ID="drop_month" runat="server">
                    <asp:ListItem Selected="True">January</asp:ListItem>
                    <asp:ListItem>February</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>September</asp:ListItem>
                    <asp:ListItem>October</asp:ListItem>
                    <asp:ListItem>November</asp:ListItem>
                    <asp:ListItem>December</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
            </td>
            <td class="style2">
                Season</td>
            <td class="style2">
                <asp:DropDownList ID="drop_season" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Price</td>
            <td>
                <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Price Group</td>
            <td>
                <asp:DropDownList ID="drop_pricegroup" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                Rating</td>
            <td>
                <asp:DropDownList ID="drop_rating" runat="server">
                    <asp:ListItem Selected="True">&lt;--- Select ---&gt;</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
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

