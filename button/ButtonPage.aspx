<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonPage.aspx.cs" Inherits="button.ButtonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<asp:HiddenField ID="hfID" runat="server"/>


			<h1>
				Community total:
				<asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label>
			</h1>

			<table>
				<tr>
					<td>
						<asp:TextBox ID="txtName" runat="server" OnTextChanged="txtName_TextChanged" MaxLength="16" placeholder="Name"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" />
					</td>
				</tr>
			</table>

			<asp:Button ID="btnUpload" runat="server" Text="Cash in" OnClick="btnUpload_Click" />
			
			<h2>
				Scoreboard
			</h2>

			<asp:GridView ID="gvScoreboard" runat="server">
				<Columns>
				</Columns>
			</asp:GridView>

        </div>
    </form>
</body>
</html>
