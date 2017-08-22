<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDown.aspx.cs" Inherits="DropDownListExp.DropDown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="ddlOptions" width="200px" runat="server" AutoPostBack="true"
         DataTextField ="Name" DataValueField="ID" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:DropDownList ID="ddlPolicy" width="200px" runat="server" DataTextField="PolicyName" DataValueField="PolicyID">
        </asp:DropDownList>
    </form>
</body>
</html>
