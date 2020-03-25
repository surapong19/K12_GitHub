<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_NBTC_LoginAD" 
    CodeFile="LoginAD.ascx.cs" %>





<asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
<asp:TextBox ID="txtUser" runat="server" Text="surapong.test@gmail.com"></asp:TextBox>

<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>

<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>