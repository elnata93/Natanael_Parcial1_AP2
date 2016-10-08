<%@ Page Title="" Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="RegistrosMateriales.aspx.cs" Inherits="Natanael_Parcial1_AP2.RegistroMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 75px;
        }
        .auto-style5 {
            width: 281px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="panel panel-success">
                <div class="panel-heading">Registro de Materiales</div>
                <div class="panel-body">
                    <div class="form-horizontal col-md-12" role="form">
        
                    
                    
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="IdTextBox" runat="server" Height="26px" Width="148px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="BuscarButton" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="DescripcionTextBox" runat="server" Height="26px" Width="241px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="PrecioTextBox" runat="server" Height="25px" Width="239px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">
                                    <asp:Button ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                                    <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" Text="Guardar" />
                                    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
        
                    
                    
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
