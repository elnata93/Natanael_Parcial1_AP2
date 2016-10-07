<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegistrosSolicitudes.aspx.cs" Inherits="Natanael_Parcial1_AP2.RegistrosMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 230px;
        }
        .auto-style6 {
            width: 506px;
        }
        .auto-style7 {
            width: 377px;
        }
        .auto-style8 {
            width: 220px;
            height: 33px;
        }
        .auto-style9 {
            width: 377px;
            height: 33px;
        }
        .auto-style10 {
            width: 230px;
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="IdTextBox" runat="server"></asp:TextBox>
                        <asp:Button ID="BuacarButton" runat="server" Text="Buscar" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style10">
                        <asp:Timer ID="FechaTimer" runat="server">
                        </asp:Timer>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Razon"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="RazonTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                
            </table>
    </div>
    
    <div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Material"></asp:Label>
                    <asp:DropDownList ID="MaterialDropDownList" runat="server" Height="22px" Width="112px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label4" runat="server" Text="Cantidad"></asp:Label>
                    <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Precio"></asp:Label>
                    <asp:DropDownList ID="PrecioDropDownList" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">
                <asp:GridView ID="MaterialesGridView" runat="server" Width="100%">
                </asp:GridView>
                </td>
                <td class="auto-style6">&nbsp;</td>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
