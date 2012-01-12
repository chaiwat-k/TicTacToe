<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CarPass.TicTacToe.WebApplication.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tic Tac Toe</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 286px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td bgcolor="#3366FF" class="style2">
                <asp:Label ID="TitleLabel" runat="server" Text="TIC TAC TOE GAME" ForeColor="White"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                <div style="float: left">
                    <asp:LinkButton ID="NewLinkButton" runat="server" OnClick="NewLinkButton_Click">New</asp:LinkButton>
                    &nbsp;|
                    <asp:LinkButton ID="QuitLinkButton" runat="server" OnClick="QuitLinkButton_Click">Quit</asp:LinkButton>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" 
                            >
                        </asp:Timer>
                        <asp:Label ID="TimeLabel" runat="server" Text="0" Style="float: right" BackColor="#99CCFF"
                            BorderColor="Blue" ForeColor="#CC00FF"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style1" rowspan="2">
                <asp:GridView ID="GamesGridView" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" Caption="Passed Games" EmptyDataText="No Game played">
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
                <br />
                <asp:GridView ID="StatisticsGridView" runat="server" Caption="Statistics" CellPadding="4"
                    ForeColor="#333333" GridLines="None" EmptyDataText="No Game played">
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
            <td align="center" valign="top" class="style2">
                <table align="center" bgcolor="#CCCCCC" style="width: 100%;">
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="LB0" runat="server" OnClick="LB0_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="LB3" runat="server" OnClick="LB3_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="LB6" runat="server" OnClick="LB6_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="LB1" runat="server" OnClick="LB1_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="LB4" runat="server" OnClick="LB4_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="LB7" runat="server" OnClick="LB7_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="LB2" runat="server" OnClick="LB2_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="LB5" runat="server" OnClick="LB5_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="LB8" runat="server" OnClick="LB8_Click"
                            ImageUrl="~/Images/u.png"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
                <h3>
                    <asp:Label ID="MsgLabel" runat="server" Text="Welcome to Tic Tac Toe" BackColor="#99CCFF"
                        BorderColor="Blue" ForeColor="#CC00FF"></asp:Label>
                </h3>
                <div>
                    <input id="Button1" type="button" value="Instructions" onclick="location='http://itdev02/Training/Instructions.htm'"; />
                </div>
            </td>
        </tr>
    </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
    </form>
</body>
</html>
