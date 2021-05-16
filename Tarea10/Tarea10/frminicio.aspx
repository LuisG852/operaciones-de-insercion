<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frminicio.aspx.cs" Inherits="Tarea10.frminicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar Datos" Width="107px" />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="18px" OnTextChanged="TextBox1_TextChanged" style="margin-right: 3px; margin-top: 37px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Buscar por ID" Width="97px" />
        <p>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" style="margin-top: 22px" Width="222px"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Buscar por nombre " Width="139px" />
        </p>
    </form>
</body>
</html>
