<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegistrosSolicitudes.aspx.cs" Inherits="Natanael_Parcial1_AP2.RegistrosMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 506px;
        }
        .auto-style9 {
            width: 377px;
            height: 33px;
        }
        .auto-style10 {
            width: 230px;
            height: 33px;
        }
        .auto-style11 {
            width: 749px;
        }
        .auto-style12 {
            width: 225px;
        }
        .auto-style13 {
            width: 320px;
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <table style="width:100%;">
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                    <asp:TextBox ID="IdTextBox" runat="server" Height="16px" Width="191px"></asp:TextBox>
                </td>
                    <td class="auto-style9">
                        <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click1"  />
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                            
                        <asp:TextBox ID="FechaTextBox" runat="server"  Height="16px" Width="78px" OnTextChanged="FechaTextBox_TextChanged"></asp:TextBox>
                            
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label9" runat="server" Text="Razon"></asp:Label>
                    <asp:TextBox ID="RazonTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label3" runat="server" Text="Material"></asp:Label>
                    <asp:DropDownList ID="MaterialDropDownList" runat="server" Height="22px" Width="112px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="Label4" runat="server" Text="Cantidad"></asp:Label>
                    <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Precio"></asp:Label>
                    <asp:DropDownList ID="PrecioDropDownList" runat="server" Height="19px" Width="103px">
                    </asp:DropDownList>
                    <asp:Label ID="Label8" runat="server" Text="Importe"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                </td>
            </tr>
            
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style11">
                <asp:GridView ID="MaterialesGridView" runat="server" Width="100%">
                </asp:GridView>
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td>
                    <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
                    </td>
                </tr>
               
            <tr>
                <td class="auto-style12">&nbsp;</td>
                
                <td class="auto-style11">
                    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                </td>

                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
