<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_NBTC_LoginAD" CodeFile="~/CMSWebParts/NBTC/LoginAD.ascx.cs" %>


<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>

<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>

<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>