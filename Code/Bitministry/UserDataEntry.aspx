<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDataEntry.aspx.cs" Inherits="UserDataEntry" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Font-Size="Large" Font-Bold="true" Font-Underline="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">

                    <asp:Button ID="btnDepositeAmount" runat="server" Text="Deposite Money" OnClick="btnDepositeAmount_Click" />
                    <asp:Button ID="btnCurrentBalance" runat="server" Text="Current Balance" OnClick="btnCurrentBalance_Click" CausesValidation="false"/>
                    <asp:Button ID="btnGetStatement" runat="server" Text="Get Statement" OnClick="btnGetStatement_Click" CausesValidation="false"/>
                    <asp:Button ID="btnWithdraw" runat="server" Text="Withdraw Money" OnClick="btnWithdraw_Click" />
                    <asp:Button ID="btnTransfer" runat="server" Text="Transfer Money" OnClick="btnTransfer_Click" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>User Name : </td>
                <td>
                    <%--<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlUserName" runat="server"></asp:DropDownList>
                </td>
                <td></td>
                <td id="tdtransfer1" runat="server">User Name to Transfer : </td>
                <td id="tdtransfer2" runat="server">
                    <asp:DropDownList ID="ddlUNameTransfer" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr id="trDepositeWithdraw" runat="server">

                <td>Amount :
                </td>

                <td>
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    <asp:CompareValidator ControlToValidate="txtAmount" runat="server" ErrorMessage="Integers only please" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <table id="tblTransaction">

            <tr id="trShowGrid" runat="server">
                <td>
                    <asp:GridView ID="grdStatement" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Status" DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount"></asp:BoundField>
                        </Columns>

                    </asp:GridView>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
